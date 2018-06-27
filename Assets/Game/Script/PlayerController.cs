using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private bool isWalk;
    private Vector2 stop;
    private Animator animator;

	void Start () 
    {
        animator = GetComponent<Animator>();
	}
	
	void Update () 
    {
        Moviment();
	}

    void Moviment()
    {                
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        isWalk = false;

        if (horizontal!=0)
        {
            transform.Translate(horizontal * Time.deltaTime * speed, 0, 0);
            isWalk = true;
            stop = new Vector2(horizontal, 0);
        }
        if (vertical!=0)
        {
            transform.Translate(0, vertical * Time.deltaTime * speed, 0);
            isWalk = true;
            stop = new Vector2(0, vertical);
        }

        animator.SetFloat("PositionY", vertical);
        animator.SetFloat("PositionX", horizontal);        
        animator.SetBool("Walk", isWalk);
        animator.SetFloat("StopX", stop.x);
        animator.SetFloat("StopY", stop.y);
    }
}
