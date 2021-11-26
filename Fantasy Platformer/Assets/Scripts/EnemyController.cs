using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D physic;
    private Animator animator;
    public Transform player;
    public float speed;
    public float agroDistance;
    private bool walking;

    void Start()
    {
        physic = GetComponent<Rigidbody2D>(); 
    }
   
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if(distToPlayer < agroDistance)
        {
            StartHunting();
        }
        else
        {
            StopHunting();
        }
    }
    void StartHunting()
    {   
        if (player.position.x < transform.position.x)
        {
            physic.velocity = new Vector2(-speed, 0);
        }
        else if(player.position.x > transform.position.x) 
        {
            physic.velocity = new Vector2(speed, 0);
        }
        animator.SetBool("GOGO", walking);
    }
    void StopHunting()
    {
        physic.velocity = new Vector2(0, 0);
    }
}
