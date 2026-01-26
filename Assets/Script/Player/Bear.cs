
using UnityEngine;
public class Bear : MonoBehaviour
{
    [SerializeField]
    public float hp = 100;

    [SerializeField]
    private float minSize = 0.2f;

    [SerializeField]
    private float maxSize = 1;
    
    private float size = 1;
    [SerializeField]
    private int strength = 20;
    [SerializeField]
    private int jumpforce = 10;
    [SerializeField]
    bool hasaweaponselected = false;
    [SerializeField]
    public bool hasUesAWeapon = false;

    [SerializeField]
    private MeshRenderer Mesh;

    public bool exist = true;
    public int team = 0;
    
    [SerializeField]
    GameObject Weapon;
    [SerializeField]
    public GameObject weaponSpawnLocation;

    public GameObject currentWeapon;

    bool isWalkingToTheRight = false;
    bool isWalkingToTheLeft = false;
    
    private void Start()
    {
      InputManager.instance.onLeftMouseButtonPressStarted += StartShoot;
    }
    
    private void OnDestroy()
    {
        InputManager.instance.onLeftMouseButtonPressStarted -= StartShoot;

        exist = false;
        Versus.Instance.QueueRefresh();
    }

    public void ChangeSize()
    {
        transform.localScale = new Vector3(transform.localScale.x, size * (hp / 200) , size * (hp / 200) );
        if (transform.localScale.y <minSize)
            transform.localScale = new Vector3(transform.localScale.x, minSize, minSize);
        if (transform.localScale.y > maxSize)
            transform.localScale = new Vector3(transform.localScale.x, maxSize, maxSize);
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
    
    public void LookIfDead()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void StartShoot()
    {
        if (currentWeapon != null)
        {
           currentWeapon.GetComponent<Shot>().Shoot();
           hasUesAWeapon = true;
           Versus.Instance.shot = true;
        }
    }

    public void SetTeamColor()
    {
        if (team == 1)
        {
            Mesh.material.color = Color.blue;
        }

        if (team == 2)
        {
            Mesh.material.color = Color.red;
        }
    }
}
