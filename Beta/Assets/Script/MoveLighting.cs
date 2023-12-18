using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLighting : MonoBehaviour
{

    public float speed = 20;
    private PlayerController playerC; //gets playerController script 
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        playerC = GameObject.Find("Hammer").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {


        if (playerC.gameOver == false)
        {
            transform.Translate(0, 0, -1 * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("PowerUp"))
        {
            Destroy(gameObject);
        }
    }

}

