using UnityEngine;
using System.Collections;

public class figureChoice : MonoBehaviour {
    public GameObject game;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onClick(GameObject go)
    {
        game = go;

        switch (game.tag)
        {
            case "cube":
                button1.SetActive(true);
                button2.SetActive(false);
                button3.SetActive(false);
                break;

            case "penta":
                button1.SetActive(false);
                button2.SetActive(true);
                button3.SetActive(false);
                break;

            case "giuk":
                button1.SetActive(false);
                button2.SetActive(false);
                button3.SetActive(true);
                break;

            default:
                break;
        }
    }
}


