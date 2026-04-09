using UnityEngine;
using System;
using System.Collections;


public class EnemyHealth : MonoBehaviour, IDamageable
{
    public float currentHealthEnemy;
    [SerializeField] private Animator animEnemy;
    [SerializeField] private Rigidbody2D rbEnemy;
    [SerializeField] private StatusEnemy statusEnemy;
    public bool isDeadEnemy = false;
    void Start()
    {
        currentHealthEnemy = statusEnemy.healthEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TakeDamage(float damage)
    {
        Debug.Log("Enemy took damage! Current health: " + currentHealthEnemy);
        currentHealthEnemy -= damage;
        if (currentHealthEnemy <= 0 && !isDeadEnemy)
        {
            Die();
        }
        else
        {
            animEnemy.SetTrigger("getHit");
        }
    }
    private void Die()
    {
        isDeadEnemy = true;
        animEnemy.SetBool("isDead", true);
        // GetComponent<Collider2D>().enabled = false;
        // rbEnemy.linearVelocity = Vector2.zero;
        // rbEnemy.bodyType = RigidbodyType2D.Static;
    }
    private void endDead()
    {
        Destroy(gameObject);
    }
}
