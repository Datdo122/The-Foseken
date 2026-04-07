using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class triggerEnemy : MonoBehaviour
{
    [SerializeField] private statusEnemy statusEnemy; 
    [SerializeField] public GameObject rayCast; 

    public LayerMask rayCastLayerMask;
    public float rayCastLength = 5f;
    public float attackDistance;
    public float timerAttack;

    private RaycastHit2D rayCastHit;
    private GameObject targetPlayer;
    [SerializeField] private Animator animatorEnemy;
    private float distance;
    private bool attackPlayer;
    private bool inRange;
    private bool canAttack;
    private float intTimerAttack;


    void Awake()
    {
        intTimerAttack = timerAttack;

    }
    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            rayCastHit = Physics2D.Raycast(rayCast.transform.position, Vector2.left, rayCastLength, rayCastLayerMask);
            RaycastDebugger();
        }    
        if (rayCastHit.collider != null)
        {
            EnemyLogic();
        }
        else if (rayCastHit.collider == null)
        {
            inRange = true;
        }

        if (inRange == false)
        {
            animatorEnemy.SetBool("isWalk", false);
            StopAttack();
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Players"))
        {
            targetPlayer = collision.gameObject;
            inRange = true;
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, targetPlayer.transform.position);
        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && canAttack == false)
        {
            Attack();
        }

        if (canAttack)
        {
            animatorEnemy.SetBool("isAttack", false);
        }
    }
    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.transform.position, Vector2.left * rayCastLength, Color.red);
        }
        else if (attackDistance >= distance)
        {
            Debug.DrawRay(rayCast.transform.position, Vector2.left * rayCastLength, Color.green);
        }
    }

    void Move()
    {
        animatorEnemy.SetBool("isWalk", true);
        if (!animatorEnemy.GetCurrentAnimatorStateInfo(0).IsName("Skel_Attack"))
        {
            Vector2 targetPosition = new Vector2(targetPlayer.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, statusEnemy.speedEnemy * Time.deltaTime);
        }
    }

    void Attack()
    {
        timerAttack -= intTimerAttack;
        attackPlayer = true;

        animatorEnemy.SetBool("isWalk", false);
        animatorEnemy.SetBool("isAttack", true);
    }

    void StopAttack()
    {
        canAttack = false;
        attackPlayer = false;
        animatorEnemy.SetBool("isAttack", false);
        
    }
}
