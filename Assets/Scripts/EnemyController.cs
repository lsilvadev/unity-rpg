using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {

    public float moveSpeed; //velocidade do inimigo  
    private bool moving;
    private Rigidbody2D rigibody;

    public float timeBetweenMove; //tempo para mudar de posição
    private float timeBetweenMoveCounter; //tempo atual de mudança de posição
    public float timeToMove; //tempo de movimentação
    private float timeToMoveCounter; //tempo atual de movimentação

    private Vector3 moveDirection; //direção
    public float waitToReload;
    private bool reloading;
    private GameObject player;

	void Start () {
        rigibody = GetComponent<Rigidbody2D>();

        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
	}
	
	void Update () {
        Move();

        if(reloading)
        {
            waitToReload -= Time.deltaTime;

            if (waitToReload < 0)
            {
                //Application.LoadLevel(Application.loadedLevel); //obsolete
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                player.SetActive(true);
            }
        }
	}

    void Move()
    {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            rigibody.velocity = moveDirection;

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            rigibody.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        /*if (other.gameObject.name=="Player")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            reloading = true;
            player = other.gameObject;
        }*/
    }
}
