using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ButtonHandler : VariableDump
{

    
    public GameObject gloveL;
    public GameObject gloveR;

    //Ints
    //Ints
    public static int check;
    public static int checkA;

    public static int bagF;
    public static int BagReset;

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

    public static int RUp;
    public static int RDown;
    public static int RCenterUp;
    public static int RCenterDown;

    public static int LUp;
    public static int LDown;
    public static int LCenterUp;
    public static int LCenterDown;


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

    public static string LUpTxt = "Off";
    public static string LDownTxt = "Off";
    public static string LCenterUpTxt = "Off";
    public static string LCenterDownTxt = "On";

    public static string RUpTxt = "Off";
    public static string RDownTxt = "Off";
    public static string RCenterUpTxt = "Off";
    public static string RCenterDownTxt = "On";


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

        BagReset = BagReset1;

        RUp = RUp1;
        RDown = RDown1;
        RCenterUp = RCenterUp1;
        RCenterDown = RCenterDown1;

        LUp = LUp1;
        LDown = LDown1;
        LCenterUp = LCenterUp1;
        LCenterDown = LCenterDown1;
    }

    [System.Serializable]
    public class Player
    {
        public int ID;

        public Task[] task;


    }
    [System.Serializable]
    public class Task
    {
        public Test[] test;
    }
    [System.Serializable]

    public class PlayerList
    {
        public Player[] player;
    }
    [System.Serializable]
    public class Test
    {
        public int test;
        //public int Task;
        public int Attempts;
        public string SoundTxt = ButtonHandler.SoundTxt;
        public string SpeechTxt = ButtonHandler.SpeechTxt;
        public string moveTTxt = ButtonHandler.moveTTxt;
        public string periodicTxt = ButtonHandler.periodicTxt;
        public string seqTxt = ButtonHandler.seqTxt;
    }

    public Player myPlayer = new Player();
    //public PlayerList myPlayerList = new PlayerList();
    public Test myTestList = new Test();

    public void outputJSON()
    {
        string strOutput = JsonUtility.ToJson(myPlayer);
        File.WriteAllText(Application.dataPath + "/text.txt", strOutput);

        string strOutput2 = JsonUtility.ToJson(myTestList);
        File.WriteAllText(Application.dataPath + "/text2.txt", strOutput2);

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
            ArmMove = 2;
            ArmMoveTxt = "OnHit";
            
        }
        else if(ArmMove == 0)
        {
            ArmMove = 1;
            ArmMoveTxt = "Controlled";
        }
        else if(ArmMove == 2) 
        {
            ArmMove = 0;
            ArmMoveTxt = "Random";
        }

    }

    public void RightUp()
    {
        if(ArmMove == 1)
        {
            if(RUp == 0)
            {
                RUp = 1;
                RDown = 0;
                RCenterUp = 0;
                RCenterDown = 0;

                RUpTxt = "On";
                RDownTxt = "Off";
                RCenterUpTxt = "Off";
                RCenterDownTxt = "Off";
            }
        }
    }
    public void RightDown()
    {
        if (ArmMove == 1)
        {
            if (RDown == 0)
            {
                RDown = 1;
                RUp = 0;
                RCenterUp = 0;
                RCenterDown = 0;

                RUpTxt = "Off";
                RDownTxt = "On";
                RCenterUpTxt = "Off";
                RCenterDownTxt = "Off";
            }
        }
    }

    public void RightCenterDown()
    {
        if (ArmMove == 1)
        {

            if (RCenterDown == 0)
            {
                RCenterDown = 1;
                RDown = 0;
                RUp = 0;
                RCenterUp = 0;

                RUpTxt = "Off";
                RDownTxt = "Off";
                RCenterUpTxt = "Off";
                RCenterDownTxt = "On";
            }
        }
    }

    public void RightCenterUp()
    {
        if (ArmMove == 1)
        {


            if (RCenterUp == 0)
            {
                RCenterUp = 1;
                RDown = 0;
                RCenterDown = 0;
                RUp = 0;

                RUpTxt = "Off";
                RDownTxt = "Off";
                RCenterUpTxt = "On";
                RCenterDownTxt = "Off";
            }
        }
    }

    public void LeftUp()
    {
        if (ArmMove == 1)
        {

            if (LUp == 0)
            {
                LUp = 1;
                LDown = 0;
                LCenterDown = 0;
                LCenterUp = 0;

                LUpTxt = "On";
                LDownTxt = "Off";
                LCenterUpTxt = "Off";
                LCenterDownTxt = "Off";
            }
        }
    }

    public void LeftDown()
    {
        if (ArmMove == 1)
        {

            if (LDown == 0)
            {
                LDown = 1;
                LUp = 0;
                LCenterDown = 0;
                LCenterUp = 0;

                LUpTxt = "Off";
                LDownTxt = "On";
                LCenterUpTxt = "Off";
                LCenterDownTxt = "Off";
            }
        }
    }

    public void LeftCenterDown()
    {
        if (ArmMove == 1)
        {


            if (LCenterDown == 0)
            {
                LCenterDown = 1;
                LDown = 0;
                LUp = 0;
                LCenterUp = 0;

                LUpTxt = "Off";
                LDownTxt = "Off";
                LCenterUpTxt = "Off";
                LCenterDownTxt = "On";
            }
        }
    }

    public void LeftCenterUp()
    {
        if (ArmMove == 1)
        {
            if (LCenterUp == 0)
            {
                LCenterUp = 1;
                LDown = 0;
                LCenterDown = 0;
                LUp = 0;

                LUpTxt = "Off";
                LDownTxt = "Off";
                LCenterUpTxt = "On";
                LCenterDownTxt = "Off";
            }
        }
    }

    public void ResetTheBag()
    {
        if(BagReset == 0)
        {
            BagReset = 1;
        }
        
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.1f);
        
    }

}
