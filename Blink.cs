using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {

	float time = 0;
	bool blinking = false;
	
	void Start()
	{
		time = Time.time;
	}
	void Update()
	{
		gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
		if(!blinking)
			StartCoroutine(blink());
	}
	
	float freq(float t)
	{
		float calc = t-time;
		return Mathf.Exp(-calc);
	}
	
	IEnumerator blink()
	{
		gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
		blinking = true;
		yield return new WaitForSeconds(freq(Time.time));
		gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
		blinking = false;
	}
}
