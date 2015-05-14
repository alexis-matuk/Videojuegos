using UnityEngine;
using System.Collections;

public class KamikazeFlicker : MonoBehaviour {

	bool blinking = false;
	Color red;
	Color normal;
	bool reColor = false;
	
	void Start()
	{
		red = new Color(1,0,0,1);
		normal = new Color(1,1,1,1);
		//Debug.Log (gameObject.GetComponent<CircleCollider2D>().bounds);
	}
	void Update()
	{
		if(!reColor)
			transform.FindChild("Kamikaze").gameObject.GetComponent<SpriteRenderer>().color = normal;
		reColor = false;
	}
	
	void OnTriggerStay2D(Collider2D col)
	{
		if(col.gameObject.GetComponent<Aphelion>())
		{
			if(Mathf.Abs(col.transform.position.x-transform.position.x) < (float)gameObject.GetComponent<CircleCollider2D>().bounds.extents.x)
			{
				if(Mathf.Abs(col.transform.position.y-transform.position.y) < (float)gameObject.GetComponent<CircleCollider2D>().bounds.extents.y)
				{
					if(!blinking)
						StartCoroutine(blink(col));
				}
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		
	}
	
	float freq(float x, float y)
	{
		//return ((((gameObject.GetComponent<CircleCollider2D>().bounds.extents.x/2)*x) + ((gameObject.GetComponent<CircleCollider2D>().bounds.extents.x/2)*y))/(gameObject.GetComponent<CircleCollider2D>().bounds.extents.x*gameObject.GetComponent<CircleCollider2D>().bounds.extents.y));
		float power = Mathf.Pow(gameObject.GetComponent<CircleCollider2D>().bounds.extents.x,2);
		return Mathf.Sqrt((0.25f)*((Mathf.Pow(x,2)/power)+(Mathf.Pow(y,2)/power)));
		//return (1f)*((Mathf.Pow(x,2)/power)+(Mathf.Pow(y,2)/power));
	}
	
	IEnumerator blink(Collider2D col)
	{
		transform.FindChild("Kamikaze").gameObject.GetComponent<SpriteRenderer>().color = normal;
		blinking = true;
		float wait=0;
		float wait2=0;
		if(col.transform.position.x < transform.position.x)
		{
			wait = transform.position.x-transform.FindChild("Kamikaze").gameObject.GetComponent<CircleCollider2D>().bounds.extents.x;
		}
		else
		{
			wait = transform.position.x+transform.FindChild("Kamikaze").gameObject.GetComponent<CircleCollider2D>().bounds.extents.x;
		}
		
		if(col.transform.position.y < transform.position.y)
		{
			wait2 = transform.position.y-transform.FindChild("Kamikaze").gameObject.GetComponent<CircleCollider2D>().bounds.extents.y;
		}
		else
		{
			wait2 = transform.position.y+transform.FindChild("Kamikaze").gameObject.GetComponent<CircleCollider2D>().bounds.extents.y;
		}
		
		yield return new WaitForSeconds(freq(Mathf.Abs(col.transform.position.x-wait),Mathf.Abs(col.transform.position.y-wait2)));
		transform.FindChild("Kamikaze").gameObject.GetComponent<SpriteRenderer>().color = red;
		blinking = false;
	}
	
	public void changeColor()
	{
		reColor = true;
	}
}
