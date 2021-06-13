using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
    RollingMovement parentScript;

    void Awake()
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
        parentScript.updateScore();

        Collider2D nextLimb = collision.collider;
        gameObject.AddComponent<FixedJoint2D>();
        FixedJoint2D JointToNext = gameObject.GetComponent<FixedJoint2D>();
        JointToNext.enabled = true;
        JointToNext.connectedBody = nextLimb.attachedRigidbody;
        JointToNext.anchor = collision.GetContact(0).point;
        //JointToNext.connectedAnchor = collision.GetContact(0).point;

        nextLimb.gameObject.tag = "Limb";
        nextLimb.gameObject.GetComponent<Limb>().enabled = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.GetComponent<Limb>().enabled)
        {
            colEnterHandle(collision);
        }
        else { return; }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (gameObject.GetComponent<Limb>().enabled)
        {
            colExitHandle(collision);
        }
        else { return; }
    }


    void colEnterHandle(Collision2D collision)
    {
        if (collision.collider.name == "Ground")
        {
            parentScript.groundConnections++;
        }
        if (collision.gameObject.CompareTag("potLimb"))
        {
            AttachNewLimb(collision);
        }
    }
    void colExitHandle(Collision2D collision)
    {
        if (collision.collider.name == "Ground")
        {
            parentScript.groundConnections--;
        }
    }




    // private void OnDrawGizmos()
    // {
    //     FixedJoint2D J = gameObject.GetComponent<FixedJoint2D>();
    //     if (J)
    //     {
    //         Gizmos.color = Color.blue;
    //         Gizmos.DrawLine(J.anchor, J.connectedAnchor);
    //         Gizmos.DrawWireSphere(J.connectedAnchor, 0.5f);
    //     }
    // }
}
