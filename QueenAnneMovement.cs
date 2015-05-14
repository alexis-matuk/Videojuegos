using UnityEngine;
using System.Collections;

public class QueenAnneMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void rotateQueen()
	{
		transform.Rotate(new Vector3(0,0,0.7f));
	}


	// Update is called once per frame
	void Update () {

		rotateQueen ();
	
	}
}
