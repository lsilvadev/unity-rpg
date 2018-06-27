using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [Header("Link do objeto que você quer seguir")]
    public GameObject followTarget;
    private Vector3 targetPosition;
    private static bool cameraExists;
    //com o SerializeField variavel moveSpeed aparece nas Propriedades
    [SerializeField]
    private float moveSpeed;    

	void Start () 
    {
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
		
	void Update () 
    {
        Follow();
	}

    void Follow()
    {
        targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);

        //Lerp calcula distancia do ponto A e ponto B
        //Lerp(posição corrente, posição do objeto, velocidade)
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        
    }
}
