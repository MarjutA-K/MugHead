using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool IsPaused = false;

    public GameObject PauseUI;
    public GameObject Player;

    private float verticalInput;

    private int Options = 3;
    private int CurrentOption = 1;

    public GameObject ResumeTXT;
    public GameObject RetryTXT;
    public GameObject ExitTXT;

    public Color SelectedColour;

    private bool OptionChange = false;


    // Start is called before the first frame update
    void Start()
    {
        PauseUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Start"))
        {
            if (IsPaused)
            {
                Resume();
            }
            else if (!IsPaused)
            {
                Pause();
            }
        }

        if(IsPaused)
        {
            if (verticalInput == 1 && !OptionChange)
            {
                CurrentOption -= 1;
                OptionChange = true;
            }
            else if (verticalInput == -1 && !OptionChange)
            {
                CurrentOption += 1;
                OptionChange = true;
            }
        }

        if (CurrentOption > Options)
        {
            CurrentOption = 1;
        }
        else if (CurrentOption < 0)
        {
            CurrentOption = 3;
        }

        if (verticalInput == 0)
        {
            OptionChange = false;
        }


        if (IsPaused)
        {
            if (CurrentOption == 1)
            {
                ResumeTXT.GetComponent<TMPro.TextMeshProUGUI>().color = SelectedColour;
                RetryTXT.GetComponent<TMPro.TextMeshProUGUI>().color = Color.black;
                ExitTXT.GetComponent<TMPro.TextMeshProUGUI>().color = Color.black;
                if (Input.GetButtonDown("Fire1"))
                {
                    Resume();
                }
            }
            else if (CurrentOption == 2)
            {
                RetryTXT.GetComponent<TMPro.TextMeshProUGUI>().color = SelectedColour;
                ResumeTXT.GetComponent<TMPro.TextMeshProUGUI>().color = Color.black;
                ExitTXT.GetComponent<TMPro.TextMeshProUGUI>().color = Color.black;
                if (Input.GetButtonDown("Fire1"))
                {
                    Restart();
                }
            }
            else
            {
                ExitTXT.GetComponent<TMPro.TextMeshProUGUI>().color = SelectedColour;
                ResumeTXT.GetComponent<TMPro.TextMeshProUGUI>().color = Color.black;
                RetryTXT.GetComponent<TMPro.TextMeshProUGUI>().color = Color.black;
                if (Input.GetButtonDown("Fire1"))
                {
                    Application.Quit();
                }
            }

        }
    }

    void Pause()
    {
        IsPaused = true;
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        Player.GetComponent<PlayerController>().enabled = false;
    }


    void Resume()
    {
        IsPaused = false;
        PauseUI.SetActive(false);
        Time.timeScale = 1.0f;
        Player.GetComponent<PlayerController>().enabled = true;
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
        IsPaused = false;
        PauseUI.SetActive(false);
        Time.timeScale = 1.0f;
        Player.GetComponent<PlayerController>().enabled = true;
    }
}
