using UnityEngine;

public class DividePower : MonoBehaviour
{
    public bool DivideHasBeenUse = false;

    private GameObject bear;

    private void OnDisable()
    {
        InputManager.instance.onKeyMPressStarted -= Divide;
    }

    private void OnEnable()
    { 
        InputManager.instance.onKeyMPressStarted += Divide;
        bear = Versus.Instance.currentBear;
        DivideHasBeenUse = true;
    }
    void Divide()
    {
        if (DivideHasBeenUse == false && bear.GetComponent<Bear>().hp > 1)
        {
            bear.GetComponent<Bear>().hp /= 2;
            bear.GetComponent<Bear>().ChangeSize();
            GameObject newBear = Instantiate(Versus.Instance.prefabBear, bear.transform.position, bear.transform.rotation);
            newBear.GetComponent<Bear>().hp = bear.GetComponent<Bear>().hp;
            newBear.GetComponent<Bear>().ChangeSize();
            newBear.GetComponent<Bear>().team = bear.GetComponent<Bear>().team;
            newBear.GetComponent<Bear>().SetTeamColor();
            newBear.GetComponent<HealtText>().ChangeHealtText(newBear);
            newBear.GetComponent<HealtText>().healtText.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (newBear.GetComponent<Bear>().team == 1)
            {
                Versus.Instance.player1Bear.Enqueue(newBear);
            }

            if (newBear.GetComponent<Bear>().team == 2)
            {
                Versus.Instance.player2Bear.Enqueue(newBear);
            }
            DivideHasBeenUse = true;
        }
    }
}
