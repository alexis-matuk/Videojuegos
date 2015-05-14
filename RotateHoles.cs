using UnityEngine;
using System.Collections;

public class RotateHoles : MonoBehaviour {
	int rot=0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	rot+=2;
	transform.localRotation = Quaternion.Euler(0,0,rot);
	}

}
