using UnityEngine;

public class HitAttackPlayer : MonoBehaviour
{
    [SerializeField] StatusPlayer statusPlayer;
    [SerializeField] PlayerController playerController;
    private float dameAttack;
    private bool Attacking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dameAttack = statusPlayer.damageAttackPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        Attacking = playerController.isAttacking;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Attacking == true)
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(dameAttack);
            }
            // Debug.Log(dameAttack);
        }
    }
}
