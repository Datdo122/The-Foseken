using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class movementPlayer : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField]private float speed = 5.0f;
    [SerializeField] private float jumpForce = 10.0f;
    private bool isfacingRight = true;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject attackCheck;
    
    private float style = 0;
    private bool aiming1 = false;

    [SerializeField] private Transform targetAiming1;
    [SerializeField] GameObject bothSpawnPrefab;

    private Vector3 savePos;
    public bool isAttacking = false;
    private bool isCasting = false;
    void Start()
    {
        attackCheck.SetActive(false);
    }
    void Update()
    {
        if (!isCasting)
        {
            Movement();
            Aiming();
        }
        Flip();
        Jump();
        StylePlayer();
        Attack();  
    }

    private void StylePlayer()
    {
        // Style
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (style == 0)
            {
                style = 1;
                anim.SetFloat("isStylish", 1.0f);
            }
            else
            {
                style = 0;
                anim.SetFloat("isStylish", 0.0f);
            }
        }
    }

    private void Movement()
    {
        //movement
        horizontalInput = Input.GetAxis("Horizontal"); 
        
        // Animations
        if (horizontalInput != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
    
    private void Attack()
    {
        // Attack
        if (Input.GetMouseButtonDown(0))
        {
            // isAttacking = true;
            anim.SetBool("isAttacking", true);
            
        }
    }
    private void SetAttacking()
    {
        isAttacking = true;
        attackCheck.SetActive(true);
    }
    private void EndAttack()
    {
        isAttacking = false;
        anim.SetBool("isAttacking", false);
        attackCheck.SetActive(false);
    }
    private void Jump()
    {
        // Jumping
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

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
        anim.SetFloat("xVelocity", Math.Abs(rb.linearVelocity.x));
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

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
    private void Aiming()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            aiming1 = !aiming1;
            targetAiming1.gameObject.SetActive(aiming1);
        }
        if (aiming1)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            targetAiming1.transform.position = mousePosition;

            if (Input.GetMouseButtonDown(1))
            {
                ExecuteAction(mousePosition);
            }
        }
    }

    private void ExecuteAction(Vector3 position)
    {
        
        savePos = position;
        isCasting = true;
        speed = 0f;
        anim.SetBool("isAiming", true);
    
        aiming1 = false;
        targetAiming1.gameObject.SetActive(false);
    }

    private void SpawnBoth()
    {
        Vector3 spawnPos = new Vector3(savePos.x, savePos.y, 0f);
        Instantiate(bothSpawnPrefab, spawnPos, Quaternion.identity);
    }
    private void EndAiming()
    {
        isCasting = false;
        anim.SetBool("isAiming", false);
        speed = 5f;
    }
}
