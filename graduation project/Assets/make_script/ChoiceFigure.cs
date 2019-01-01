using UnityEngine;
using System.Collections;

public class ChoiceFigure : MonoBehaviour {
    public bool Colorstatus = false;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    bool touch;
	// Use this for initialization
	void Start () {
        touch = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void onClick()
    {

        if (touch == true)
        {
            Button1.SetActive(true);
            Button2.SetActive(true);
            Button3.SetActive(true);
            Colorstatus = true;
            touch = false;
        }
        else
        {
            Button1.SetActive(false);
            Button2.SetActive(false);
            Button3.SetActive(false);
            touch = true;
        }

    }
}
