using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using MilkShake;

public class RollingMovement : MonoBehaviour
{
    Vector2 userInput;
    Rigidbody2D rb;

    public int groundConnections;
    public float currentRotation;
    public float rollPower;
    public float maxSpeed;
    public float jumpStr;

    public Shaker MyShaker;
    public ShakePreset ShakePreset;

    //public Stack<Rigidbody2D> Limbs = new Stack<Rigidbody2D>();

    public int childLimbCounter = 0;
    public Text ScoreText;
    public AudioSource audioData;
    public bool playingSound = false;
    public float offGroundDelay = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (groundConnections >= 1 && !playingSound)
        {
            playingSound = true;
            offGroundDelay = 0;
            audioData.Play(0);
        }
        if (groundConnections <= 0)
        {
            offGroundDelay += Time.deltaTime;
            print(offGroundDelay);
        }
        if (offGroundDelay > 0.2)
        {
            audioData.Stop();
        }
    }   
        
 
    void FixedUpdate()
    {
        currentRotation = (Mathf.Abs(rb.angularVelocity));
        userInput.Set(Input.GetAxis("Horizontal")*-1, Input.GetAxis("Vertical"));
        // Debug.DrawRay(transform.position, Vector2.up*10f, Color.red);


        if (currentRotation < maxSpeed)
        {
            rb.AddTorque(userInput.x*rollPower, ForceMode2D.Force);
        }
        if (groundConnections>0)
        {
            if (Input.GetButton("Jump"))
            {
                rb.AddForce(new Vector2(0, jumpStr*groundConnections));
                MyShaker.Shake(ShakePreset);
            }
        }
    }

    public void updateScore()
    {
        childLimbCounter++;
        ScoreText.text = "Score: " + childLimbCounter.ToString();
    }

}

