using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public int isHit;
    public string textValue;
    public Text textElement;
    List<string> punches = new List<string>();
    
    // Start is called before the first frame update
    void Start()
    {
        punches.Add("Right Hook");
        punches.Add("Left Hook");
        punches.Add("Upper Cut");
        punches.Add("Jab");
        punches.Add("Right Cross");
        punches.Add("Left Cross");

        textValue = punches[Random.Range(0, punches.Count)];
        textElement.text = textValue;
    }

    // Update is called once per frame
    void Update()
    {
      if(GlovesHit.isHit1 != isHit)
        {
            textValue = punches[Random.Range(0, punches.Count)];
            textElement.text = textValue;
            isHit = GlovesHit.isHit1;
        }
    }

}
