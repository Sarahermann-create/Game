using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rbCharacter;

    [Header("Ajustes de Movimiento")]
    public float moveSpeed = 5f;       
    public float rotationSpeed = 150f; 
    public float jumpForce = 5f;       

    void Start()
    {
        if (rbCharacter == null)
        {
            rbCharacter = GetComponent<Rigidbody>();
        }

        if (rbCharacter != null)
        {
            rbCharacter.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            if (rbCharacter != null)
            {
                rbCharacter.linearVelocity = new Vector3(rbCharacter.linearVelocity.x, 0f, rbCharacter.linearVelocity.z);
                rbCharacter.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        bool isRunning = false;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0.0f, 0.0f, moveSpeed * Time.deltaTime);
            isRunning = true;
        }

     
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(0.0f, -rotationSpeed * Time.deltaTime, 0.0f);
           
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);

        }

    
        anim.SetBool("Running", isRunning);
    }
}