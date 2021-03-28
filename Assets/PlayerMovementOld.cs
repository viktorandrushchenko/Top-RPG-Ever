using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOld : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private SpriteRenderer spriteRenderer = null;

    private Vector2 velocity;
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        velocity.x = Input.GetAxisRaw("Horizontal");

        if (velocity.x > 0)
            spriteRenderer.flipX = false;
        else if (velocity.x < 0)
            spriteRenderer.flipX = true;

        animator.SetBool("IsRun", velocity.sqrMagnitude > .1f);

        rb.position += velocity * speed * Time.deltaTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (Input.GetMouseButtonDown(0))
            animator.SetTrigger("Punch");
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
