using TMPro;
using UnityEngine;

public class StartCharacter : MonoBehaviour
{
    private static StartCharacter instance;
    public static StartCharacter Instance => instance;

    [SerializeField]
    private TextMeshProUGUI StartCharacterText;
    
    public int startCharacter = 1; 
    
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

    public void IncreasedStartCharacter()
    {
        if (startCharacter < 9)
        {
            startCharacter++;
            StartCharacterText.text = startCharacter.ToString();
        }
    }
   
    public void DecreasedStartCharacter()
    {
        if (startCharacter > 1)
        {
            startCharacter--;
            StartCharacterText.text = startCharacter.ToString();
        }
    }
}
