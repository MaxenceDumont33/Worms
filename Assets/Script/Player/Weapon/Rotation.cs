using UnityEngine;


public class Rotation : MonoBehaviour
{
   private Camera camera;
   GameObject currentBear;
   
   private GameObject MousLocator;

   private void Start()
   {
      camera = Camera.main;
      currentBear = Versus.Instance.currentBear;
   }

   private void Update()
   {
       if (PauseMenu.Instance.paused ==false)
       {
           Vector3 weaponPosition = transform.position;
           Vector2 mousePosition2D = Input.mousePosition;
           Vector3 mousePosition3D = new Vector3(mousePosition2D.x, mousePosition2D.y, 14);
           Vector3 mousePosition = camera.ScreenToWorldPoint(mousePosition3D);
           Vector2 direction = mousePosition - weaponPosition;
           transform.rotation = Quaternion.LookRotation(direction);
           if (direction.x > 0)
           {
               currentBear.transform.rotation = Quaternion.Euler(-90, 90, 0);
               currentBear.GetComponent<HealtText>().healtText.transform.rotation = Quaternion.Euler(0, 0, 0);
           }
           if (direction.x < 0)
           {
               currentBear.transform.rotation = Quaternion.Euler(-90, -90, 0);
               currentBear.GetComponent<HealtText>().healtText.transform.rotation = Quaternion.Euler(0, 0, 0);
           }
       }
   }
}
