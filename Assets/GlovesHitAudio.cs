using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlovesHitAudio : MonoBehaviour
{
    OVRGrabbable ovrGrabbable;

    AudioSource audio;
    public AudioClip HitSoundtop;
    public AudioClip HitSoundmid;
    public AudioClip HitSoundbot;
    public AudioClip HitSoundblock;

    public GameObject bag;
    //BagInFront checkBag;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        ovrGrabbable = GetComponent<OVRGrabbable>();
    }
    private void Update()
    {
        if(ButtonHandler.Sound == 0)
        {
            audio.spatialBlend = 0.9f;
        }
        else if (ButtonHandler.Sound == 1 && gameObject.tag == "GloveR")
        {
            audio.spatialBlend = 0;
            audio.panStereo = 1;
        }
        else if (ButtonHandler.Sound == 1 && gameObject.tag == "GloveL")
        {
            audio.spatialBlend = 0;
            audio.panStereo = -1;

        }
        else if (ButtonHandler.Sound == 2)
        {
            audio.spatialBlend = 0;
            audio.panStereo = 0;
        }
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {

        //Haptics and audio for the Top section of the bag
        if (col.gameObject.tag == "Bag" && ButtonHandler.checkA == 0)
        {
            if (gameObject.tag == "GloveL")
            {
                Vector3 teste = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
                float velocityF = teste.magnitude / 7f;
                audio.PlayOneShot(HitSoundtop, velocityF * ButtonHandler.slider2);                

            }
            else if (gameObject.tag == "GloveR")
            {
                Vector3 teste2 = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
                float velocityF2 = teste2.magnitude / 7f;
                audio.PlayOneShot(HitSoundtop, velocityF2 * ButtonHandler.slider2);

            }
        }
        if (col.gameObject.tag == "Bagmid" && ButtonHandler.checkA == 0)
        {
            if (gameObject.tag == "GloveL")
            {
                Vector3 teste = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
                float velocityF = teste.magnitude / 7f;
                audio.PlayOneShot(HitSoundmid, velocityF * ButtonHandler.slider2);

            }
            else if (gameObject.tag == "GloveR")
            {
                Vector3 teste2 = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
                float velocityF2 = teste2.magnitude / 7f;
                audio.PlayOneShot(HitSoundmid, velocityF2 * ButtonHandler.slider2);

            }
        }
        if (col.gameObject.tag == "Bagbot" && ButtonHandler.checkA == 0)
        {
            if (gameObject.tag == "GloveL")
            {
                Vector3 teste = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
                float velocityF = teste.magnitude / 7f;
                audio.PlayOneShot(HitSoundbot, velocityF * ButtonHandler.slider2);

            }
            else if (gameObject.tag == "GloveR")
            {
                Vector3 teste2 = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
                float velocityF2 = teste2.magnitude / 7f;
                audio.PlayOneShot(HitSoundbot, velocityF2 * ButtonHandler.slider2);

            }
        }
        if (col.gameObject.tag == "EnL" || col.gameObject.tag == "EnR")
        {
            if (ButtonHandler.checkA == 0)
            {
                if (gameObject.tag == "GloveL")
                {
                    Vector3 teste2 = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
                    float velocityF2 = teste2.magnitude / 7f;
                    audio.PlayOneShot(HitSoundblock, velocityF2 * ButtonHandler.slider2);
                }
                else if (gameObject.tag == "GloveR")
                {
                    Vector3 teste2 = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
                    float velocityF2 = teste2.magnitude / 7f;
                    audio.PlayOneShot(HitSoundblock, velocityF2 * ButtonHandler.slider2);
                }
            }
        }
        
    }
}
