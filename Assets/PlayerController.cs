using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rbCharacter;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("Running",true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("Running",true);
        }

        if (Input.GetKeyDown(KeyCode.Space)) /*se esta presionando una tecla */
        {
            anim.SetTrigger("Jump");
        }
        

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0.0f,0.0f,0.02f);
            anim.SetBool("Running",true);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            this.transform.Translate(0.0f,0.0f,0.02f);
            anim.SetBool("Running",false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(0.0f,-0.1f,0.0f);
            anim.SetBool("Running",true);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(0.0f,0.1f,0.0f);
            anim.SetBool("Running",true);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("Running",false);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("Running",false);
        }

    }
}