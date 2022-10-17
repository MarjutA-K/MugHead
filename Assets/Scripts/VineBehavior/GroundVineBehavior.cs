using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundVineBehavior : MonoBehaviour
{
    public Animator groundVineAnimator;
    public Animator vineAnimator1;
    public Animator vineAnimator2;
    public Animator vineAnimator3;
    public Animator vineAnimator4;
    public Animator vineAnimator5;
    public Animator vineAnimator6;

    public GameObject groundVine;
    public GameObject vine1;
    public GameObject vine2;
    public GameObject vine3;
    public GameObject vine4;
    public GameObject vine5;
    public GameObject vine6;

    private bool startGroundVine;
    private bool startVine1;
    private bool startVine2;
    private bool startVine3;
    private bool startVine4;
    private bool startVine5;
    private bool startVine6;

    private int waitTime1;
    private int waitTime2;
    private int waitTime3;
    private int waitTime4;
    private int waitTime5;
    private int waitTime6;

    private int reverse_time;

    // Start is called before the first frame update
    void OnEnable()
    {
        groundVine.SetActive(false);
        vine1.SetActive(false);
        vine2.SetActive(false);
        vine3.SetActive(false);
        vine4.SetActive(false);
        vine5.SetActive(false);
        vine6.SetActive(false);

        startGroundVine = true;
        startVine1 = true;
        startVine2 = true;
        startVine3 = true;
        startVine4 = true;
        startVine5 = true;
        startVine6 = true;

        waitTime1 = Random.Range(2, 13);
        waitTime2 = Random.Range(4, 15);
        waitTime3 = Random.Range(2, 13);
        waitTime4 = Random.Range(12, 22);
        waitTime5 = Random.Range(14, 22);
        waitTime6 = Random.Range(12, 22);

        reverse_time = 3;
    }

    // Update is called once per frame
    void Update()
    {      
        if (startGroundVine)
        {
            StartCoroutine(GroundVineStart());

        }
        /*else
        {          
            StartCoroutine(GroundVineReverse());
        }*/

        if (startVine1)
        {
            StartCoroutine(Vine1AnimStart());
        }
        else
        {
            StartCoroutine(Vine1Reverse());           
        }
    
        if (startVine2)
        {
            StartCoroutine(Vine2AnimStart());
        }
        else
        {
            StartCoroutine(Vine2Reverse());
        }

        if (startVine3)
        {
            StartCoroutine(Vine3AnimStart());
        }
        else
        {
            StartCoroutine(Vine3Reverse());
        }


        if (startVine4)
        {
            StartCoroutine(Vine4AnimStart());
        }
        else
        {
            StartCoroutine(Vine4Reverse());
        }

        if (startVine5)
        {
            StartCoroutine(Vine5AnimStart());
        }
        else
        {
            StartCoroutine(Vine5Reverse());
        }

        if (startVine6)
        {
            StartCoroutine(Vine6AnimStart());
        }
        else
        {
            StartCoroutine(Vine6Reverse());
        }
    }

    IEnumerator GroundVineStart()
    {
        yield return new WaitForSeconds(1f);
        groundVineAnimator.SetBool("playAnim", true);
        groundVine.SetActive(true);
        startGroundVine = false;
    }

    // Reverse animation play
    /*IEnumerator GroundVineReverse()
    {
        yield return new WaitForSeconds(5f);    
        groundVineAnimator.SetFloat("Direction", -1);
        groundVineAnimator.Play("GroundVineAnimation", -1, float.NegativeInfinity);
    }*/

    IEnumerator Vine1AnimStart()
    {   
        yield return new WaitForSeconds(waitTime1);
        vine1.SetActive(true);
        vineAnimator1.SetBool("playAnim", true);
        startVine1 = false;
    }

    // Reverse animation play
    IEnumerator Vine1Reverse()
    {
        yield return new WaitForSeconds(reverse_time);
        vineAnimator1.SetFloat("Direction", -1);
        vineAnimator1.Play("VineAnimation", -1, float.NegativeInfinity);
    }

    IEnumerator Vine2AnimStart()
    {
        yield return new WaitForSeconds(waitTime2);
        vine2.SetActive(true);
        vineAnimator2.SetBool("playAnim", true);
        startVine2 = false;
    }

    // Reverse animation play
    IEnumerator Vine2Reverse()
    {
        yield return new WaitForSeconds(reverse_time);
        vineAnimator2.SetFloat("Direction", -1);
        vineAnimator2.Play("VineAnimation2", -1, float.NegativeInfinity);
    }

    IEnumerator Vine3AnimStart()
    {
        yield return new WaitForSeconds(waitTime3);
        vine3.SetActive(true);
        vineAnimator3.SetBool("playAnim", true);
        startVine3 = false;
    }

    // Reverse animation play
    IEnumerator Vine3Reverse()
    {
        yield return new WaitForSeconds(reverse_time);
        vineAnimator3.SetFloat("Direction", -1);
        vineAnimator3.Play("VineAnimation3", -1, float.NegativeInfinity);
    }

    IEnumerator Vine4AnimStart()
    {
        yield return new WaitForSeconds(waitTime4);
        vine4.SetActive(true);
        vineAnimator4.SetBool("playAnim", true);
        startVine4 = false;
    }

    // Reverse animation play
    IEnumerator Vine4Reverse()
    {
        yield return new WaitForSeconds(reverse_time);
        vineAnimator4.SetFloat("Direction", -1);
        vineAnimator4.Play("VineAnimation", -1, float.NegativeInfinity);
    }

    IEnumerator Vine5AnimStart()
    {
        yield return new WaitForSeconds(waitTime5);
        vine5.SetActive(true);
        vineAnimator5.SetBool("playAnim", true);
        startVine5 = false;
    }

    // Reverse animation play
    IEnumerator Vine5Reverse()
    {
        yield return new WaitForSeconds(reverse_time);
        vineAnimator5.SetFloat("Direction", -1);
        vineAnimator5.Play("VineAnimation2", -1, float.NegativeInfinity);
    }

    IEnumerator Vine6AnimStart()
    {
        yield return new WaitForSeconds(waitTime6);
        vine6.SetActive(true);
        vineAnimator6.SetBool("playAnim", true);
        startVine6 = false;
    }

    // Reverse animation play
    IEnumerator Vine6Reverse()
    {
        yield return new WaitForSeconds(reverse_time);
        vineAnimator6.SetFloat("Direction", -1);
        vineAnimator6.Play("VineAnimation3", -1, float.NegativeInfinity);
    }
}
