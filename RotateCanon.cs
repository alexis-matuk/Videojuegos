using UnityEngine;
using System.Collections;

public class RotateCanon : MonoBehaviour {

	float leftLimit = -15;
	float rightLimit = 15;
	float rot=0;
	bool movingRight=true;
	
	// Update is called once per frame
	void Update () {
	
		if (rot>=leftLimit && rot<=rightLimit) {
			if (rot<=leftLimit)
				movingRight = true;
			if (rot>=rightLimit)
				movingRight = false;
			if (movingRight)
				rot+=1;
			else
				rot-=1;
		}
		//transform.FindChild("tip").Rotate(0,0,rot*Time.deltaTime);
		Quaternion rotation = Quaternion.Euler(0,0,rot);
		transform.FindChild("tip").localRotation = rotation;
	}
}
