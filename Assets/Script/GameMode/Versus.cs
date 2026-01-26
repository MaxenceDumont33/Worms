using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;


public class Versus : MonoBehaviour
{
    
    private static Versus _instance;
    public static Versus Instance => _instance;
    
    public Queue<GameObject> player1Bear = new Queue<GameObject>();
    public Queue<GameObject> player2Bear = new Queue<GameObject>();
    
    public TextMeshProUGUI winningText;
    public GameObject endMenu;

    public GameObject bear;
    
    [SerializeField]
    public GameObject prefabBear;
    
    public GameObject currentBear;
    private int numberOfBearAtStart;
    [SerializeField]
    public int numberOfPlayer = 0;
    [SerializeField]
    public int roundTime = 0;
    [SerializeField]
    public int timeAfterShot = 0;

    public bool timerStop = false;

    public bool shot = false;
    
    
    public int timeRemaining;
    private int playerPlaying = 1;

    void Awake()
    {
        if (_instance)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }
    
    void Start()
    {
        numberOfBearAtStart = StartCharacter.Instance.startCharacter;
        for (int i = 0; i < numberOfBearAtStart; i++)
        {
            bear = Instantiate(prefabBear, new Vector3(Random.Range(-10,10),2,0), prefabBear.transform.rotation);
            bear.GetComponent<Bear>().team = 1;
            bear.GetComponent<Bear>().SetTeamColor();
            bear.GetComponent<HealtText>().ChangeHealtText(bear);
            bear.GetComponent<HealtText>().healtText.transform.rotation = Quaternion.Euler(0, 0, 0);
            player1Bear.Enqueue(bear);
        }
        for (int j = 0; j < numberOfBearAtStart; j++)
        {
            bear = Instantiate(prefabBear, new Vector3(Random.Range(-10,10),2,0), prefabBear.transform.rotation);
            bear.GetComponent<Bear>().team = 2;
            bear.GetComponent<Bear>().SetTeamColor();
            bear.GetComponent<HealtText>().ChangeHealtText(bear);
            bear.GetComponent<HealtText>().healtText.transform.rotation = Quaternion.Euler(0, 0, 0);
            player2Bear.Enqueue(bear);
        }
        StartCoroutine(PlayerTurn(playerPlaying, roundTime, timeRemaining)) ;
    }
    
    
    IEnumerator PlayerTurn( int playerPlaying  , int roundTime , int timeRemaining)
    {
        Debug.Log(playerPlaying);
        timeRemaining = roundTime;
        if (playerPlaying == 1)
        {
            currentBear = player1Bear.Dequeue();
        }
        if (playerPlaying == 2)
        {
            currentBear = player2Bear.Dequeue();
        }
        ActivatePlayer();
        CameraMovement.Instance.CurrentCameraMode = CameraMovement.CameraMode.Player;
        while (timeRemaining > 0)
        {
            if (shot)
            {
                timeRemaining = 5;
                shot = false;
            }
            UIManager.Instance.SetTime(timeRemaining);
            yield return new WaitForSeconds(1);
            timeRemaining -= 1;
            Debug.Log(timeRemaining);
        }if (currentBear != null)
        {
            
            if (playerPlaying == 1)
            {
                player1Bear.Enqueue(currentBear);
            }
            if (playerPlaying == 2)
            {
                player2Bear.Enqueue(currentBear);
            }
        }
        else
        {
            Debug.Log("No");
        }
        EndOfTurn();
    }

    void EndOfTurn()
    { ;
        if (playerPlaying == 1)
        {
            playerPlaying = 2;
        } 
        else if (playerPlaying == 2)
        {
            playerPlaying = 1;
        }
        UnActivatePlayer();
        GameOver();
        StartCoroutine(PlayerTurn(playerPlaying, roundTime, timeAfterShot));
    }

    void GameOver()
    {
        if (player1Bear.Count == 0 || player2Bear.Count == 0)
        {
            if (player1Bear.Count == 0)
            {
                winningText.text = "Player 1";
            }

            if (player2Bear.Count == 0)
            {
                winningText.text = "Player 2";
            }
            endMenu.SetActive(true);
        }
    }

    public void QueueRefresh()
    {
        GameObject bear;
        for (int i = 0; i <= player1Bear.Count; i++)
        {
            if (player1Bear.Count > 0)
            {
                bear = player1Bear.Dequeue();
                if (bear.GetComponent<Bear>().exist)
                {
                    player1Bear.Enqueue(bear);
                }
            }
            else
            {
                Debug.Log("No Bear");
            }
        }

        for (int j = 0; j <= player2Bear.Count; j++)
        {
            if (player2Bear.Count > 0)
            {
                bear = player2Bear.Dequeue();
                if (bear.GetComponent<Bear>().exist)
                {
                    player2Bear.Enqueue(bear);
                }
            }
            else
            {
                Debug.Log("No Bear");
            }
        }
        Debug.Log(player1Bear.Count);
        Debug.Log(player2Bear.Count);
    }
    
    void ActivatePlayer()
    {
        if (currentBear != null)
        {
            currentBear.GetComponent<HealtText>().healtText.enabled = false;
            currentBear.GetComponent<DividePower>().enabled = true;
            currentBear.GetComponent<MergePower>().enabled = true;
            currentBear.GetComponent<DividePower>().DivideHasBeenUse = false;
            currentBear.GetComponent<MergePower>().mergeHasBeenUsed = false;
            currentBear.GetComponent<PlayerMovement>().enabled = true;
        }
    }

    void UnActivatePlayer()
    {
        if (currentBear != null)
        {
            currentBear.GetComponent<HealtText>().healtText.enabled = true;
            currentBear.GetComponent<DividePower>().enabled = false;
            currentBear.GetComponent<MergePower>().enabled = false;
            currentBear.GetComponent<PlayerMovement>().enabled = false;  
        }
    }
    
}
