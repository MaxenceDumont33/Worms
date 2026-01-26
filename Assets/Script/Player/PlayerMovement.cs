using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool isWalkingToTheRight = false;
    bool isWalkingToTheLeft = false;
    [SerializeField]
    private int jumpforce = 425;
    [SerializeField]
    private int speed = 10;
    [SerializeField]
    Rigidbody bear;
    private void Start()
    {
        InputManager.instance.onKeyDPressStarted += MovementRight;
        InputManager.instance.onKeyDPressCanceled += StopMovementToTheRight;
        InputManager.instance.onKeyQPressStarted += MovementLeft;
        InputManager.instance.onKeyQPressCanceled += StopMovementToTheLeft;
        InputManager.instance.onLeftArrowPressStarted += MovementLeft;
        InputManager.instance.onLeftArrowPressCanceled += StopMovementToTheLeft;
        InputManager.instance.onRightArrowPressStarted += MovementRight;
        InputManager.instance.onRightArrowPressCanceled += StopMovementToTheRight;
        InputManager.instance.onKeySpacePressStarted += Jump;
    }
    
    private void OnDestroy()
    {
        InputManager.instance.onKeyDPressStarted -= MovementRight;
        InputManager.instance.onKeyDPressCanceled -= StopMovementToTheRight;
        InputManager.instance.onKeyQPressStarted -= MovementLeft;
        InputManager.instance.onKeyQPressCanceled -= StopMovementToTheLeft;

        InputManager.instance.onLeftArrowPressStarted -= MovementLeft;
        InputManager.instance.onLeftArrowPressCanceled -= StopMovementToTheLeft;
        
        InputManager.instance.onRightArrowPressStarted -= MovementRight;
        InputManager.instance.onRightArrowPressCanceled -= StopMovementToTheRight;
        
        InputManager.instance.onKeySpacePressStarted -= Jump;
    }
    void Update()
    {
        Movement();
    }
    
    void MovementRight()
    {
        isWalkingToTheRight = true;
    }
    
    void MovementLeft()
    {
        isWalkingToTheLeft = true;
    }

    void StopMovementToTheRight()
    {
        isWalkingToTheRight = false;
    }

    void StopMovementToTheLeft()
    {
        isWalkingToTheLeft = false;
    }
    void Movement()
    {
            if (isWalkingToTheRight)
            {
                if (WeaponManger.Instance.currentWeapon != null)
                {
                    WeaponManger.Instance.UnEquipWeapon();
                }
                transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);
                GetComponent<HealtText>().healtText.transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.rotation = Quaternion.Euler(-90, 90, 0);
            }

            if (isWalkingToTheLeft)
            {
                if (WeaponManger.Instance.currentWeapon != null)
                {
                    WeaponManger.Instance.UnEquipWeapon();
                }
                WeaponManger.Instance.UnEquipWeapon();
                transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
                GetComponent<HealtText>().healtText.transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.rotation = Quaternion.Euler(-90, -90, 0);
            }
        
    }
    void Jump()
    {
        if (isGrounded)
        { 
            WeaponManger.Instance.UnEquipWeapon();
            bear.AddForce(0, jumpforce, 0);
        }
        
    }
    public bool isGrounded;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") && !isGrounded){
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 3
            && isGrounded){
            isGrounded = false;
        }
    }
    
}
