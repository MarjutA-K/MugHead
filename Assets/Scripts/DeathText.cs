using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathText : MonoBehaviour
{
    public GameObject DeathTxt;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.FindWithTag("Player"))
        {
            DeathTxt.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        }
    }
}
