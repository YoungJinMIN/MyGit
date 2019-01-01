using UnityEngine;
using System.Collections;

public class instanceStar : MonoBehaviour {
    public GameObject Prefab;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Click(GameObject Prefab)
    {
        //Object cube = Instantiate(Prefab, transform.position, transform.rotation);
        GameObject Box = GameObject.Find("BoxObject");
        GameObject cube = Instantiate(Prefab);
        cube.transform.parent = Box.transform;
        cube.transform.localPosition = new Vector3(0.1f, 0.2f, 0.1f);
        cube.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        cube.transform.localRotation = transform.localRotation;
    }
}
