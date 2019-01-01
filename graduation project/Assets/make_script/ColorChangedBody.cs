using UnityEngine;
using System.Collections;

public class ColorChangedBody : MonoBehaviour {
	Renderer rend;
    //int test = 0;
	// Use this for initializatio
	void Start () {
		rend = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void Click(){
        
        if(ColorStatusScript.statnum==1){
            rend.material.color = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
        }
        else if (ColorStatusScript.statnum == 2)
        {
            rend.material.color = new Vector4(0.0f, 1.0f, 0.0f, 1.0f);
        }
        else if (ColorStatusScript.statnum == 3)
        {
            rend.material.color = new Vector4(0.0f, 0.0f, 1.0f, 1.0f);
        }
        else if (ColorStatusScript.statnum == 4)
        {
            rend.material.color = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
        }
        
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "rHand")
        {
            if (ColorStatusScript.statnum == 1)
            {
                rend.material.color = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
            }
            else if (ColorStatusScript.statnum == 2)
            {
                rend.material.color = new Vector4(0.0f, 1.0f, 0.0f, 1.0f);
            }
            else if (ColorStatusScript.statnum == 3)
            {
                rend.material.color = new Vector4(0.0f, 0.0f, 1.0f, 1.0f);
            }
            else if (ColorStatusScript.statnum == 4)
            {
                rend.material.color = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
            }
        }
    }
}
