using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    //SerializeField] private AudioSource damageSound;
    private Animator anim;
    public float health;
    private PlayerMovement playerMovement;
    private PlayerInput playerInput;
    public GameObject canvasDead;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public float heal;



    private void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
        
        
    }

    private void FixedUpdate()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
         health += Time.deltaTime * heal;
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart; 
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void Update()
    {
        if(health <=0)
        {
            SceneManager.LoadScene(1);
            //canvasDead.SetActive(true);
            anim.SetTrigger("isDie");
            anim.SetBool("isJumped", false);
            Destroy(gameObject, 3);
            Destroy(GetComponent<PlayerMovement>(), 1);
            Destroy(GetComponent<PlayerInput>(), 1);
        }
        

    }
    // public void PlayDamage(float bom)
    //{
    //  health -= bom;
    //if (health <= 0)
    //{ 
    //  Die(); 
    //}

    //}

    //private void Die()
    //{
    //  anim.SetTrigger("isDie");
    //Destroy(GetComponent<Collider2D>(), 2);
    //}


}