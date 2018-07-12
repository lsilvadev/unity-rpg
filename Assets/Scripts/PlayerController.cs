using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalMoveModifier;
    private bool playerMoving;
    public Vector2 lastPosition;
    private Animator animator;
    private new Rigidbody2D rigidbody;
    
    private static bool playerExists;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public string startPoint;

	void Start () 
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

	}
	
	void Update () 
    {
        Move();
	}

    void Move()
    {                
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        playerMoving = false;

        if (!attacking)
        {
            // horizontal movement, left or right
            if (horizontal > 0.5f || horizontal < -0.5f)
            {
                //transform.Translate(new Vector3(horizontal * Time.deltaTime * moveSpeed, 0f, 0f));
                rigidbody.velocity = new Vector2(horizontal * currentMoveSpeed, rigidbody.velocity.y);
                playerMoving = true;
                lastPosition = new Vector2(horizontal, 0);
            }

            // vertical movement, up or down
            if (vertical > 0.5f || vertical < -0.5f)
            {
                //transform.Translate(new Vector3(0f, vertical * Time.deltaTime * moveSpeed, 0f));
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, vertical * currentMoveSpeed);
                playerMoving = true;
                lastPosition = new Vector2(0, vertical);
            }

            if (horizontal < 0.5f && horizontal > -0.5f)
            {
                rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
            }

            if (vertical < 0.5f && vertical > -0.5f)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                rigidbody.velocity = Vector2.zero;
                animator.SetBool("Attack", true);
            }

            if (Mathf.Abs(horizontal) > 0.5f && Mathf.Abs(vertical) > 0.5f)
            {
                currentMoveSpeed = moveSpeed * diagonalMoveModifier;
            }
            else
            {
                currentMoveSpeed = moveSpeed;
            }
        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }
        else
        {
            attacking = false;
            animator.SetBool("Attack", false);
        }
                
        animator.SetFloat("MoveY", vertical);
        animator.SetFloat("MoveX", horizontal);
        animator.SetBool("PlayerMoving", playerMoving);
        animator.SetFloat("LastPositionX", lastPosition.x);
        animator.SetFloat("LastPositionY", lastPosition.y);
    }
}
