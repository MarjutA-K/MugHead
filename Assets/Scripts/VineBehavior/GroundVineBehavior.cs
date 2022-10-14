using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundVineBehavior : MonoBehaviour
{
    public Animator groundVineAnimator;
    public Animator vineAnimator1;
    public Animator vineAnimator2;
    public Animator vineAnimator3;

    private bool startGroundVine;
    private bool startVine1;
    private bool startVine2;
    private bool startVine3;

    // Start is called before the first frame update
    void Start()
    {
        startGroundVine = true;
        startVine1 = true;
        startVine2 = true;
        startVine3 = true;
    }

    // Update is called once per frame
    void Update()
    {      
        if (startGroundVine)
        {
            StartCoroutine(AnimStart());

        }
        else
        {
            StartCoroutine(AnimReverse());
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

    IEnumerator AnimStart()
    {
        yield return new WaitForSeconds(4f);
        groundVineAnimator.SetBool("playAnim", true);
        startGroundVine = false;
    }

    IEnumerator AnimReverse()
    {
        yield return new WaitForSeconds(5f);
        // Reverse animation play
        groundVineAnimator.SetFloat("Direction", -1);
        groundVineAnimator.Play("GroundVineAnimation", -1, float.NegativeInfinity);
    }

    IEnumerator Vine1AnimStart()
    {   
        yield return new WaitForSeconds(6f);
        vineAnimator1.SetBool("playAnim", true);
        startVine1 = false;
    }

    IEnumerator Vine1Reverse()
    {
        yield return new WaitForSeconds(2f);
        vineAnimator1.SetFloat("Direction", -1);
        vineAnimator1.Play("cubeanimation", -1, float.NegativeInfinity);
    }

    IEnumerator Vine2AnimStart()
    {
        yield return new WaitForSeconds(6f);
        vineAnimator2.SetBool("playAnim", true);
        startVine2 = false;
    }

    IEnumerator Vine2Reverse()
    {
        yield return new WaitForSeconds(2f);
        vineAnimator2.SetFloat("Direction", -1);
        vineAnimator2.Play("cubeanimation", -1, float.NegativeInfinity);
    }

    IEnumerator Vine3AnimStart()
    {
        yield return new WaitForSeconds(8f);
        vineAnimator3.SetBool("playAnim", true);
        startVine3 = false;
    }

    IEnumerator Vine3Reverse()
    {
        yield return new WaitForSeconds(2f);
        vineAnimator3.SetFloat("Direction", -1);
        vineAnimator3.Play("cubeanimation", -1, float.NegativeInfinity);
    }
}
