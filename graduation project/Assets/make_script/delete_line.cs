using UnityEngine;
using System.Collections;

public class delete_line : MonoBehaviour {
	//public GameObject LineObject;
    private IEnumerator _spawnCoroutine;
    

    public void StartBalls()
    {
        _spawnCoroutine = AddlineWithDelay();
        StartCoroutine(_spawnCoroutine);
    }

    public void StopBalls()
    {
        StopAllCoroutines();
    }


    private IEnumerator AddlineWithDelay()
    {
        float delayInterval = .15f;
        while (true)
        {
            Click();
            yield return new WaitForSeconds(delayInterval);
        }
    }

	public void Click() {
        GameObject LineObject = GameObject.FindGameObjectWithTag("line");
		Destroy(LineObject);
		
	}
}
