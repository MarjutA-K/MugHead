using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathText : MonoBehaviour
{
    public GameObject DeathTxt;
    public GameObject RetryTxt;
    
    public GameObject Player;

    private bool IsDead = false;

    // Start is called before the first frame update
    void Start()
    {
        IsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.FindWithTag("Player"))
        {
            DeathTxt.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
            RetryTxt.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
            IsDead = true;
        }

        if(IsDead)
        {
            if(Input.GetButtonDown("Select"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
