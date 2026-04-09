using System;
using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    
    [SerializeField] StatusPlayer statusPlayer;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject attackCheck;
    [SerializeField] private GameObject hitboxPlayer;

    public bool isAttacking = false;

    private float speedPlayer;
    private float jumpForce;
    private bool isCasting = false;
    private bool isfacingRight = true;
    private bool isRolling = false;

    //combo
    private int comboStep = 0;
    private float lastClickTime;
    private float comboDelay = 1f;

    void Start()
    {
        speedPlayer = statusPlayer.speedPlayer;   
        jumpForce = statusPlayer.jumpForcePlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCasting == false)
        {
            movementPlayer();
            Flip();
        }
        jumpPlayer();
        attackPlayer();
        jumpAttack();

        if (Time.time - lastClickTime > comboDelay)
        {
            resetCombo();
        }

        rollPlayer();
    }

    //di chuyển nhân vật
    private void movementPlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
    //lật nhân vật
    private void Flip()
    {
        if (isfacingRight && horizontalInput < 0 || !isfacingRight && horizontalInput > 0)
        {
            isfacingRight = !isfacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    //nhảy
    private void jumpPlayer()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            anim.SetBool("isJumping", true);
        }
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            anim.SetBool("isJumping", true);
        }

        //animations
        anim.SetBool("isJumping", !IsGrounded());
    }
    
    //cập nhật vật lý
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * speedPlayer, rb.linearVelocity.y);
        anim.SetFloat("xVelocity", Math.Abs(rb.linearVelocity.x));
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    //kiểm tra xem nhân vật có chạm đất hay không
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //tấn công
    private void attackPlayer()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded())
        {
            // Debug.Log(comboStep);
            if (comboStep == 0)
            {
                Attack_base();
                comboStep ++;
            }
            else if (comboStep == 1)
            {
                Combo_1();
                comboStep ++;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && IsGrounded())
        {
            if (comboStep == 2)
            {
                Combo_E();
            }
        }
    }
    
    private void jumpAttack()
    {
        if (Input.GetMouseButtonDown(0) && !IsGrounded())
        {
            // isAttacking = true;
            isCasting = true;
            anim.SetBool("isAttackJump", true);
        }
    }
    
    private void setAttack()
    {
        isAttacking = true;
        attackCheck.SetActive(true);
    }
    private void stopHitAttack()
    {
        isAttacking = false;
        isCasting = false;
        anim.SetBool("isAttacking", false);
        attackCheck.SetActive(false);
    }
    private void stopHitJumpAttack()
    {
        isAttacking = false;
        isCasting = false;
        attackCheck.SetActive(false);
        anim.SetBool("isAttackJump", false);
    }

    //khóa và mở khóa di chuyển
    private void lockMovement()
    {
        speedPlayer = 0;
        jumpForce = 0;
    }

    private void unlockMovement()
    {
        speedPlayer = statusPlayer.speedPlayer;
        jumpForce = statusPlayer.jumpForcePlayer;        
    }

    //combo
    private void resetCombo()
    {
        comboStep = 0;
        anim.SetInteger("ComboCount", comboStep);
    }
    private void Attack_base()
    {
        // isAttacking = true;
        isCasting = true;
        anim.SetBool("isAttacking", true);
        lastClickTime = Time.time;
    }
    private void Combo_1()
    {
        anim.SetInteger("ComboCount", comboStep);
        lastClickTime = Time.time + 0.25f;
    }
    private void Combo_E()
    {
        anim.SetInteger("ComboCount", comboStep);
        lastClickTime = Time.time;
    }
    
    //lăn
    private void rollPlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded() && !isRolling)
        {
            StartCoroutine(RollRoutine());
        }
    }

    private IEnumerator RollRoutine()
    {
        isRolling = true;
        anim.SetTrigger("isRolling");

        float rollDirection = transform.localScale.x > 0 ? 1 : -1;   

        rb.linearVelocity = new Vector2(rollDirection * statusPlayer.rollForcePlayer, rb.linearVelocity.y);
        hitboxPlayer.SetActive(false); // Vô hiệu hóa hitbox trong khi lăn

        yield return new WaitForSeconds(statusPlayer.rollDurationPlayer);

        isRolling = false;
        hitboxPlayer.SetActive(true); // Kích hoạt hitbox sau khi lăn xong
    }
}