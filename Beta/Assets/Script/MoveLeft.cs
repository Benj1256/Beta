using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {

    public float speed;
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
         
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle") || transform.position.x < leftBound && gameObject.CompareTag("PowerUp"))
        {
            Destroy(gameObject);
        }
    }

 

}
