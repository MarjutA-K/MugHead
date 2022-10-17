using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreDisplay;

    [Space]
    public bool bossIsDead;
    public GameObject boss;

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = score.ToString();

        if (bossIsDead)
        {
            StartCoroutine(Respawn());
            bossIsDead = false;
        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        boss.SetActive(true);
    }
}
