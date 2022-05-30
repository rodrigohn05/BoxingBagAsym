using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "GloveL" || col.gameObject.tag == "GloveR")
        {
            Vector3 HitSpeed = CalcVelocity(rb.position);
            //Debug.Log(HitSpeed);
        }
    }
    Vector3 CalcVelocity(Vector3 localPos)
    {
        return rb.GetPointVelocity(transform.TransformPoint(localPos));
    }
}
