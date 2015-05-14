using UnityEngine;
using System.Collections;

public class BlinkShield : MonoBehaviour {

	float time = 0;
	float duration = 0;
	float startBlinking=0;
	float temp=0;
	bool blinking = false;
	bool secondTime = false;
	
	void Start()
	{
		duration = GameObject.FindGameObjectWithTag("Player").GetComponent<Aphelion>().getDuration();
		startBlinking = duration-4;
		time = Time.time;
	}
	
	void Update()
	{
		gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
		if(!blinking && (Time.time-time) >= startBlinking)
		{
			if(!secondTime)
			{
				temp = Time.time;
				secondTime = true;
			}
			StartCoroutine(blink());
		}
	}
	
	float freq(float t)
	{
		float calc = t;
		return Mathf.Exp(-calc);
	}
	
	IEnumerator blink()
	{
		gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
		blinking = true;
		yield return new WaitForSeconds(freq(Time.time-temp));
		gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
		blinking = false;
	}
}
