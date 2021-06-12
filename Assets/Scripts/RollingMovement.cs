using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingMovement : MonoBehaviour
{
    Vector2 userInput;
    Rigidbody2D rb;

    public float movSpeed = 0.15f;
    public float jumpStr = 10f;

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
        // Horizontal Movement
        userInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.AddRelativeTour
        // Debug.DrawRay(transform.position, userInput*2, Color.red);
    }
}

