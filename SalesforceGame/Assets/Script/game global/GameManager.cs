using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private GameObject coffe1;
    private GameObject coffe2;
    private GameObject coffe3;
    private GameObject coffe4;
    private GameObject coffe5;
    private GameObject coffe6;

    private GameObject gameover;

    private GameObject player;

    private GameObject gamecomplete;

    // Use this for initialization
    void Start () {

        coffe1 = GameObject.Find("health1");
        coffe2 = GameObject.Find("health2");
        coffe3 = GameObject.Find("health3");
        coffe4 = GameObject.Find("health4");
        coffe5 = GameObject.Find("health5");
        coffe6 = GameObject.Find("health6");

        gameover = GameObject.Find("gameover");

        gamecomplete = GameObject.Find("complete");

        player = GameObject.Find("player");

        gameover.SetActive(false);
        gamecomplete.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        switch (player.GetComponent<player>().checkLife()) {
            case 1:
                coffe2.SetActive(false);
                coffe3.SetActive(false);
                coffe4.SetActive(false);
                coffe5.SetActive(false);
                coffe6.SetActive(false);
                break;
            case 2:
                coffe3.SetActive(false);
                coffe4.SetActive(false);
                coffe5.SetActive(false);
                coffe6.SetActive(false);
                break;
            case 3:
                coffe4.SetActive(false);
                coffe5.SetActive(false);
                coffe6.SetActive(false);
                break;
            case 4:
                coffe5.SetActive(false);
                coffe6.SetActive(false);
                break;
            case 5:
                coffe6.SetActive(false);
                break;
            case 99:
                gamecomplete.SetActive(true);
                break;
            case 0:
                coffe1.SetActive(false);
                coffe2.SetActive(false);
                coffe3.SetActive(false);
                coffe4.SetActive(false);
                coffe5.SetActive(false);
                coffe6.SetActive(false);
                gameover.SetActive(true);
                break;
            default:
                break;
        }
    }
}
