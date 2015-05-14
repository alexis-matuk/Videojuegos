using UnityEngine;
using System.Collections;

public class BlinkBomb : MonoBehaviour {

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
		{
			StartCoroutine(blink());
		}
	}
	
	float freq(float t)
	{
		float calc = t;
		return Mathf.Exp(-calc+0.5f);
	}
	
	IEnumerator blink()
	{
		gameObject.GetComponent<SpriteRenderer>().color = new Color(1,0,0,1);
		blinking = true;
		yield return new WaitForSeconds(freq(Time.time-time));
		gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
		blinking = false;
	}
}
