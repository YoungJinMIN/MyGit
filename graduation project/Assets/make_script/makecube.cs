using UnityEngine;
using System.Collections;

public class makecube : MonoBehaviour {
	private float speedX;
	private float speedY;
	public Material mat;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click(){
		speedX = Random.Range (-1f, 1f);
		speedY = Random.Range (-1f, 1f);	
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3(speedX,speedY,1);
		cube.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
        //cube.transform.localRotation = new Vector3(0, 0, 0);
  
	}
}
