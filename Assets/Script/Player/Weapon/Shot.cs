using System.Collections;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed = 4;
    [SerializeField] 
    private int amountshot;
    [SerializeField]
    public GameObject bullet;
    [SerializeField]
    private GameObject Canon;

    public GameObject bulletFired;
    
    public void Shoot()
    {
        bulletFired = Instantiate(bullet, Canon.transform.position, Canon.transform.rotation);
        bulletFired.GetComponent<Rigidbody>().AddForce(transform.forward * 500 );
        CameraMovement.Instance.CurrentCameraMode = CameraMovement.CameraMode.Bullet;
        WeaponManger.Instance.UnEquipWeapon();
    }
}
