using UnityEngine;
using System.Collections;

public class BombDestroy : MonoBehaviour {

	void OnEnable()
	{
		Invoke ("Destroy", 5f);
	}
	
	void Destroy()
	{
		Destroy (gameObject);
	}
	
	void OnDisable()
	{
		CancelInvoke();
	}
	
}
