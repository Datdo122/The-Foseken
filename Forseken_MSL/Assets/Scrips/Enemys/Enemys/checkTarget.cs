using UnityEngine;

public class checkTarget : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private platrollEnemyAI platrollEnemyAI;
    private chaseAttackAI chaseAttackAI;
    void Start()
    {
        platrollEnemyAI = GetComponentInParent<platrollEnemyAI>();
        chaseAttackAI = GetComponentInParent<chaseAttackAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            platrollEnemyAI.enabled = false;
            chaseAttackAI.enabled = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            platrollEnemyAI.enabled = true;
            chaseAttackAI.enabled = false;
        }
    }
}
