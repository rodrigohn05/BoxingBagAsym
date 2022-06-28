using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset JSONtext;

    [System.Serializable]
    public class Player
    {
        public int ID;
        public Config[] config;
        public Task[] task;
    }
    [System.Serializable]
    public class Task
    {
        public int TaskID;
        public Test[] test;
    }
    [System.Serializable]

    public class PlayerList
    {
        public Player[] player;
    }
    [System.Serializable]
    public class Config
    {
        public string SoundTxt = ButtonHandler.SoundTxt;
        public string SpeechTxt = ButtonHandler.SpeechTxt;
        public string moveTTxt = ButtonHandler.moveTTxt;
        public string periodicTxt = ButtonHandler.periodicTxt;
        public string seqTxt = ButtonHandler.seqTxt;
        public string cardinalityTxt = ButtonHandler.cardinalityTxt;
        public string checkTxt = ButtonHandler.checkTxt;
    }
    
    [System.Serializable]
    public class Test
    {
        public int TestID;
        public Attempts[] attempts;
    }

    [System.Serializable]
    public class Attempts
    {
        public int Number;
        public string HittingHand;
        public string ObjectHit;
    }

    public PlayerList myPlayerList = new PlayerList();

    // Start is called before the first frame update
    public void Read()
    {
        Debug.Log("Read");
        myPlayerList = JsonUtility.FromJson<PlayerList>(JSONtext.text);
    }

    // Update is called once per frame
    void Start()
    {
        myPlayerList = JsonUtility.FromJson<PlayerList>(JSONtext.text);
    }
}
