using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDead : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public int health;
    public float speed;
    public int damage;
    private float stopTime;
    public float startStopTime;
    public float normalSpeed;
    private Health player;
    
    [SerializeField] private AudioSource damageSound;


    //public GameObject sound;


    private void Start()
    {
        
        player = FindObjectOfType<Health>();
        normalSpeed = speed;

    }


    private void Update()
    {
        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            
         
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);


    }

    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;
        health -= damage;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {


            // Instantiate(sound, transform.position, Quaternion.identity);
            if (timeBtwAttack <= 0)
            {
                //anim.SetTrigger("enemyAttack");
                player.health -= damage;
                damageSound.Play();

            }
            else
            {
                timeBtwAttack = Time.deltaTime;
            }

        }
    }
   
}
