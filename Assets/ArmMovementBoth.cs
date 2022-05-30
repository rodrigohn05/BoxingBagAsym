using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovementBoth : MonoBehaviour
{
    AudioSource audio;
    public AudioClip sonar;
    public AudioClip UpF;
    public AudioClip UpL;
    public AudioClip UpR;
    public AudioClip DownF;
    public AudioClip DownL;
    public AudioClip DownR;
    
    bool protect = true;
    float timer;

    int armPos = 4;
    

    void Start()
    {
        timer = Random.Range(4, 9);
        audio = GetComponent<AudioSource>();
        //positionReset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Adding cardinality options

        if (ButtonHandler.cardinality == 2)
        {
            GameObject.FindGameObjectWithTag("EnR").GetComponent<ArmMovement>().enabled = true;
            GameObject.FindGameObjectWithTag("EnL").GetComponent<ArmMovement>().enabled = true;
            gameObject.GetComponent<ArmMovementBoth>().enabled = false;
        }
        else if (ButtonHandler.cardinality == 1)
        {
            gameObject.GetComponent<ArmMovementBoth>().enabled = true;
        }

        //Audio Settings
        
        if (ButtonHandler.Sound == 0)
        {
            audio.spatialBlend = 0.9f;
        }
        else if (ButtonHandler.Sound == 1 && armPos == 2 || ButtonHandler.Sound == 1 && armPos == 5)
        {
            audio.spatialBlend = 0;
            audio.panStereo = 1;
        }
        else if (ButtonHandler.Sound == 1 && armPos == 0 || ButtonHandler.Sound == 1 && armPos == 3)
        {
            audio.spatialBlend = 0;
            audio.panStereo = -1;
        }
        else if (ButtonHandler.Sound == 2 || armPos == 1 || armPos == 4)
        {
            audio.spatialBlend = 0;
            audio.panStereo = 0;
        }
        

        //Use of sonification
        if (OVRInput.GetDown(OVRInput.Button.One) && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
        {
            audio.PlayOneShot(sonar);
        }

        //Use of Speech
        if (OVRInput.GetDown(OVRInput.Button.One) && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 1 && armPos == 1 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
        {
            audio.pitch = 1f;

            audio.PlayOneShot(UpF);
        }
        else if (OVRInput.GetDown(OVRInput.Button.One) && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 1 && armPos == 0 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
        {
            audio.pitch = 1f;

            audio.PlayOneShot(UpL);
        }
        else if (OVRInput.GetDown(OVRInput.Button.One) && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 1 && armPos == 2 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
        {
            audio.pitch = 1f;

            audio.PlayOneShot(UpR);
        }
        else if (OVRInput.GetDown(OVRInput.Button.One) && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 1 && armPos == 3 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
        {
            audio.pitch = 1f;

            audio.PlayOneShot(DownL);
        }
        else if (OVRInput.GetDown(OVRInput.Button.One) && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 1 && armPos == 4 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
        {
            audio.pitch = 1f;

            audio.PlayOneShot(DownF);
        }
        else if (OVRInput.GetDown(OVRInput.Button.One) && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 1 && armPos == 5 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
        {
            audio.pitch = 1f;

            audio.PlayOneShot(DownR);
        }

        timer -= Time.deltaTime;
        Vector3 position = transform.position;
        if (timer <= 0)
        {
            //Repositioning the hands before every move
            if (armPos == 0)
            {
                position.y -= 0.25f;
                position.x += 0.2f;
                transform.position = position;
            }
            else if(armPos == 1)
            {
                position.y -= 0.25f;
                transform.position = position;
            }
            else if (armPos == 2)
            {
                position.y -= 0.25f;
                position.x -= 0.2f;
                transform.position = position;
            }
            else if (armPos == 3)
            {
                position.x += 0.2f;
                transform.position = position;
            }
            else if (armPos == 5)
            {
                position.x -= 0.2f;
                transform.position = position;
            }

            int nextPos = Random.Range(0, 5);

            //Up Front
            if (nextPos == 1)
            {
                audio.pitch = 2f;
                position.y += 0.25f;
                transform.position = position;
                timer = Random.Range(4, 9);
                armPos = 1;
                if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
                {

                    audio.PlayOneShot(sonar);
                }
                else if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 1 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
                {
                    audio.pitch = 1f;

                    audio.PlayOneShot(UpF);
                }
            }


            //Down Left
            else if (nextPos == 3)
            {
                audio.pitch = 1f;

                position.x -= 0.2f;
                transform.position = position;
                timer = Random.Range(4, 9);
                armPos = 3;
                if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
                {
                    audio.PlayOneShot(sonar);
                }
                else if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 1 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
                {
                    audio.PlayOneShot(DownL);
                }
            }
            //Down Right
            else if (nextPos == 5)
            {
                audio.pitch = 1f;

                position.x += 0.2f;
                transform.position = position;
                timer = Random.Range(4, 9);
                armPos = 5;
                if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
                {
                    audio.PlayOneShot(sonar);
                }
                else if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 1 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
                {
                    audio.PlayOneShot(DownR);
                }

            }
            //Up Left
            else if (nextPos == 0)
            {
                audio.pitch = 2f;

                position.y += 0.25f;
                position.x -= 0.2f;
                transform.position = position;
                timer = Random.Range(4, 9);
                armPos = 0;
                if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
                {
                    audio.PlayOneShot(sonar);
                }
                else if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 1 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
                {
                    audio.pitch = 1f;

                    audio.PlayOneShot(UpL);
                }

            }
            //Up Right
            else if (nextPos == 2)
            {
                audio.pitch = 2f;

                position.y += 0.25f;
                position.x += 0.2f;
                transform.position = position;
                timer = Random.Range(4, 9);
                armPos = 2;
                if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
                {
                    audio.PlayOneShot(sonar);
                }
                else if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 1 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
                {
                    audio.pitch = 1f;

                    audio.PlayOneShot(UpR);
                }

            }
            //Down Front
            else if (nextPos == 4)
            {
                audio.pitch = 1f;

                transform.position = position;

                timer = Random.Range(4, 9);
                armPos = 4;
                if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
                {
                    audio.PlayOneShot(sonar);
                }
                else if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 1 && ButtonHandler.checkA == 0 && ButtonHandler.sequential == 0)
                {
                    audio.PlayOneShot(DownF);
                }

            }


        }
        
    }
}
