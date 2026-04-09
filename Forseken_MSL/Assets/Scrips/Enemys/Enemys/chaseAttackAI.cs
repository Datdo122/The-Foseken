using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.AI;

public class chaseAttackAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Animator anmEnemy;
    [SerializeField] private StatusEnemy statusEnemy;
    [SerializeField] private GameObject hitBoxAttack;
    private Vector3 originalScale;
    private float checkDistance;
    private float distanceRadius;
    [SerializeField] private CircleCollider2D attackRangeCollider;
    private bool canChasePlayer = false;
    private float SpeedEnemy;
    public bool isPlayerRange;
    void Start()
    {
        distanceRadius = attackRangeCollider.radius * math.abs(transform.localScale.x);
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (canChasePlayer && playerTransform != null)
        {
            isPlayerRange = distanceToPlayer <= distanceRadius;
            ChasePlayer();
            FlipSprite();
        }
        if (distanceToPlayer <= distanceRadius)
        {
            isPlayerRange = true;
            ChasePlayer();
        }
        else
        {
            navMeshAgent.ResetPath();
        }
        checkDistance = playerTransform.position.x - transform.position.x;
        // Debug.Log("Distance to Player: " + checkDistance);
        wakeEnemy();
        AttackEnemy();
        
    }

    void wakeEnemy()
    {
        SpeedEnemy = navMeshAgent.velocity.magnitude;
        anmEnemy.SetFloat("xVelocity", SpeedEnemy);

    }

    void DamePlayer()
    {
        if (Math.Abs(checkDistance) < 2f)
        {
            IDamageable damageable = playerTransform.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(statusEnemy.damageEnemy);
            }
            // Debug.Log(statusEnemy.damageEnemy);
        }
    }

    void AttackEnemy()
    {
        if (Math.Abs(checkDistance) < 2f)
        {
            anmEnemy.SetBool("isAttack", true);
        }
        else if (Math.Abs(checkDistance) >= 2f)
        {
            anmEnemy.SetBool("isAttack", false);
        }
    }
    private void enabledHitBoxAttack()
    {
        hitBoxAttack.SetActive(true);
    }
    private void disabledHitBoxAttack()
    {
        hitBoxAttack.SetActive(false);
    }


    // void DamePlayer()
    // {
    //     IDamageable damageable = playerTransform.GetComponent<IDamageable>();
    //     if (damageable != null)
    //     {
    //         damageable.TakeDamage(statusEnemy.damageEnemy);
    //     }
    // }

    void ChasePlayer()
    {
        navMeshAgent.SetDestination(playerTransform.position);
    }
    void FlipSprite()
    {
        if (checkDistance < 0 && canChasePlayer == true)
        {
            transform.localScale = originalScale;
        }
        else if (checkDistance > 0 && canChasePlayer == true)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTransform = collision.gameObject.transform;
            canChasePlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canChasePlayer = false;
            navMeshAgent.ResetPath();
        }
    }
}
