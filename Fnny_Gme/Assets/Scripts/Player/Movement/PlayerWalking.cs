using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalking : MonoBehaviour
{

    float Horizontal;
    public float jumpPower;
    public float dashPower;
    public bool isFacingRight = true;
    public float Speed;
    public bool canMove;
    public bool sword_out;
    public bool canAttack;
    public bool canDash;
    public bool isDashing;
    public float dashTime;
    public float DashCooldown;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Animator animator;

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetMouseButtonDown(0) && canAttack == true)
        {
            StartCoroutine(OnAttack());
        }
        if (canMove == false)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
        {
            StartCoroutine(Dash());
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        Turn();
        


    }
    void FixedUpdate()
    {
        if (canMove == false || isDashing == true)
        {
            return;
        }
        rb.velocity = new Vector2(Horizontal * Speed, rb.velocity.y);
        //animator.SetFloat("Speed", Mathf.Abs(Horizontal));
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Turn()
    {
        if (isFacingRight && Horizontal < 0f || !isFacingRight && Horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 LocalScale = transform.localScale;
            LocalScale.x *= -1f;
            transform.localScale = LocalScale;
        }
    }
    private void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);  
        }
    }
    private IEnumerator OnAttack()
    {
        canMove = false;
        canAttack = false;
        animator.SetBool("Attack_1", true);
        //animator.SetFloat("Speed", 0);
        yield return new WaitForSeconds(1/6f);
        animator.SetBool("Attack_1", false);
        sword_out = true;
        yield return new WaitForSeconds(1/12f);
        sword_out = false;
        yield return new WaitForSeconds(1/20f);
        canMove = true;
        canAttack = true;
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(Horizontal * dashPower, rb.velocity.y);
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        yield return new WaitForSeconds(DashCooldown);
        canDash = true;
    }


    
}
