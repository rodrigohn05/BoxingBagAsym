using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextHandler : MonoBehaviour
{
    public GameObject txt;

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Text mytxt = txt.GetComponent<Text>();
        if(transform.tag == "TextHaptic")
        {
            mytxt.text = ButtonHandler.slider.ToString();
        }
        else if(transform.tag == "TextAudio")
        {
            mytxt.text = ButtonHandler.slider2.ToString();
        }
        else if (transform.tag == "TextHeight")
        {
            mytxt.text = ButtonHandler.slider3.ToString();
        }
        else if (transform.tag == "TextDistance")
        {
            mytxt.text = ButtonHandler.slider4.ToString();
        }
        else if (transform.tag == "TextHapticsString")
        {
            mytxt.text = ButtonHandler.checkTxt;
        }
        else if (transform.tag == "TextAudioString")
        {
            mytxt.text = ButtonHandler.checkATxt;
        }
        else if(transform.tag == "TextBag")
        {
            mytxt.text = ButtonHandler.BagFTxt;
        }
        else if (transform.tag == "TextSoundType")
        {
            mytxt.text = ButtonHandler.SoundTxt;
        }
        else if (transform.tag == "TextmoveT")
        {
            mytxt.text = ButtonHandler.moveTTxt;
        }
        else if (transform.tag == "TextSpeech")
        {
            mytxt.text = ButtonHandler.SpeechTxt;
        }
        else if (transform.tag == "TextCardin")
        {
            mytxt.text = ButtonHandler.cardinalityTxt;
        }
        else if (transform.tag == "TextSeq")
        {
            mytxt.text = ButtonHandler.seqTxt;
        }
        else if (transform.tag == "TextDisc")
        {
            mytxt.text = ButtonHandler.periodicTxt;
        }
        else if(transform.tag == "TextArmMove")
        {
            mytxt.text = ButtonHandler.ArmMoveTxt;
        }


        else if (transform.tag == "TextRUp")
        {
            mytxt.text = ButtonHandler.RUpTxt;
        }
        else if (transform.tag == "TextRDown")
        {
            mytxt.text = ButtonHandler.RDownTxt;
        }
        else if (transform.tag == "TextRCenterUp")
        {
            mytxt.text = ButtonHandler.RCenterUpTxt;
        }
        else if (transform.tag == "TextRCenterDown")
        {
            mytxt.text = ButtonHandler.RCenterDownTxt;
        }


        else if (transform.tag == "TextLUp")
        {
            mytxt.text = ButtonHandler.LUpTxt;
        }
        else if (transform.tag == "TextLDown")
        {
            mytxt.text = ButtonHandler.LDownTxt;
        }
        else if (transform.tag == "TextLCenterUp")
        {
            mytxt.text = ButtonHandler.LCenterUpTxt;
        }
        else if (transform.tag == "TextLCenterDown")
        {
            mytxt.text = ButtonHandler.LCenterDownTxt;
        }
    }
}
