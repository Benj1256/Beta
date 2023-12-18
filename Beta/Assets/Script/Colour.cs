using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colour : MonoBehaviour
{

    private PlayerController cont;
    Renderer ren;
    public Material bolt;
    public Material def;
    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<Renderer>();
        cont = GameObject.Find("Hammer").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cont.PowerUp == true)
        {
            // ren.enabled = true;
            ren.sharedMaterial = bolt;
        }

        else
        {
            ren.sharedMaterial = def;

        }
    }


    // REF - www.youtube.com/watch?v=8acjjqlHe20&t=11s
}
