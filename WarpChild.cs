using UnityEngine;
using System.Collections;

public class WarpChild : MonoBehaviour {
	float wait = 0.5f;
	bool waiting = false;
	bool sent = false;
	void OnTriggerEnter2D(Collider2D col)
	{
		if(sent)
		{
			StartCoroutine(timer());
		}
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			Transform par = transform.parent;
			if(!sent){
				col.gameObject.transform.position = par.FindChild("warpLeft").transform.position;
				par.FindChild("warpLeft").GetComponent<WarpParent>().sentFromWarp();
			}
			if(!waiting)
			{
				col.gameObject.transform.position = par.FindChild("warpLeft").transform.position;
				par.FindChild("warpLeft").GetComponent<WarpParent>().sentFromWarp();
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			sent = false;
		}
	}
	
	
	IEnumerator timer()
	{
		float w = wait;
		while(w > 0)
		{
			w-=Time.deltaTime;
			waiting = true;
			yield return null;
		}
		waiting = false;
	}
	
	public void sentFromWarp()
	{
		sent = true;
	}
	
}
