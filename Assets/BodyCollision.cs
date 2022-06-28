using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollision : MonoBehaviour
{
    public static int bodyCol;
    GameObject LeftArm;
    GameObject RightArm;

    public int LAint;
    public int RAint;

    public int LeftChecker;
    public int RightChecker;

    private void Start()
    {
        LeftArm = GameObject.FindGameObjectWithTag("EnL");
        RightArm = GameObject.FindGameObjectWithTag("EnR");
    }
    private void Update()
    {
        LAint = GetComponent<ArmMovement>().impactL;
        RAint = GetComponent<ArmMovement>().impactR;

        if (LAint != LeftChecker)
        {
            StartCoroutine(DisableCollider());
            LeftChecker = LAint;
        }
        if (RAint != RightChecker)
        {
            StartCoroutine(DisableCollider());
            RightChecker = RAint;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "GloveL" || other.transform.tag == "GloveR")
        {
            if (bodyCol == 0)
            {
                bodyCol = 1;
            }
            else if (bodyCol == 1)
            {
                bodyCol = 0;
            }
        }
    }
    IEnumerator DisableCollider()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }
}
