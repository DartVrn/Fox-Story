using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    public Animator omg;
    [SerializeField] private AudioSource missAttack;
    [SerializeField] private AudioSource attackMob;

    private void Update()
    {
        if(timeBtwAttack <= 0)
        {
            //if(Input.GetMouseButton(0))
            //{
              
                //omg.SetTrigger("isAttack");
              
            //}
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        if (enemies.Length == 0)
            missAttack.Play();
        else
            attackMob.Play();

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().TakeDamage(damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
