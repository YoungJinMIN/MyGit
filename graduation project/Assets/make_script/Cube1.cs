using UnityEngine;
using System.Collections;

public class Cube1 : MonoBehaviour {
	float speed = 0f;
	bool move = true;
	bool check = true;
    bool check1;
	int time;
    int time1;
	public float rotateRate = 1.0f;
	public float InvokeRate = 1.0f;

	//float xRot;
	//float yRot;
	//float zRot;
	//float wRot;


	void Start () {
		//InvokeRepeating ("newRotation", 0.0f, InvokeRate);
        speed = 0f;
        time = 0;
        time1 = 0;
        check1 = false;
    }
	void Update()
    {
        
		if (time < 50 && speed != 0) {

           // if (check == true) {
				transform.Translate (0f,speed * Time.deltaTime, 0f);
		//	} else {
		//		transform.Translate (0f,-(speed * Time.deltaTime), 0f);
		//	}
			print ("move");
            time++;

		}
        else if(time >= 50 && time <= 121 && speed!=0 || time >= 171 && time <= 242 && speed != 0)
        {
			print(time);
			
			transform.Rotate (0,5f,0);
			time++;	
            /*
            if (time == 121)
            {
                speed = 0f;
                time = 0;
            }
            */
        }
        else if(time >= 121 && time <=171 && speed!=0)
        {
            transform.Translate(0f, -(speed * Time.deltaTime), 0f);
            time++;
        }
        if (time > 242)
        {
            time = 0;
            speed = 0f;

            if (check == true)
                check = false;
            else
                check = true;

        }

    }
   

	/*void newRotation()
	{
		xRot = Random.Range (-720, 720);
		yRot = Random.Range (-720, 720);
		zRot = Random.Range (-720, 720);
		wRot = Random.Range (-720, 720);
	}

	/*
	void Update () {
		if (time < 10&&speed!=0) {
			transform.Translate (0f, speed * Time.deltaTime, 0f);
			print ("move");
			time++;
		}
		else if(time >= 10 && time < 200 && speed!=0){
			//transform.Rotate (0,speed,0);
			transform.Rotate(new Vector3(15,30,30)*Time.deltaTime);
			print ("rotate");
			time++;
		}
			//transform.rotation = Quaternion.Euler(speed,0,0);
	}
	*/
	public void Stop(){
        /*
		if (move == true) {
			speed = 1f;
			move = false;
		} else {
			speed = 0f;
			move = true;
		}
        */
        speed = 1f;
        check1 = true;
	}
}

