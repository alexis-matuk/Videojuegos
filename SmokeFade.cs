using UnityEngine;
using System.Collections;

public class SmokeFade : MonoBehaviour {

	float time = 0;
	
	void Start()
	{
		time = Time.time;
	}
	
	void Update()
	{
		float tiempo = Time.time-time;
		fade (tiempo);
	}
	
	void fade(float t)
	{
		float f = -(1f/5.5f)*t+1;
		gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,f);
	}
}
