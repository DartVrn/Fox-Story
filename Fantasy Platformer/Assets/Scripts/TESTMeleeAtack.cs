using UnityEngine;

public class MeleeAtack : MonoBehaviour
{
    private float TimeBtwAttack;
    public Transform AttackPoints;
    public LayerMask DamageableLayerMask;
    public float AttackRange;
    public int Damage;

    private Animator _animator;
    private float _timer;

    private void Start()
    {
        GetReferences();
    }

    private void OnDrawGizmosSelected()
    {

    }

    private void Update()
    {
        Attack();
    }


    private void Attack()
    {
        if (_timer <=0)
        {
          

        }
        else
        {
            _timer -= Time.deltaTime;
        }

    }

    private void GetReferences()
    {
        _animator = GetComponent<Animator>();
    }
}
