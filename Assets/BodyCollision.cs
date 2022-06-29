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
        
    }
    private void Update()
    {
        LeftArm = GameObject.FindGameObjectWithTag("EnL");
        RightArm = GameObject.FindGameObjectWithTag("EnR");
        LAint = LeftArm.GetComponent<ArmMovement>().impactL;
        RAint = RightArm.GetComponent<ArmMovement>().impactR;

        if (LAint != LeftChecker)
        {
            Debug.Log("LAint != LeftChecker");
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
            StartCoroutine(DisableColliders(LeftArm));
            StartCoroutine(DisableColliders(RightArm));

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
        yield return new WaitForSeconds(0.8f);
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }

    IEnumerator DisableColliders(GameObject arm)
    {
        arm.GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        arm.GetComponent<CapsuleCollider>().enabled = true;
    }
}
