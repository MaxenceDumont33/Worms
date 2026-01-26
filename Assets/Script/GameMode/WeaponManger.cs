using System;
using UnityEngine;

public class WeaponManger : MonoBehaviour
{
    private static WeaponManger instance;
    public static WeaponManger Instance => instance;
    [SerializeField] 
    public GameObject Pistol;
    [SerializeField] 
    public GameObject Shotgun;
    
    public GameObject currentWeapon =null;
    GameObject bear;


    public void Start()
    {
        currentWeapon = null;
    }
    
    void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void EquipWeapon(GameObject Weapon)
    {
        bear = Versus.Instance.currentBear;
        GameObject weaponSpawnLocation = bear.GetComponent<Bear>().weaponSpawnLocation;
        if ( bear.GetComponent<Bear>().hasUesAWeapon == false)
        {
            if (currentWeapon == null)
            {
                Vector3 weaponSpawnPosition = new Vector3(weaponSpawnLocation.transform.position.x, weaponSpawnLocation.transform.position.y, weaponSpawnLocation.transform.position.z);
                currentWeapon = Instantiate(Weapon, weaponSpawnPosition , bear.transform.rotation);
                currentWeapon.transform.parent = bear.transform;
                bear.GetComponent<Bear>().currentWeapon = currentWeapon;
            }
        }
    }
    public void UnEquipWeapon()
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }
    }
}
