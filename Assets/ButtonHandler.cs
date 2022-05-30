using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : VariableDump
{
    public GameObject gloveL;
    public GameObject gloveR;

    //Ints
    //Ints
    public static int check;
    public static int checkA;

    public static int bagF;

    public static float slider;
    public static float slider2;
    public static float slider3;
    public static float slider4;


    public static int Sound;

    public static int moveT;

    public static int Speech;

    public static int periodic;

    public static int sequential;

    public static int cardinality;

    public static int ArmMove;

    //Strings

    public static string checkTxt = "On";
    public static string checkATxt = "On";

    public static string BagFTxt = "In Front";

    public static string SoundTxt = "Spatial";

    public static string moveTTxt = "onTrigger";

    public static string SpeechTxt = "Sonification";

    public static string periodicTxt = "Discrete";

    public static string seqTxt = "Concurrent";

    public static string cardinalityTxt = "Two";

    public static string ArmMoveTxt = "Random";

    private void Start()
    {
        check = check1;
        checkA = checkA1;
        bagF = bagF1;
        slider = slider1;
        slider2 = slider21;
        slider3 = slider31;
        slider4 = slider41;
        Sound = Sound1;
        moveT = moveT1;
        Speech = Speech1;
        periodic = periodic1;
        sequential = sequential1;
        cardinality = cardinality1;
        ArmMove = ArmMove1;
    }

    public void HapticsHandler()
    {

        if(check == 0)
        {
            check = 1;
            checkTxt = "Off";
        }
        else
        {
            check = 0;
            checkTxt = "On";
        }
    }
    public void AudioHandler()
    {

        if (checkA == 0)
        {
            checkA = 1;
            checkATxt = "Off";
        }
        else
        {
            checkA = 0;
            checkATxt = "On";
        }
    }

    public void SliderChangeHaptics(float newValue)
    {
        slider = newValue;
    }
    public void SliderChangeAudio(float newValue2)
    {
        slider2 = newValue2;
    }
    public void SliderChangeHeight(float newValue3)
    {
        slider3 = newValue3;
    }
    public void SliderChangeDistance(float newValue4)
    {
        slider4 = newValue4;
    }

    public void BagTrack()
    {
        if (bagF == 1)
        {
            bagF = 0;
            BagFTxt = "Free";
        }
        else
        {
            bagF = 1;
            BagFTxt = "In Front";
        }

    }
    public void MonoSound()
    {
        if(Sound == 1)
        {
            //Mono
            Sound = 2;
            SoundTxt = "Mono";
        }
        else if(Sound == 0)
        {
            //BI
            Sound = 1;
            SoundTxt = "BI";
        }
        else if (Sound == 2)
        {
            //Spatial
            Sound = 0;
            SoundTxt = "Spatial";
        }
    }

    public void MoveTrigger()
    {
        if (moveT == 0)
        {
            moveT = 1;
            moveTTxt = "onMovement";
        }
        else if (moveT == 1)
        {
            moveT = 0;
            moveTTxt = "onTrigger";
        }
    }

    public void SpeechOn()
    {
        if (Speech == 0)
        {
            Speech = 1;
            SpeechTxt = "Speech";
        }
        else if (Speech == 1)
        {
            Speech = 0;
            SpeechTxt = "Sonification";
        }
    }

    public void CardinOneTwo()
    {
        if (cardinality == 1)
        {
            cardinality = 2;
            cardinalityTxt = "Two";
        }
        else if (cardinality == 2)
        {
            cardinality = 1;
            cardinalityTxt = "One";
        }
    }

    public void SeqConc()
    {
        if (sequential == 0)
        {
            sequential = 1;
            seqTxt = "Concurrent";
        }
        else if(sequential == 1)
        {
            sequential = 0;
            seqTxt = "Sequential";
            
        }
    }

    public void DiscPeriodCont()
    {
        if (periodic == 0)
        {
            periodic = 1;
            periodicTxt = "Periodic";
        }
        else if(periodic == 1)
        {
            periodic = 2;
            periodicTxt = "Continuous";
            
        }
        else if (periodic == 2)
        {
            periodic = 0;
            periodicTxt = "Discrete";
        }
    }

    public void ArmMovement()
    {
        if (ArmMove == 1)
        {
            ArmMove = 0;
            ArmMoveTxt = "Random";
        }
        else
        {
            ArmMove = 1;
            ArmMoveTxt = "Controlled";
        }

    }
}
