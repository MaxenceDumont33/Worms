using UnityEngine;

public class DividePower : MonoBehaviour
{
    public bool DivideHasBeenUse = false;

    private GameObject bear;

    private void Start()
    {
        InputManager.instance.onKeyMPressStarted += Divide;
    }

    private void OnDestroy()
    {
        InputManager.instance.onKeyMPressStarted -= Divide;
    }

    private void OnEnable()
    { 
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
