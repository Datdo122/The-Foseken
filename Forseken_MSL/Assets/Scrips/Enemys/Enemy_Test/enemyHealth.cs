using UnityEngine;

public class enemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] statusEnemy statusEnemy;
    public float currentHealth;
    [SerializeField] Animator aniEnemy;
    [SerializeField] Rigidbody2D rbEnemy;
    public bool isDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = statusEnemy.healthEnemy;
    }

    // Update is called once per frame
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
            aniEnemy.SetBool("isHitting", true);
        }
    }

    private void endHit()
    {
        aniEnemy.SetBool("isHitting", false);
    }

    private void Die()
    {
        isDead = true;
        aniEnemy.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        rbEnemy.linearVelocity = Vector2.zero;
        rbEnemy.bodyType = RigidbodyType2D.Static;
    }
    private void endDead()
    {
        Destroy(gameObject);
    }
}
