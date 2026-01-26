using TMPro;
using UnityEngine;
public class HealtText : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI healtText;
    
    
    public void ChangeHealtText(GameObject bear)
    {
        float hp = bear.GetComponent<Bear>().hp;
        healtText.text = hp.ToString();
    }
}
