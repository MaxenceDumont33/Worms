using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
      
   public void Play()
   {
      SceneManager.LoadScene("Game_Scene");
   }

   public void Quit()
   {
      Debug.Log("Quit");
      Application.Quit();
   }

   public void MainMenu()
   {
      SceneManager.LoadScene("Main_Menu");
   }

   public void PistolButton()
   {
      Debug.Log("Equip");
      WeaponManger.Instance.EquipWeapon(WeaponManger.Instance.Pistol);
      UIManager.Instance.HideInventory();
   }

   public void ShotgunButton()
   {
      Debug.Log("Equipe");
      WeaponManger.Instance.EquipWeapon(WeaponManger.Instance.Shotgun);
      UIManager.Instance.HideInventory();
   }
}
