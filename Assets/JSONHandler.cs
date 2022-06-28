using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONHandler : MonoBehaviour
{
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
}
