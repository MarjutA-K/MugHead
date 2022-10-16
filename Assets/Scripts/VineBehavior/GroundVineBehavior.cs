using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundVineBehavior : MonoBehaviour
{
    public Animator groundVineAnimator;
    public Animator vineAnimator1;
    public Animator vineAnimator2;
    public Animator vineAnimator3;

    public GameObject vine1;
    public GameObject vine2;
    public GameObject vine3;

    private bool startGroundVine;
    private bool startVine1;
    private bool startVine2;
    private bool startVine3;

    int waitTime1;
    int waitTime2;
    int waitTime3;


    // Start is called before the first frame update
    void Start()
    {
        vine1.SetActive(false);
        vine2.SetActive(false);
        vine3.SetActive(false);

        startGroundVine = true;
        startVine1 = true;
        startVine2 = true;
        startVine3 = true;

        waitTime1 = Random.Range(5, 15);
        waitTime2 = Random.Range(5, 15);
        waitTime3 = Random.Range(5, 15);
    }

    // Update is called once per frame
    void Update()
    {      
        if (startGroundVine)
        {
            StartCoroutine(GroundVineStart());

        }
        else
        {          
            StartCoroutine(GroundVineReverse());
        }

        if(startVine1)
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
    }

    IEnumerator GroundVineStart()
    {
        yield return new WaitForSeconds(4f);
        groundVineAnimator.SetBool("playAnim", true);
        startGroundVine = false;
    }

    IEnumerator GroundVineReverse()
    {
        yield return new WaitForSeconds(5f);
        // Reverse animation play
        groundVineAnimator.SetFloat("Direction", -1);
        groundVineAnimator.Play("GroundVineAnimation", -1, float.NegativeInfinity);
    }

    IEnumerator Vine1AnimStart()
    {   
        //yield return new WaitForSeconds(7f);
        yield return new WaitForSeconds(waitTime1);
        vine1.SetActive(true);
        vineAnimator1.SetBool("playAnim", true);
        startVine1 = false;
    }

    IEnumerator Vine1Reverse()
    {
        yield return new WaitForSeconds(2f);
        //yield return new WaitForSeconds(waitTime);
        vineAnimator1.SetFloat("Direction", -1);
        vineAnimator1.Play("VineAnimation", -1, float.NegativeInfinity);
    }

    IEnumerator Vine2AnimStart()
    {
        //yield return new WaitForSeconds(8f);
        yield return new WaitForSeconds(waitTime2);
        vine2.SetActive(true);
        vineAnimator2.SetBool("playAnim", true);
        startVine2 = false;
    }

    IEnumerator Vine2Reverse()
    {
        yield return new WaitForSeconds(2f);
        //yield return new WaitForSeconds(waitTime);
        vineAnimator2.SetFloat("Direction", -1);
        vineAnimator2.Play("VineAnimation2", -1, float.NegativeInfinity);
    }

    IEnumerator Vine3AnimStart()
    {
        //yield return new WaitForSeconds(6f);
        yield return new WaitForSeconds(waitTime3);
        vine3.SetActive(true);
        vineAnimator3.SetBool("playAnim", true);
        startVine3 = false;
    }

    IEnumerator Vine3Reverse()
    {
        yield return new WaitForSeconds(2f);
        //yield return new WaitForSeconds(waitTime);
        vineAnimator3.SetFloat("Direction", -1);
        vineAnimator3.Play("VineAnimation3", -1, float.NegativeInfinity);
    }
}
