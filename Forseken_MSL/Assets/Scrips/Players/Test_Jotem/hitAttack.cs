using System;
using UnityEditor.Search;
using UnityEngine;

public class hitAttack : MonoBehaviour
{
    [SerializeField] statusPlayer statusPlayer;
    [SerializeField] Animator aniPlayer;
    [SerializeField] movementPlayer movementPlayer;
    private bool Attacking = false;
    private float damage;
    void Start()
    {
        damage = statusPlayer.damageAttackPlayer;
    }
    void Update()
    {
        Attacking = movementPlayer.isAttacking;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Player hit an enemy!");
        if (collision.gameObject.CompareTag("Enemy") && Attacking == true)
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
        }
    }
}
