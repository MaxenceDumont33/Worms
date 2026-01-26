using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    private static UIManager instance;
    public static UIManager Instance => instance;
    
    public GameObject TimerUI;
    public GameObject InventoryUI;
    public TextMeshProUGUI TimeText;
    
    
    
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
    
    private void Start()
    {
        InputManager.instance.onKeyIPressStarted += ShownInventory;
    }

    private void OnDestroy()
    {
        InputManager.instance.onKeyIPressStarted -= ShownInventory;
    }
    private void ShownInventory()
    {
        if (InventoryUI.activeSelf == false)
        {
            InventoryUI.SetActive(true);
        }
        else
            InventoryUI.SetActive(false);
    }

    public void HideInventory()
    {
        if (InventoryUI.activeSelf == true)
        {
            InventoryUI.SetActive(false);
        }
    }
    
    public void SetTime(int time)
    {
        TimeText.text = time.ToString();
    }
}
