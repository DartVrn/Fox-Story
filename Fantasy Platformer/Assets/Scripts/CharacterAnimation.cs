using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.RightArrow)))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D)))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isJamped", true);
        }
        else
        {
            anim.SetBool("isJamped", false);
        }

       // if (Input.GetKey(KeyCode.Mouse0))
        //{
         //   anim.SetTrigger("isAttack");
        //}
        //else
       // {
           // anim.SetTrigger("isAttack");
        //}


        //if (Input.GetKey(KeyCode.Space))
        // {
        //anim.SetTrigger("jump");
        //}

    }
}