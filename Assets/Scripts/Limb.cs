using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
    RollingMovement parentScript;
    // Start is called before the first frame update
    void Start()
    {
        parentScript = GameObject.Find("Player").GetComponent<RollingMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool groundCheck(Collision2D collision)
    {
        return true;

    }
    void AttachNewLimb(Collision2D collision)
    {
        parentScript.childLimbCounter++;

        Collider2D nextLimb = collision.collider;
        gameObject.AddComponent<FixedJoint2D>();
        gameObject.GetComponent<FixedJoint2D>().connectedBody = nextLimb.attachedRigidbody;
        nextLimb.gameObject.tag = "Limb";
        nextLimb.gameObject.GetComponent<Limb>().enabled = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Ground")
        {
            parentScript.groundConnections =+ 1;
        }
        if (collision.gameObject.CompareTag("potLimb"))
        {
            AttachNewLimb(collision);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.collider.name == "Ground")
        {
            parentScript.groundConnections = -1;
        }
    }
}
