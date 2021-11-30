using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLateral : MonoBehaviour
{


    public float speed = 5f;

    private float lowerLimit = 5f;

    private PlayerController playerControllerScript;



    // Start is called before the first frame update
    void Start()
    {

        // Nos comunicamos con el script PlayerController
        playerControllerScript = GameObject.Find("Player").
            GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        // Movemos a la derecha
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        //Eliminar Game Objects no necesarios
        if (transform.position.y < lowerLimit)
        {
            Destroy(gameObject);
        }


    }

    /*random.Range(0, 2);
        if n == 0
        {
            n = -1
        }
     n* sapwnPos;*/
}
