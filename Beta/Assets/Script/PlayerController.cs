using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private Rigidbody PlayerRb;

    int powerUpDuration = 5;

    public string mode;
    public GameObject restartButton;

    //public ParticleSystem explosiveParticle;
    // public ParticleSystem LightingParticle; (lighting effect)
    // public float Gravity; use when collide
    private AudioSource audio;
    public bool gameOver = true;
    public float speed = 80.0f;
    private GameObject camera;
    public bool PowerUp;
    public GameObject title;
    private StartMenu menu;
    //private Animator playerAnim; (use later for thor)

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        PlayerRb = GetComponent<Rigidbody>();
        camera = GameObject.Find("Main Camera");
        menu = GameObject.Find("Easy").GetComponent<StartMenu>();
        

    }

    // Update is called once per frame
    void Update()

    {
       float op = Input.GetAxis("Vertical");
       float po = Input.GetAxis("Horizontal");


        if (op != 0  && !gameOver)
        {
            PlayerRb.AddForce(camera.transform.up  * speed * op);
        }

       else if (mode == "Hard" && po != 0 && !gameOver)
        {
            PlayerRb.AddForce(camera.transform.right * speed * po);
        }

        PlayerRb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Goal"))
        {
            PlayerRb.useGravity = true;
            gameOver = true;
            Debug.Log("Congrats");

        }

        else if (PowerUp == true)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {

            }

            else
            {
                Destroy(collision.gameObject);
                StartCoroutine(PowerupCooldown());
            }
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {

            PlayerRb.useGravity = true;
            gameOver = true;
            Debug.Log("Game Over");
            restartButton.SetActive(true);
           // audio.PlayOneShot(crashSound);
            //explosiveParticle.Play();
        }
     }


    private void OnTriggerEnter(Collider collision) { 
     if(collision.gameObject.CompareTag("PowerUp"))
        {
            PowerUp = true;
            Destroy(collision.gameObject);
        }




    }

    public void StartGame()
    {
        gameOver = false;
        title.gameObject.SetActive(false);
        
        // Physics.gravity *= Gravity; (Use when collides to fall)
        //playerAnim = GetComponent<Animator>();

    }


    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        PowerUp = false;
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restartButton.SetActive(false);
    }
}
