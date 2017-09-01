using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLVL1 : MonoBehaviour {

    private GameObject tex;
    private GameObject tex1;
    private GameObject tex2;
    private GameObject tex3;

    private GameObject chat;

    private GameObject player;

    private int x = 0;
    // Use this for initialization
    void Start () {

        tex = GameObject.Find("Text0");
        tex1 = GameObject.Find("Text1");
        tex2 = GameObject.Find("Text2");
        tex3 = GameObject.Find("Text3");

        chat = GameObject.Find("Chat");

        player = GameObject.Find("player");
    }
	
	// Update is called once per frame
	void Update () {
        switch (x) {

            case 0:
                tex.SetActive(true);
                tex1.SetActive(false);
                tex2.SetActive(false);
                tex3.SetActive(false);
                break;
            case 1:
                tex.SetActive(false);
                tex1.SetActive(true);
                tex2.SetActive(false);
                tex3.SetActive(false);
                break;

            case 2:
                tex.SetActive(false);
                tex1.SetActive(false);
                tex2.SetActive(true);
                tex3.SetActive(false);
                break;

            case 3:
                tex.SetActive(false);
                tex1.SetActive(false);
                tex2.SetActive(false);
                tex3.SetActive(true);
                break;

            case 4:
                chat.SetActive(false);
                player.GetComponent<player>().SetplayerStart(true);
                break;
        }
	}

    public void LoadStage() {
        x++;
        Debug.Log(" SUMANDO " + x);
    }
}
