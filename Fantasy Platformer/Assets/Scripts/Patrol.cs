using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    [SerializeField] private float speed;

    private Animator animator;
    private int currentIndex;
    private Vector2 currentPoint;
    private bool walking;
    private bool isDead;
    public int health;
    private Enemy enemy;



    void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
        health = enemy.health;
        animator = GetComponent<Animator>();
        currentPoint = points[0].position;

        ChooseDirection();

        walking = true;
    }

   
    void Update()
    {
        if (enemy.health <= 0)
        {
            return;
        }
        Walk();
    }

   

    private void Walk()
    {
        animator.SetBool("Walk", walking);
        if(walking)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, currentPoint, step);
            if (Vector3.Distance(transform.position, currentPoint) < 0.2f)
            {
                StartCoroutine(Idle());
            }
        }
    }
    private IEnumerator Idle()
    {
        walking = false;
        animator.SetTrigger("Idle");
        ChooseNextPoint();

        yield return new WaitForSeconds(1);
        walking = true;
    }

    private void ChooseNextPoint()
    {
        currentIndex = ++currentIndex < points.Count ? currentIndex : 0;
        currentPoint = points[currentIndex].position;

        ChooseDirection();
    }

    private void ChooseDirection()
    {
        GetComponent<SpriteRenderer>().flipX = currentPoint.x > transform.position.x;
    }
}
