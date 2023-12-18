using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{

    public GameObject[] prefab1;
    private Vector3 spawnPos = new Vector3 (37.45f, 3, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playC;

    int index;
    Vector3 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        playC = GameObject.Find("Hammer").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void SpawnObstacle()
    {
        spawnLocation = new Vector3(30, Random.Range(1, 6), 0);
        index = Random.Range(0, prefab1.Length);

        if (playC.gameOver == false)
        {
            Instantiate(prefab1[index], spawnLocation, prefab1[index].transform.rotation) ;
        }
    }
}
