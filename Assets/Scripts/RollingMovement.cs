using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MilkShake;

public class RollingMovement : MonoBehaviour
{
    Vector2 userInput;
    Rigidbody2D rb;

    public bool isGrounded;
    public float currentRotation;
    public float rollPower;
    public float maxSpeed;
    public float jumpStr;

    //public Stack<Rigidbody2D> Limbs = new Stack<Rigidbody2D>();

    public Shaker MyShaker;
    public ShakePreset ShakePreset;

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
        // Horizontal Movement
        userInput.Set(Input.GetAxis("Horizontal")*-1, Input.GetAxis("Vertical"));
        // Debug.DrawRay(transform.position, userInput*10f, Color.red);


            if (currentRotation < maxSpeed)
            {
                rb.AddTorque(userInput.x*rollPower, ForceMode2D.Force);
            }
        if (isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                rb.AddForce(new Vector2(0, jumpStr));
                MyShaker.Shake(ShakePreset);
            }
        }
    }

    void AttachNewLimb(Collision2D collision)
    {
        //print(collision.collider.attachedRigidbody);
        Rigidbody2D newRB = collision.collider.attachedRigidbody;

        //Limbs.Push(newRB);
        //print(Limbs);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Ground")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "potLimb")
        {
            AttachNewLimb(collision);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.collider.name == "Ground")
        {
            isGrounded = false;
        }
    }
}

