using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceScript : MonoBehaviour
{

    public GameObject player;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(this.transform.position, player.transform.position);

        if (distance != 1.7f)
        {
            distance = 1.7f;
            transform.position = (transform.position - player.transform.position).normalized * distance + player.transform.position;
        }
    }
}
