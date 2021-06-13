using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

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


}

