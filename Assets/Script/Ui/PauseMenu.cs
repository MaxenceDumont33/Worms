using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private static PauseMenu instance;
    public static PauseMenu Instance => instance;
    [SerializeField]
    GameObject pauseMenu;
    public bool paused = false;
    
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
    
    void Start()
    {
        InputManager.instance.onEscapeButtonPressStarted += Pause;
    }

    void OnDestroy()
    {
        InputManager.instance.onEscapeButtonPressStarted -= Pause;
    }

    public void Pause()
    {
        if (!paused)
        {
            paused = true;
            pauseMenu.SetActive(true);
            //Time.timeScale = 0f;
            //TimeScale 0 Empeche L'activation des bouton.
        }
        else
        {
            paused = false;
            pauseMenu.SetActive(false);
            //Time.timeScale = 1;
        }
    }
}
