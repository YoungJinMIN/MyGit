using UnityEngine;
using System.Collections;

public class ColorStatusScript : MonoBehaviour {

    public GameObject g;
 
    public static int statnum=0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onClick(GameObject go)
    {
        g = go;
        if (g.tag == "Red")
        {
            statnum = 1;
            Debug.Log(statnum);
        }
        else if (g.tag == "Green")
        {
            statnum = 2;
            Debug.Log(statnum);
        }
        else if (g.tag == "Blue")
        {
            statnum = 3;
            Debug.Log(statnum);
        }
        else if (g.tag == "Black")
        {
            statnum = 4;
            Debug.Log(statnum);
        }
    }
}
