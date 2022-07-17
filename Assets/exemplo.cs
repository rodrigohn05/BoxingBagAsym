using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exemplo : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            {
                Debug.Log(mousePos.x+", "+ mousePos.y);
            }
        }
    }
}
