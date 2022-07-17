using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagInFront : MonoBehaviour
{
    //Remember to drag the camera to this field in the inspector
    public Transform cameraTransform;
    public Transform RightGlove;
    public float distanceCG;
    //Set it to whatever value you think is best
    //public float distanceFromCamera = 0.9f;
    //public float height = 0.8f;


    void Update()
    {
        distanceCG = Vector3.Distance(cameraTransform.position, RightGlove.position);

        Vector3 resultingPos = cameraTransform.position + cameraTransform.forward * (distanceCG+0.3f);

        transform.position = resultingPos;
        
        transform.LookAt(cameraTransform);
        Vector3 posy = transform.position;

        posy.y = resultingPos.y + ButtonHandler.slider3;
        transform.position = posy;
    }
}
