using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private bool playerMoving;
    public Vector2 lastMove;
    private Animator animator;
    private new Rigidbody2D rigidbody;
    private static bool playerExists;

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

        if (horizontal > 0.5f || horizontal < -0.5f)
        {
            //transform.Translate(new Vector3(horizontal * Time.deltaTime * moveSpeed, 0f, 0f));
            rigidbody.velocity = new Vector2(horizontal * moveSpeed, rigidbody.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(horizontal, 0);
        }
        
        if (vertical > 0.5f || vertical < -0.5f)
        {
            //transform.Translate(new Vector3(0f, vertical * Time.deltaTime * moveSpeed, 0f));
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, vertical * moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0, vertical);
        }

        if (horizontal < 0.5f && horizontal > -0.5f)
        {
            rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
        }

        if (vertical < 0.5f && vertical > -0.5f)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
        }
        
        animator.SetFloat("MoveY", vertical);
        animator.SetFloat("MoveX", horizontal);
        animator.SetBool("PlayerMoving", playerMoving);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);
    }
}
