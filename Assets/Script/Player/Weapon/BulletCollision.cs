using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField]
    GameObject Bullet;
    
    [SerializeField]
    private float Damage = 10;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") )
        {
            CameraMovement.Instance.CurrentCameraMode = CameraMovement.CameraMode.Player;
            Destroy(Bullet);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameObject bearTouch = collision.gameObject;
            bearTouch.GetComponent<Bear>().hp -= Damage;
            bearTouch.GetComponent<HealtText>().ChangeHealtText(bearTouch);
            bearTouch.GetComponent<Bear>().ChangeSize();
            bearTouch.GetComponent<Bear>().LookIfDead();
            CameraMovement.Instance.CurrentCameraMode = CameraMovement.CameraMode.Player;
            Destroy(Bullet);
        }
    }
}
