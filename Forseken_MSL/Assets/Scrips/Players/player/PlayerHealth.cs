using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private StatusPlayer statusPlayer;
    public float currentHealth;
    [SerializeField] private Animator animPlayer;
    [SerializeField] private Rigidbody2D rbPlayer;

    public bool isDead = false;

     void Start()
    {
        currentHealth = statusPlayer.healthPlayer;
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
        else
        {
            animPlayer.SetTrigger("getHit");
        }
        // Debug.Log("Player took damage! Current health: " + currentHealth);
    }
    private void Die()
    {
        isDead = true;
        animPlayer.SetTrigger("isDead");
        rbPlayer.bodyType = RigidbodyType2D.Static;
        rbPlayer.linearVelocity = Vector2.zero;
    }
    private void endDead()
    {
        Destroy(gameObject);
    }
}
