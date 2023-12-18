using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartMenu : MonoBehaviour
{
    private PlayerController playC;
    private Button button;
    private string mode;
    private MoveLeft opt;
    



    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(clicked);

        opt = GameObject.Find("BackGround").GetComponent<MoveLeft>();

        playC = GameObject.Find("Hammer").GetComponent<PlayerController>();

        //titleScr.gameObject.SetActive(false);

    }

private void clicked(){

        mode = gameObject.name;

        spd();

        playC.StartGame();
}

void spd()
    {
        if (mode == "Easy")
        {
            opt.speed = 20;
        }

        else if (mode == "Medium")
        {
            opt.speed = 25;
        }

        else if (mode == "Hard")
        {
            opt.speed = 30;
            playC.mode = mode;
        }
    }






}
