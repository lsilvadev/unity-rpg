using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

    [Header("Link do objeto que você quer seguir")]
    public GameObject target;
    private Vector3 positionTarget;

    //com o SerializeField variavel seep aparece nas Propriedades
    [SerializeField]
    private float speed;

	void Start () 
    {
	    	
	}
		
	void Update () 
    {
        Follow();
	}

    void Follow()
    {
        positionTarget = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

        //Lerp calcula distancia do ponto A e ponto B
        //Lerp(posição corrente, posição do objeto, velocidade)
        Vector3 tempPosition = Vector3.Lerp(transform.position, positionTarget, speed);

        transform.position = tempPosition;
    }
}
