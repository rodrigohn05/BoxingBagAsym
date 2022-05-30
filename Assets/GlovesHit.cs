using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlovesHit : MonoBehaviour
{
    public static int isHit1;
    VibrationScript HitSpeed;
    OVRGrabbable ovrGrabbable;
    float VibTime;
    public GameObject LArm;
    public GameObject RArm;
    public GameObject bag;
    public Vector3 LPosition;
    public Vector3 RPosition;

    //BagInFront checkBag;
    // Start is called before the first frame update
    void Start()
    {
        LPosition = LArm.transform.position;
        RPosition = RArm.transform.position;
        VibTime = 0.0f;

        ovrGrabbable = GetComponent<OVRGrabbable>();
    }

    private void Update()
    {
        if(OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0)
        {
            Debug.Log("trigger: " + OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger));
            
            StartCoroutine(ResetBag());
        }

        //Use Bag Track button to stop bag following
        if (ButtonHandler.bagF == 0 && bag.GetComponent<BagInFront>().enabled)
        {
            bag.GetComponent<BagInFront>().enabled = false;
        }
        else if (ButtonHandler.bagF == 1 && bag.GetComponent<BagInFront>().enabled == false)
        {
            bag.GetComponent<BagInFront>().enabled = true;
        }
    }
    void OnTriggerEnter(Collider col)
    {

        //Haptics and audio for the Top section of the bag
        if (col.gameObject.tag == "Bag" && ButtonHandler.check == 0)
        {
            //isHit1 = GameObject.Find("Text").GetComponent<ShowText>().isHit;
            if (isHit1 == 0)
            {
                isHit1 = 1;
            }
            else
            {
                isHit1 = 0;
            }

            if (gameObject.tag == "GloveL")
            {
                Vector3 teste = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
                float velocityF = teste.magnitude / 7f;
                
                StartCoroutine(Haptics(0.5f, velocityF + 0.3f, 0.5f, false, true));

            }
            else if (gameObject.tag == "GloveR")
            {
                Vector3 teste2 = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
                float velocityF2 = teste2.magnitude / 7f;
                
                StartCoroutine(Haptics(0.5f, velocityF2 + 0.3f, 0.5f, true, false));

            }


        }
        //Haptics and audio for the mid section of the bag
        if (col.gameObject.tag == "Bagmid" && ButtonHandler.check == 0)
        {
            //isHit1 = GameObject.Find("Text").GetComponent<ShowText>().isHit;
            if (isHit1 == 0)
            {
                isHit1 = 1;
            }
            else
            {
                isHit1 = 0;
            }

            if (gameObject.tag == "GloveL")
            {
                Vector3 teste = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
                float velocityF = teste.magnitude / 7f;
                
                StartCoroutine(Haptics(0.5f, velocityF + 0.15f, 0.4f, false, true));

            }
            else if (gameObject.tag == "GloveR")
            {
                Vector3 teste2 = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
                float velocityF2 = teste2.magnitude / 7f;
                
                StartCoroutine(Haptics(0.5f, velocityF2 + 0.15f, 0.4f, true, false));

            }


        }

        //Haptics and audio for the bottom section of the bag
        if (col.gameObject.tag == "Bagbot" && ButtonHandler.check == 0)
        {
            //isHit1 = GameObject.Find("Text").GetComponent<ShowText>().isHit;
            if (isHit1 == 0)
            {
                isHit1 = 1;
            }
            else
            {
                isHit1 = 0;
            }

            if (gameObject.tag == "GloveL")
            {
                Vector3 teste = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
                float velocityF = teste.magnitude / 7f;
                
                StartCoroutine(Haptics(0.5f, velocityF + 0.02f, 0.4f, false, true));

            }
            else if (gameObject.tag == "GloveR")
            {
                Vector3 teste2 = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
                float velocityF2 = teste2.magnitude / 7f;
                
               StartCoroutine(Haptics(0.5f, velocityF2 + 0.02f, 0.4f, true, false));

            }


        }
        //Haptics for Defensive arms
        if (col.gameObject.tag == "EnL" || col.gameObject.tag == "EnR")
        {
            if (ButtonHandler.check == 0)
            {
                //isHit1 = GameObject.Find("Text").GetComponent<ShowText>().isHit;
                if (isHit1 == 0)
                {
                    isHit1 = 1;
                }
                else
                {
                    isHit1 = 0;
                }

                if (gameObject.tag == "GloveL")
                {
                    Vector3 teste = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
                    float velocityF = teste.magnitude / 7f;

                    StartCoroutine(HapticsPulse(0.5f, 1f, false, true));
                    Debug.Log("Acertei com a esquerda");
                }
                else if (gameObject.tag == "GloveR")
                {
                    Vector3 teste2 = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
                    float velocityF2 = teste2.magnitude / 7f;

                    StartCoroutine(HapticsPulse(0.5f, 1f, true, false));
                    Debug.Log("Acertei com a direita");

                }

            }
        }


    }
    IEnumerator Haptics(float frequency, float amplitude, float duration, bool rightHand, bool leftHand)
    {
        if (rightHand) OVRInput.SetControllerVibration(frequency, amplitude * ButtonHandler.slider, OVRInput.Controller.RHand);
        if (leftHand) OVRInput.SetControllerVibration(frequency, amplitude * ButtonHandler.slider, OVRInput.Controller.LHand);

        yield return new WaitForSeconds(duration);

        if (rightHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RHand);
        if (leftHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LHand);
    }

    IEnumerator HapticsPulse(float frequency, float amplitude, bool rightHand, bool leftHand)
    {
        if (rightHand) OVRInput.SetControllerVibration(frequency, amplitude * ButtonHandler.slider, OVRInput.Controller.RHand);
        if (leftHand) OVRInput.SetControllerVibration(frequency, amplitude * ButtonHandler.slider, OVRInput.Controller.LHand);

        yield return new WaitForSeconds(0.1f);

        if (rightHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RHand);
        if (leftHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LHand);

        yield return new WaitForSeconds(0.1f);

        if (rightHand) OVRInput.SetControllerVibration(frequency,2* amplitude * ButtonHandler.slider, OVRInput.Controller.RHand);
        if (leftHand) OVRInput.SetControllerVibration(frequency, amplitude * ButtonHandler.slider, OVRInput.Controller.LHand);

        yield return new WaitForSeconds(0.1f);

        if (rightHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RHand);
        if (leftHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LHand);

        yield return new WaitForSeconds(0.1f);

        if (rightHand) OVRInput.SetControllerVibration(frequency, amplitude * ButtonHandler.slider, OVRInput.Controller.RHand);
        if (leftHand) OVRInput.SetControllerVibration(frequency, amplitude * ButtonHandler.slider, OVRInput.Controller.LHand);

        yield return new WaitForSeconds(0.1f);

        if (rightHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RHand);
        if (leftHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LHand);
    }

    IEnumerator ResetBag()
    {
        ButtonHandler.bagF = 1;
        bag.GetComponent<BagInFront>().enabled = true;
        LArm.transform.position = LPosition;
        RArm.transform.position = RPosition;
        yield return new WaitForSeconds(0.1f);
        ButtonHandler.bagF = 0;
        bag.GetComponent<BagInFront>().enabled = false;
    }
}
