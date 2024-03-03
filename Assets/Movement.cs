using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;
    private Animator animator;
    private Rigidbody rb;
   public Joystick  joystick ;
   public void Jump (){
        rb.AddForce(new Vector3(0,10,0), ForceMode.Impulse);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
     
    }

    void Update()
    {
        float verticalInput = joystick.Vertical;
        float horizontalInput = joystick.Horizontal;

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.3f);
            animator.SetBool("move", true); // Set the "Move" parameter to true when there is movement
        }
        else
        {
            animator.SetBool("move", false); // Set the "Move" parameter to false when there is no movement
        }
    }

    
}
