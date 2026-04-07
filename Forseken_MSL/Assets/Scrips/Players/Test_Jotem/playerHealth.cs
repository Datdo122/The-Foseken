using Unity.Multiplayer.PlayMode;
using UnityEngine;

public class playerHealth : MonoBehaviour, IDamageable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private statusPlayer statusPlayer;
    public float CurrentPlayerHealth;
    [SerializeField] private Rigidbody2D rbPlayer;
    [SerializeField] private Animator aniPlayer;
    public bool isDead = false;

    void Start()
    {
        CurrentPlayerHealth = statusPlayer.healthPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        CurrentPlayerHealth -= damage;
        if (CurrentPlayerHealth <= 0)
        {
            Die();
        }
        else
        {
            aniPlayer.SetBool("isHitting", true);
        }
        Debug.Log("Player took damage! Current health: " + CurrentPlayerHealth);
    }   

    private void endHit()
    {
        aniPlayer.SetBool("isHitting", false);
    }

    private void Die()
    {
        isDead = true;
        aniPlayer.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        rbPlayer.linearVelocity = Vector2.zero;
        rbPlayer.bodyType = RigidbodyType2D.Static;
    }

    private void endDead()
    {
        Destroy(gameObject);
    }
}
