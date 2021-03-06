using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{

    public GameObject EnemyLeft;
    public GameObject EnemyRight;

    public AudioSource audio;
    public AudioClip sonar;
    public AudioClip UpFR;
    public AudioClip UpFL;
    public AudioClip UpL;
    public AudioClip UpR;
    public AudioClip DownFR;
    public AudioClip DownFL;
    public AudioClip DownL;
    public AudioClip DownR;
    public AudioClip beep;
    bool protect = true;
    float timer;
    float timerPeriod;
    float contTimer;
    bool Rplaying;
    bool Lplaying;

    Vector3 positionReset;
    public int left = 3;
    public int right = 3;

    int thisPosR = 0;
    int thisPosL = 0;

    int randomOnHitR = 0;
    int randomOnHitL = 0;

    public int AMHitH = 0;
    public int AMHitB = 0;
    public int AMHitR=0;
    public int AMHitL = 0;
    public int amhit1=0;

    public GameObject checkotherR;
    public GameObject checkotherL;

    public int impactR;
    public int impactL;

    int variavel;

    List<int> usedValues = new List<int>();


    void Start()
    {
        timer = Random.Range(4,9);
        audio = GetComponent<AudioSource>();
        timerPeriod = 4f;
        contTimer = 2.522f;

        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Adding cardinality options
        if (ButtonHandler.cardinality == 1)
        {

            GameObject.FindGameObjectWithTag("Arms").GetComponent<ArmMovementBoth>().enabled = true;
            gameObject.GetComponent<ArmMovement>().enabled = false;
        }
        else if (ButtonHandler.cardinality == 2)
        {
            gameObject.GetComponent<ArmMovement>().enabled = true;
        }


        if(gameObject.tag == "EnL" && EnemyRight.GetComponent<AudioSource>().isPlaying)
        {
            audio.Stop();
        }
        else if (gameObject.tag == "EnR" && EnemyLeft.GetComponent<AudioSource>().isPlaying)
        {
            audio.Stop();
        }
        
        /*
                //Making it really sequential
                if(ButtonHandler.sequential == 0 && gameObject.tag == "EnL" && EnemyRight.GetComponent<AudioSource>().isPlaying)
                {
                    audio.Stop();

                }
                else if(ButtonHandler.sequential == 0 && gameObject.tag == "EnR" && EnemyLeft.GetComponent<AudioSource>().isPlaying )
                {
                    audio.Stop();

                }
        */
        //Sound Properties
        if (ButtonHandler.Sound == 0)
        {
            audio.spatialBlend = 0.9f;
        }
        else if (ButtonHandler.Sound == 1 && gameObject.tag == "EnL" && left != 0 && left != 3)
        {
            
            audio.spatialBlend = 0;
            audio.panStereo = 1;
        }
        else if(ButtonHandler.Sound == 1 && ButtonHandler.Speech == 0 && gameObject.tag == "EnL" && left == 0 || ButtonHandler.Sound == 1 && ButtonHandler.Speech == 0 && gameObject.tag == "EnL" && left == 3)
        {
            
            audio.spatialBlend = 0.9f;
            audio.panStereo = 0;
        }
        else if (ButtonHandler.Sound == 1 && gameObject.tag == "EnR" && right != 0 && right != 3)
        {
            audio.spatialBlend = 0;
            audio.panStereo = -1;

        }
        else if (ButtonHandler.Sound == 1 && ButtonHandler.Speech == 0 && gameObject.tag == "EnR" && right == 0 || ButtonHandler.Sound == 1 && ButtonHandler.Speech == 0 && gameObject.tag == "EnR" && right == 3)
        {
            audio.spatialBlend = 0.9f;
            audio.panStereo = 0;
        }

        else if (ButtonHandler.Sound == 2)
        {
            audio.spatialBlend = 0;
            audio.panStereo = 0;
        }

        //Periodic Sound
        if (ButtonHandler.periodic == 1)
        {
            timerPeriod -= Time.deltaTime;
            if (timerPeriod <= 0)
            {
                StartCoroutine(PeriodicSound());
                timerPeriod = 4f;
            }
        }


        //Continuous Settings
        if(ButtonHandler.periodic == 2 && ButtonHandler.sequential == 0)
        {
            contTimer -= Time.deltaTime;
            if (contTimer <= 0)
            {
                StartCoroutine(Continuous());
                contTimer = 2.6f;
            }
        }
        else if(ButtonHandler.periodic == 2 && ButtonHandler.sequential == 1)
        {
            
            StartCoroutine(Continuous());
        }
        else if(ButtonHandler.periodic == 1 || ButtonHandler.periodic == 0)
        {
            audio.volume = 0.29f;
            audio.loop = false;
            
        }

        //StartCoroutine(Continuous());

        //Use of sonification with button trigger
        if (OVRInput.GetDown(OVRInput.Button.One) && gameObject.tag == "EnL" && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
        {
            
            if (ButtonHandler.sequential == 0)
            {
                StartCoroutine(SequentialSoundL());
                
            }
            else if (ButtonHandler.sequential == 1)
            {
                audio.PlayOneShot(sonar);
            }
        }
        else if (OVRInput.GetDown(OVRInput.Button.Three) && gameObject.tag == "EnR" && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
        {
            if (ButtonHandler.sequential == 0)
            {
                StartCoroutine(SequentialSoundR());

            }
            else if (ButtonHandler.sequential == 1)
            {
                audio.PlayOneShot(sonar);
            }
        }

        //Use of Speech with BUTTON trigger
        if (gameObject.tag == "EnR")
        {
            if (OVRInput.GetDown(OVRInput.Button.Three) && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 1 && right == 0 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
            {
                audio.pitch = 1f;
                if (ButtonHandler.sequential == 0)
                {
                    StartCoroutine(SequentialSpeechR(UpFL));
                }
                else if (ButtonHandler.sequential == 1)
                {
                    audio.PlayOneShot(UpFL);
                }
            }
            else if (OVRInput.GetDown(OVRInput.Button.Three) && gameObject.tag == "EnR" && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 1 && right == 1 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
            {
                audio.pitch = 1f;

                if (ButtonHandler.sequential == 0)
                {
                    StartCoroutine(SequentialSpeechR(DownL));
                }
                else if (ButtonHandler.sequential == 1)
                {
                    audio.PlayOneShot(DownL);
                }
            }
            else if (OVRInput.GetDown(OVRInput.Button.Three) && gameObject.tag == "EnR" && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 1 && right == 2 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
            {
                audio.pitch = 1f;

                if (ButtonHandler.sequential == 0)
                {
                    StartCoroutine(SequentialSpeechR(UpL));
                }
                else if (ButtonHandler.sequential == 1)
                {
                    audio.PlayOneShot(UpL);
                }
            }
            else if (OVRInput.GetDown(OVRInput.Button.Three) && gameObject.tag == "EnR" && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 1 && right == 3 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
            {
                audio.pitch = 1f;

                if (ButtonHandler.sequential == 0)
                {
                    StartCoroutine(SequentialSpeechR(DownFL));
                }
                else if (ButtonHandler.sequential == 1)
                {
                    audio.PlayOneShot(DownFL);
                }
            }
        }
        else if (gameObject.tag == "EnL") {

            if (OVRInput.GetDown(OVRInput.Button.One) && gameObject.tag == "EnL" && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 1 && left == 0 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
            {
                audio.pitch = 1f;

                if (ButtonHandler.sequential == 0)
                {
                    StartCoroutine(SequentialSpeechL(UpFR));
                }
                else if (ButtonHandler.sequential == 1)
                {
                    audio.PlayOneShot(UpFR);
                }
            }

            else if (OVRInput.GetDown(OVRInput.Button.One) && gameObject.tag == "EnL" && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 1 && left == 1 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
            {
                audio.pitch = 1f;

                if (ButtonHandler.sequential == 0)
                {
                    StartCoroutine(SequentialSpeechL(DownR));
                }
                else if (ButtonHandler.sequential == 1)
                {
                    audio.PlayOneShot(DownR);
                }
            }

            else if (OVRInput.GetDown(OVRInput.Button.One) && gameObject.tag == "EnL" && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 1 && left == 2 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
            {
                audio.pitch = 1f;

                if (ButtonHandler.sequential == 0)
                {
                    StartCoroutine(SequentialSpeechL(UpR));
                }
                else if (ButtonHandler.sequential == 1)
                {
                    audio.PlayOneShot(UpR);
                }
            }

            else if (OVRInput.GetDown(OVRInput.Button.One) && gameObject.tag == "EnL" && ButtonHandler.moveT == 0 && ButtonHandler.Speech == 1 && left == 3 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
            {
                audio.pitch = 1f;

                if (ButtonHandler.sequential == 0)
                {
                    StartCoroutine(SequentialSpeechL(DownFR));
                }
                else if (ButtonHandler.sequential == 1)
                {
                    audio.PlayOneShot(DownFR);
                }
            }
        }

        //Movement of the enemy's hands

        
        
        Vector3 position = transform.position;
        if (ButtonHandler.ArmMove == 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ResetPos();

                int nextPos = Random.Range(0, 3);
                //Center up Right hand
                if (nextPos == 0 && transform.tag == "EnR")
                {

                    position.y += 0.25f;
                    transform.position = position;
                    timer = Random.Range(4, 9);
                    right = 0;
                    MovementArms();

                }
                //Center up Left hand
                else if (nextPos == 0 && transform.tag == "EnL")
                {

                    position.y += 0.25f;
                    transform.position = position;
                    timer = Random.Range(4, 9);
                    left = 0;
                    MovementArms();

                }
                //Players Left down
                else if (nextPos == 1 && transform.tag == "EnR")
                {
                    audio.pitch = 1f;

                    position.x -= 0.2f;
                    transform.position = position;
                    timer = Random.Range(4, 9);
                    right = 1;
                    MovementArms();

                }
                //Players Right down
                else if (nextPos == 1 && transform.tag == "EnL")
                {
                    audio.pitch = 1f;

                    position.x += 0.2f;
                    transform.position = position;
                    timer = Random.Range(4, 9);
                    left = 1;
                    MovementArms();

                }
                //Players LEft up
                else if (nextPos == 2 && transform.tag == "EnR")
                {


                    position.y += 0.25f;
                    position.x -= 0.2f;
                    transform.position = position;
                    timer = Random.Range(4, 9);
                    right = 2;
                    MovementArms();

                }
                //Players Right up
                else if (nextPos == 2 && transform.tag == "EnL")
                {


                    position.y += 0.25f;
                    position.x += 0.2f;
                    transform.position = position;
                    timer = Random.Range(4, 9);
                    left = 2;
                    MovementArms();

                }
                //Center down Right Hand
                else if (nextPos == 3 && transform.tag == "EnR")
                {
                    audio.pitch = 1f;

                    transform.position = position;

                    timer = Random.Range(4, 9);
                    right = 3;
                    MovementArms();

                }
                //Center down left Hand
                else if (nextPos == 3 && transform.tag == "EnL")
                {
                    audio.pitch = 1f;

                    transform.position = position;

                    timer = Random.Range(4, 9);
                    left = 3;
                    MovementArms();

                }

            }
        }


        else if (ButtonHandler.ArmMove == 1)
        {
            
            
            //Right Arm Movement Controlled From PC
            if (ButtonHandler.RUp == 1 && transform.tag == "EnR" && right != 2)
            {
                //Debug.Log("Tou aqui moh kota");

                ResetPos();
                right = 2;
                position.y += 0.25f;
                position.x -= 0.2f;
                transform.position = position;
                MovementArms();
            }

            else if(ButtonHandler.RDown == 1 && transform.tag == "EnR" && right != 1)
            {
                ResetPos();
                audio.pitch = 1f;
                right = 1;
                position.x -= 0.2f;
                transform.position = position;
                MovementArms();
            }
            else if(ButtonHandler.RCenterUp == 1 && transform.tag == "EnR" && right != 0)
            {
                ResetPos();
                right = 0;
                position.y += 0.25f;
                transform.position = position;
                MovementArms();
            }
            else if(ButtonHandler.RCenterDown == 1 && transform.tag == "EnR" && right != 3)
            {
                ResetPos();
                audio.pitch = 1f;
                right = 3;
                MovementArms();
            }

            //Left Arm Movement Controlled From PC
            if (ButtonHandler.LUp == 1 && transform.tag == "EnL" && left != 2)
            {
                ResetPos();
                left = 2;
                position.y += 0.25f;
                position.x += 0.2f;
                transform.position = position;
                MovementArms();
            }

            else if (ButtonHandler.LDown == 1 && transform.tag == "EnL" && left != 1)
            {
                ResetPos();
                audio.pitch = 1f;
                left = 1;
                position.x += 0.2f;
                transform.position = position;
                MovementArms();
            }
            else if (ButtonHandler.LCenterUp == 1 && transform.tag == "EnL" && left != 0)
            {
                ResetPos();
                left = 0;
                position.y += 0.25f;
                transform.position = position;
                MovementArms();
            }
            else if (ButtonHandler.LCenterDown == 1 && transform.tag == "EnL" && left != 3)
            {
                ResetPos();
                audio.pitch = 1f;
                left = 3;
                MovementArms();
            }
        }

        else if(ButtonHandler.ArmMove == 2)
        {
            if (transform.tag == "EnR")
            {
                checkotherR = GameObject.FindGameObjectWithTag("EnL");
                impactL = checkotherR.GetComponent<ArmMovement>().amhit1;
                if(impactL != AMHitL)
                {
                    ResetPos();
                    right = Random.Range(0, 3);
                    Debug.Log("right: " + right);
                    
                    
                    if (right == 0 && transform.tag == "EnR")
                    {
                        position.y += 0.25f;
                        transform.position = position;
                        MovementArms();
                    }
                    else if (right == 1 && transform.tag == "EnR")
                    {
                        audio.pitch = 1f;

                        position.x -= 0.2f;
                        transform.position = position;
                        MovementArms();
                    }
                    else if (right == 2 && transform.tag == "EnR")
                    {
                        position.y += 0.25f;
                        position.x -= 0.2f;
                        transform.position = position;
                        MovementArms();
                    }
                    else if (right == 3 && transform.tag == "EnR")
                    {
                        audio.pitch = 1f;
                        MovementArms();
                    }
                    AMHitL = impactL;
                }
                else if(impactR != AMHitR)
                {
                    ResetPos();
                    right = Random.Range(0, 3);
                    Debug.Log("right: " + right);
                    
                    
                    if (right == 0 && transform.tag == "EnR")
                    {
                        position.y += 0.25f;
                        transform.position = position;
                        MovementArms();
                    }
                    else if (right == 1 && transform.tag == "EnR")
                    {
                        audio.pitch = 1f;

                        position.x -= 0.2f;
                        transform.position = position;
                        MovementArms();
                    }
                    else if (right == 2 && transform.tag == "EnR")
                    {
                        position.y += 0.25f;
                        position.x -= 0.2f;
                        transform.position = position;
                        MovementArms();
                    }
                    else if (right == 3 && transform.tag == "EnR")
                    {
                        audio.pitch = 1f;
                        MovementArms();
                    }
                    AMHitR = impactR;
                }
            }
            else if (transform.tag == "EnL")
            {
                checkotherL = GameObject.FindGameObjectWithTag("EnR");
                impactR = checkotherL.GetComponent<ArmMovement>().amhit1;
                if (impactR != AMHitR)
                {
                    ResetPos();
                    left = Random.Range(0, 3);
                    Debug.Log("left: " + left);
                    
                    if (left == 0 && transform.tag == "EnL")
                    {
                        position.y += 0.25f;
                        transform.position = position;
                        MovementArms();
                    }

                    else if (left == 1 && transform.tag == "EnL")
                    {
                        audio.pitch = 1f;
                        position.x += 0.2f;
                        transform.position = position;
                        MovementArms();
                    }
                    else if (left == 2 && transform.tag == "EnL")
                    {
                        position.y += 0.25f;
                        position.x += 0.2f;
                        transform.position = position;
                        MovementArms();
                    }
                    else if (left == 3 && transform.tag == "EnL")
                    {
                        audio.pitch = 1f;
                        MovementArms();
                    }
                    AMHitR = impactR;
                }
                else if(impactL != AMHitL)
                {
                    ResetPos();
                    left = Random.Range(0, 3);
                    Debug.Log("left: " + left);

                    if (left == 0 && transform.tag == "EnL")
                    {
                        position.y += 0.25f;
                        transform.position = position;
                        MovementArms();
                    }

                    else if (left == 1 && transform.tag == "EnL")
                    {
                        audio.pitch = 1f;
                        position.x += 0.2f;
                        transform.position = position;
                        MovementArms();
                    }
                    else if (left == 2 && transform.tag == "EnL")
                    {
                        position.y += 0.25f;
                        position.x += 0.2f;
                        transform.position = position;
                        MovementArms();
                    }
                    else if (left == 3 && transform.tag == "EnL")
                    {
                        audio.pitch = 1f;
                        MovementArms();
                    }
                    AMHitL = impactL;
                }

                
            }

            if (BodyCollision.bodyCol != AMHitB)
            {
                ResetPos();
                if (transform.tag == "EnR")
                {
                    right = Random.Range(0, 3);
                    Debug.Log("right: " + right);
                }
                else if (transform.tag == "EnL")
                {
                    left = Random.Range(0, 3);
                    Debug.Log("left: " + left);
                }

                if (right == 0 && transform.tag == "EnR")
                {
                    position.y += 0.25f;
                    transform.position = position;
                    MovementArms();
                }
                else if (right == 1 && transform.tag == "EnR")
                {
                    audio.pitch = 1f;

                    position.x -= 0.2f;
                    transform.position = position;
                    MovementArms();
                }
                else if (right == 2 && transform.tag == "EnR")
                {
                    position.y += 0.25f;
                    position.x -= 0.2f;
                    transform.position = position;
                    MovementArms();
                }
                else if (right == 3 && transform.tag == "EnR")
                {
                    audio.pitch = 1f;
                    MovementArms();
                }

                if (left == 0 && transform.tag == "EnL")
                {
                    position.y += 0.25f;
                    transform.position = position;
                    MovementArms();
                }

                else if (left == 1 && transform.tag == "EnL")
                {
                    audio.pitch = 1f;
                    position.x += 0.2f;
                    transform.position = position;
                    MovementArms();
                }
                else if (left == 2 && transform.tag == "EnL")
                {
                    position.y += 0.25f;
                    position.x += 0.2f;
                    transform.position = position;
                    MovementArms();
                }
                else if (left == 3 && transform.tag == "EnL")
                {
                    audio.pitch = 1f;
                    MovementArms();
                }

                AMHitB = BodyCollision.bodyCol;
            }
            if (HeadCollision.headCol != AMHitH)
            {
                ResetPos();
                if (transform.tag == "EnR")
                {
                    right = Random.Range(0, 3);
                    Debug.Log("right: " + right);
                }
                else if (transform.tag == "EnL")
                {
                    left = Random.Range(0, 3);
                    Debug.Log("left: " + left);
                }

                if (right == 0 && transform.tag == "EnR")
                {
                    position.y += 0.25f;
                    transform.position = position;
                    MovementArms();
                }
                else if (right == 1 && transform.tag == "EnR")
                {
                    audio.pitch = 1f;

                    position.x -= 0.2f;
                    transform.position = position;
                    MovementArms();
                }
                else if (right == 2 && transform.tag == "EnR")
                {
                    position.y += 0.25f;
                    position.x -= 0.2f;
                    transform.position = position;
                    MovementArms();
                }
                else if (right == 3 && transform.tag == "EnR")
                {
                    audio.pitch = 1f;
                    MovementArms();
                }

                if (left == 0 && transform.tag == "EnL")
                {
                    position.y += 0.25f;
                    transform.position = position;
                    MovementArms();
                }

                else if (left == 1 && transform.tag == "EnL")
                {
                    audio.pitch = 1f;
                    position.x += 0.2f;
                    transform.position = position;
                    MovementArms();
                }
                else if (left == 2 && transform.tag == "EnL")
                {
                    position.y += 0.25f;
                    position.x += 0.2f;
                    transform.position = position;
                    MovementArms();
                }
                else if (left == 3 && transform.tag == "EnL")
                {
                    audio.pitch = 1f;
                    MovementArms();
                }
                AMHitH = HeadCollision.headCol;
            }
            /**
                        if (amhit1 != AMHit)
                        {
                            ResetPos();
                            if (transform.tag == "EnR")
                            {
                                right = Random.Range(0, 3);
                                Debug.Log("right: " + right);
                            }
                            else if (transform.tag == "EnL")
                            {
                                left = Random.Range(0, 3);
                                Debug.Log("left: " + left);
                            }

                            if (right == 0 && transform.tag == "EnR")
                            {
                                position.y += 0.25f;
                                transform.position = position;
                                MovementArms();
                            }
                            else if (right == 1 && transform.tag == "EnR")
                            {
                                audio.pitch = 1f;

                                position.x -= 0.2f;
                                transform.position = position;
                                MovementArms();
                            }
                            else if (right == 2 && transform.tag == "EnR")
                            {
                                position.y += 0.25f;
                                position.x -= 0.2f;
                                transform.position = position;
                                MovementArms();
                            }
                            else if (right == 3 && transform.tag == "EnR")
                            {
                                audio.pitch = 1f;
                                MovementArms();
                            }

                            if (left == 0 && transform.tag == "EnL")
                            {
                                position.y += 0.25f;
                                transform.position = position;
                                MovementArms();
                            }

                            else if (left == 1 && transform.tag == "EnL")
                            {
                                audio.pitch = 1f;
                                position.x += 0.2f;
                                transform.position = position;
                                MovementArms();
                            }
                            else if (left == 2 && transform.tag == "EnL")
                            {
                                position.y += 0.25f;
                                position.x += 0.2f;
                                transform.position = position;
                                MovementArms();
                            }
                            else if (left == 3 && transform.tag == "EnL")
                            {
                                audio.pitch = 1f;
                                MovementArms();
                            }
                            AMHit = amhit1;
                        }
                        **/
        }



        void ResetPos()
        {
            //Debug.Log("Bithc");
                //Repositioning the hands before every move
                if (right == 0)
                {
                    position.y -= 0.25f;
                    transform.position = position;
                }
                else if (right == 1)
                {
                    position.x += 0.2f;
                    transform.position = position;
                }
                else if (right == 2)
                {
                    position.y -= 0.25f;
                    position.x += 0.2f;
                    transform.position = position;
                }

                if (left == 0)
                {
                    position.y -= 0.25f;
                    transform.position = position;
                }
                else if (left == 1)
                {
                    position.x -= 0.2f;
                    transform.position = position;
                }
                else if (left == 2)
                {
                    position.y -= 0.25f;
                    position.x -= 0.2f;
                    transform.position = position;
                }
        }

        void MovementArms()
        {
            if (gameObject.tag == "EnR")
            {
                if (right == 0)
                {
                    audio.pitch = 2f;
                    if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
                    {

                        if (ButtonHandler.sequential == 0)
                        {
                            StartCoroutine(SequentialSoundR());

                        }
                        else if (ButtonHandler.sequential == 1)
                        {
                            audio.PlayOneShot(sonar);
                        }
                    }
                    else if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 1 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
                    {
                        audio.pitch = 1f;

                        if (ButtonHandler.sequential == 0)
                        {
                            audio.pitch = 1f;
                            audio.Stop();
                            StartCoroutine(SequentialSpeechR(UpFL));
                        }
                        else if (ButtonHandler.sequential == 1)
                        {
                            audio.PlayOneShot(UpFL);
                        }
                    }
                    else if (ButtonHandler.periodic == 1 && ButtonHandler.Speech == 0 || ButtonHandler.periodic == 2 && ButtonHandler.Speech == 0)
                    {
                        audio.pitch = 2f;
                    }
                }

                else if (right == 1)
                {
                    audio.pitch = 1f;
                    if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
                    {
                        if (ButtonHandler.sequential == 0)
                        {
                            StartCoroutine(SequentialSoundR());

                        }
                        else if (ButtonHandler.sequential == 1)
                        {
                            audio.PlayOneShot(sonar);
                        }
                    }
                    else if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 1 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
                    {
                        if (ButtonHandler.sequential == 0)
                        {
                            audio.pitch = 1f;
                            audio.Stop();
                            StartCoroutine(SequentialSpeechR(DownL));
                        }
                        else if (ButtonHandler.sequential == 1)
                        {
                            audio.PlayOneShot(DownL);
                        }
                    }
                }

                else if (right == 2)
                {
                    audio.pitch = 2f;
                    if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
                    {

                        if (ButtonHandler.sequential == 0)
                        {
                            StartCoroutine(SequentialSoundR());

                        }
                        else if (ButtonHandler.sequential == 1)
                        {
                            audio.PlayOneShot(sonar);
                        }
                    }
                    else if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 1 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
                    {
                        audio.pitch = 1f;

                        if (ButtonHandler.sequential == 0)
                        {
                            audio.pitch = 1f;
                            audio.Stop();
                            StartCoroutine(SequentialSpeechR(UpL));
                        }
                        else if (ButtonHandler.sequential == 1)
                        {
                            audio.PlayOneShot(UpL);
                        }
                    }
                    else if (ButtonHandler.periodic == 1 && ButtonHandler.Speech == 0 || ButtonHandler.periodic == 2 && ButtonHandler.Speech == 0)
                    {
                        audio.pitch = 2f;
                    }
                }
                else if (right == 3)
                {
                    audio.pitch = 1f;
                    if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
                    {
                        if (ButtonHandler.sequential == 0)
                        {
                            StartCoroutine(SequentialSoundR());
                        }
                        else if (ButtonHandler.sequential == 1)
                        {
                            audio.PlayOneShot(sonar);
                        }
                    }
                    else if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 1 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
                    {
                        if (ButtonHandler.sequential == 0)
                        {
                            audio.pitch = 1f;
                            audio.Stop();
                            StartCoroutine(SequentialSpeechR(DownFL));
                        }
                        else if (ButtonHandler.sequential == 1)
                        {
                            audio.PlayOneShot(DownFL);
                        }
                    }
                }
            }
            else if (gameObject.tag == "EnL")
            {
                if (left == 0)
                {
                    audio.pitch = 2f;
                    if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
                    {

                        if (ButtonHandler.sequential == 0)
                        {
                            StartCoroutine(SequentialSoundL());

                        }
                        else if (ButtonHandler.sequential == 1)
                        {
                            audio.PlayOneShot(sonar);
                        }
                    }
                    else if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 1 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
                    {
                        audio.pitch = 1f;

                        if (ButtonHandler.sequential == 0)
                        {
                            audio.pitch = 1f;
                            audio.Stop();
                            StartCoroutine(SequentialSpeechL(UpFR));
                        }
                        else if (ButtonHandler.sequential == 1)
                        {
                            audio.PlayOneShot(UpFR);
                        }
                    }
                    else if (ButtonHandler.periodic == 1 && ButtonHandler.Speech == 0 || ButtonHandler.periodic == 2 && ButtonHandler.Speech == 0)
                    {
                        audio.pitch = 2f;
                    }

                }
                else if (left == 1)
                {
                    audio.pitch = 1f;
                    if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
                    {
                        if (ButtonHandler.sequential == 0)
                        {
                            StartCoroutine(SequentialSoundL());

                        }
                        else if (ButtonHandler.sequential == 1)
                        {
                            audio.PlayOneShot(sonar);
                        }
                    }
                    else if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 1 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
                    {
                        if (ButtonHandler.sequential == 0)
                        {
                            audio.pitch = 1f;
                            audio.Stop();
                            StartCoroutine(SequentialSpeechL(DownR));
                        }
                        else if (ButtonHandler.sequential == 1)
                        {
                            audio.PlayOneShot(DownR);
                        }
                    }
                }

                else if (left == 2)
                {
                    audio.pitch = 2f;
                    if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
                    {

                        if (ButtonHandler.sequential == 0)
                        {
                            StartCoroutine(SequentialSoundL());

                        }
                        else if (ButtonHandler.sequential == 1)
                        {
                            audio.PlayOneShot(sonar);
                        }
                    }
                    else if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 1 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
                    {
                        audio.pitch = 1f;

                        if (ButtonHandler.sequential == 0)
                        {
                            audio.pitch = 1f;
                            audio.Stop();
                            StartCoroutine(SequentialSpeechL(UpR));
                        }
                        else if (ButtonHandler.sequential == 1)
                        {
                            audio.PlayOneShot(UpR);
                        }
                    }
                    else if (ButtonHandler.periodic == 1 && ButtonHandler.Speech == 0 || ButtonHandler.periodic == 2 && ButtonHandler.Speech == 0)
                    {
                        audio.pitch = 2f;
                    }
                }

                else if (left == 3)
                {
                    audio.pitch = 1f;
                    if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 0 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
                    {
                        if (ButtonHandler.sequential == 0)
                        {
                            StartCoroutine(SequentialSoundL());

                        }
                        else if (ButtonHandler.sequential == 1)
                        {
                            audio.PlayOneShot(sonar);
                        }
                    }
                    else if (ButtonHandler.moveT == 1 && ButtonHandler.Speech == 1 && ButtonHandler.checkA == 0 && ButtonHandler.periodic == 0)
                    {
                        if (ButtonHandler.sequential == 0)
                        {
                            audio.pitch = 1f;
                            audio.Stop();
                            StartCoroutine(SequentialSpeechL(DownFR));
                        }
                        else if (ButtonHandler.sequential == 1)
                        {
                            audio.PlayOneShot(DownFR);
                        }
                    }
                }
            }
            
        }
        
        
    }

    void OnTriggerEnter(Collider other)
    {

        //Debug.Log("ontrigger");
        
            if (other.gameObject.tag == "GloveR" || other.gameObject.tag == "GloveL")
            {
                if (gameObject.transform.tag == "EnL")
                {
                    if (amhit1 == 0)
                    {
                        amhit1 = 1;
                        impactL = 1;
                    }
                    else if (amhit1 == 1)
                    {
                        amhit1 = 0;
                        impactL = 0;
                    }
                }
                
                else if (gameObject.transform.tag == "EnR")
                {
                    if (amhit1 == 0)
                    {
                        amhit1 = 1;
                        impactR = 1;
                    }
                    else if (amhit1 == 1)
                    {
                        amhit1 = 0;
                        impactR = 0;
                    }
                }
            }
        
    }


    IEnumerator PeriodicSound()
        {
            if (ButtonHandler.Speech == 0)
            {
                if (ButtonHandler.sequential == 1)
                {
                    audio.PlayOneShot(sonar);
                    yield return new WaitForSeconds(2);

                }
                else if (ButtonHandler.sequential == 0)
                {
                    if(gameObject.tag == "EnL")
                    {
                        
                        audio.PlayOneShot(sonar);
                    }
                    else if (gameObject.tag == "EnR")
                    {
                        yield return new WaitForSeconds(2);
                        
                        audio.PlayOneShot(sonar);
                    }
                         
                }
            }
            else if (ButtonHandler.Speech == 1)
            {
                audio.pitch = 1f;
                if (ButtonHandler.sequential == 1)
                {
                    audio.pitch = 1f;
                    if (gameObject.tag == "EnL" && left == 0)
                    {
                        audio.PlayOneShot(UpFR);
                    }
                    else if (gameObject.tag == "EnL" && left == 1)
                    {
                        audio.PlayOneShot(DownR);
                    }
                    else if (gameObject.tag == "EnL" && left == 2)
                    {
                        audio.PlayOneShot(UpR);
                    }
                    else if (gameObject.tag == "EnL" && left == 3)
                    {
                        audio.PlayOneShot(DownFR);
                    }
                    else if (gameObject.tag == "EnR" && right == 0)
                    {
                        audio.PlayOneShot(UpFL);
                    }
                    else if (gameObject.tag == "EnR" && left == 1)
                    {
                        audio.PlayOneShot(DownL);
                    }
                    else if (gameObject.tag == "EnR" && left == 2)
                    {
                        audio.PlayOneShot(UpL);
                    }
                    else if (gameObject.tag == "EnR" && left == 3)
                    {
                        audio.PlayOneShot(DownFL);
                    }
                    yield return new WaitForSeconds(2);

                }
                else if (ButtonHandler.sequential == 0)
                {
                    audio.pitch = 1f;
                    if (gameObject.tag == "EnL" && left == 0)
                    {
                        audio.PlayOneShot(UpFR);
                        
                    }
                    else if (gameObject.tag == "EnL" && left == 1)
                    {
                        audio.PlayOneShot(DownR);
                    }
                    else if (gameObject.tag == "EnL" && left == 2)
                    {
                        audio.PlayOneShot(UpR);
                    }
                    else if (gameObject.tag == "EnL" && left == 3)
                    {
                        audio.PlayOneShot(DownFR);
                        
                    }
                
                    yield return new WaitForSeconds(2);


                    if (gameObject.tag == "EnR" && right == 0)
                    {
                        
                        audio.PlayOneShot(UpFL);
                    }
                    else if (gameObject.tag == "EnR" && right == 1)
                    {
                        
                        audio.PlayOneShot(DownL);
                    }
                    else if (gameObject.tag == "EnR" && right == 2)
                    {
                        
                        audio.PlayOneShot(UpL);
                    }
                    else if (gameObject.tag == "EnR" && right == 3)
                    {
                        
                        audio.PlayOneShot(DownFL);
                    }

                }
            }

    }
    //sss

    IEnumerator SequentialSoundL()
        {
            audio.PlayOneShot(sonar);
            Debug.Log("HELLOOOOOOOO");
            yield return new WaitForSeconds(1f);
            
            EnemyRight.GetComponent<AudioSource>().PlayOneShot(sonar);
            
        }

        
        IEnumerator SequentialSoundR()
        {
            audio.PlayOneShot(sonar);
            Debug.Log("HEOO");
            yield return new WaitForSeconds(1f);
            
            EnemyLeft.GetComponent<AudioSource>().PlayOneShot(sonar);

        }

        IEnumerator SequentialSpeechL(AudioClip speech)
        {
            audio.pitch = 1f;
            EnemyRight.GetComponent<AudioSource>().pitch = 1f;
            audio.PlayOneShot(speech);
            
        
        if (EnemyRight.GetComponent<ArmMovement>().right == 0)
        {
            yield return new WaitForSeconds(1f);
            EnemyRight.GetComponent<AudioSource>().PlayOneShot(UpFL);
        }
        else if (EnemyRight.GetComponent<ArmMovement>().right == 1)
        {
            yield return new WaitForSeconds(1f);
            EnemyRight.GetComponent<AudioSource>().PlayOneShot(DownL);
        }
        else if (EnemyRight.GetComponent<ArmMovement>().right == 2)
        {
            yield return new WaitForSeconds(1f);
            EnemyRight.GetComponent<AudioSource>().PlayOneShot(UpL);
        }
        else if (EnemyRight.GetComponent<ArmMovement>().right == 3)
        {
            yield return new WaitForSeconds(1f);
            EnemyRight.GetComponent<AudioSource>().PlayOneShot(DownFL);
        }
        
    }
        IEnumerator SequentialSpeechR(AudioClip speech)
        {
            audio.pitch = 1f;
            EnemyLeft.GetComponent<AudioSource>().pitch = 1f;
            audio.PlayOneShot(speech);
           
            
            if (EnemyLeft.GetComponent<ArmMovement>().left == 0)
            {
                yield return new WaitForSeconds(1f);
                EnemyLeft.GetComponent<AudioSource>().PlayOneShot(UpFR);
            }
            else if (EnemyLeft.GetComponent<ArmMovement>().left == 1)
            {
                yield return new WaitForSeconds(1f);
                EnemyLeft.GetComponent<AudioSource>().PlayOneShot(DownR);
            }
            else if (EnemyLeft.GetComponent<ArmMovement>().left == 2)
            {
                yield return new WaitForSeconds(1f);
                EnemyLeft.GetComponent<AudioSource>().PlayOneShot(UpR);
            }
            else if (EnemyLeft.GetComponent<ArmMovement>().left == 3)
            {
                yield return new WaitForSeconds(1f);
                EnemyLeft.GetComponent<AudioSource>().PlayOneShot(DownFR);
            }
            
        }
        
        IEnumerator Continuous()
        {
            if (ButtonHandler.periodic == 2)
            {
                audio.volume = 0.04f;
                if (ButtonHandler.sequential == 1)
                {
                    if (!audio.isPlaying)
                    {
                        audio.clip = beep;
                        audio.loop = true;
                        audio.Play();
                    }

                }
                else if (ButtonHandler.sequential == 0)
                {
                    audio.Stop();
                    if (gameObject.tag == "EnL")
                    {
                        EnemyRight.GetComponent<AudioSource>().Stop();
                        audio.PlayOneShot(beep);

                    }
                    else if (gameObject.tag == "EnR")
                    {
                        yield return new WaitForSeconds(1.3f);
                        EnemyLeft.GetComponent<AudioSource>().Stop();
                        audio.PlayOneShot(beep);
                    }
                }
                
            }
            


    }
    IEnumerator ContiSeqR()
    {
        audio.PlayOneShot(beep);
        while (audio.isPlaying)
        {
            yield return null;
        }
        audio.Stop();
    }
    IEnumerator ContiSeqL()
    {
        audio.PlayOneShot(beep);
        while (audio.isPlaying)
        {
            yield return null;
        }
        audio.Stop();
    }

    
    public int UniqueRandomInt(int min, int max)
    {
        
        int rand = Random.Range(min, max);
        
        
        if (gameObject.tag == "EnR")
        {
            while (rand == right)
            {
                rand = Random.Range(min, max);
                right = rand;
            }
        }
        else if (gameObject.tag == "EnL")
        {
            while (rand == left)
            {
                rand = Random.Range(min, max);
                left = rand;
            }
        }
            return rand;
    }

}
    

