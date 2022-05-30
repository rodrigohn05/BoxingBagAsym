using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    AudioSource audio;
    public AudioClip sonar;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One) && gameObject.tag == "EnL")
        {
            audio.PlayOneShot(sonar);
        }
        else if (OVRInput.Get(OVRInput.Button.Three) && gameObject.tag == "EnR")
        {
            audio.PlayOneShot(sonar);
        }
    }


}
