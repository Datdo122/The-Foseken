using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent AgentEnemy;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Animator animEnemy;
    [SerializeField] private statusEnemy statusEnemy;
    private Vector3 originalScale;
    private float checkDistance;
    private float distanceRadius;
    [SerializeField] private CircleCollider2D detectionRadius;
    private bool canChasePlayer = false;
    float currentspeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        distanceRadius = detectionRadius.radius * math.abs(transform.localScale.x);
        AgentEnemy.updateRotation = false;
        AgentEnemy.updateUpAxis = false;
        originalScale = transform.localScale;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (canChasePlayer && playerTransform != null)
        {
            ChasePlayer();
            FlipSprite();
        }
        if (distanceToPlayer < distanceRadius)
        {
            ChasePlayer();
        }
        else
        {
            AgentEnemy.ResetPath();
        }
        // Debug.Log("Distance to player: " + distanceToPlayer);
        checkDistance = playerTransform.position.x - transform.position.x;
        Wake();
        Attack();
    }

    void Wake()
    {
        currentspeed = AgentEnemy.velocity.magnitude;
        animEnemy.SetFloat("xVelocity", currentspeed);
    }

    void Attack()
    {
        if (checkDistance < 2.0f)
        {
            animEnemy.SetBool("isAttacking", true);
        }
        else
        {
            animEnemy.SetBool("isAttacking", false);
        }
        Debug.Log("Distance to player: " + checkDistance);
    }

    void DamePlayer()
    {
        if (checkDistance < 2.0f)
        {
            IDamageable damageable = playerTransform.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(statusEnemy.damageAttackEnemy); // Adjust the damage value as needed
            }
            // Debug.Log("Enemy attacked the player!");
        }

    }

    void ChasePlayer()
    {
        AgentEnemy.SetDestination(playerTransform.position);
    }
    void FlipSprite()
    {
        if (checkDistance > 0 && canChasePlayer == true)
        {
            transform.localScale = originalScale;
        }
        else if (checkDistance < 0 && canChasePlayer == true)
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
            // Debug.Log("Player detected, chasing!");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AgentEnemy.ResetPath();
            canChasePlayer = false;
        }
    }
}
