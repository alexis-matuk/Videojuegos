using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QueenAnneAI : MonoBehaviour {

	int random;
	bool waiting=false;
	
	// Use this for initialization
	void Start () {
		(gameObject.GetComponent<QueenAnneExpansive> ()).enabled = false;
		(gameObject.GetComponent<QueenAnneFire> ()).enabled = false;
		(gameObject.GetComponent<QueenAnneSpawnMine> ()).enabled = false;
		//(gameObject.GetComponent<QueenAnneSpawnShootingStars> ()).enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!waiting) {
			StartCoroutine(ataca());
		}
	}

	IEnumerator ataca()
	{
		waiting = true;
		atacaca ();
		yield return new WaitForSeconds(Random.Range(2f,4f));
		waiting=false;
	}
	
	void atacaca()
	{
		random = Random.Range (1, 100);

		if(random < 35)
		{
			(gameObject.GetComponent<QueenAnneExpansive> ()).enabled = true;
		}
		else if(random<40)
		{
			(gameObject.GetComponent<QueenAnneSpawnShootingStars> ()).enabled = true;
		}
		else if(random < 60)
		{
			(gameObject.GetComponent<QueenAnneSpawnMine> ()).enabled = true;
		}
		else if (random < 100) {
			(gameObject.GetComponent<QueenAnneFire> ()).enabled = true;
		}
	}

	public void setInactive(int script)
	{
		switch (script) 
		{
		case 1:
			(gameObject.GetComponent<QueenAnneExpansive> ()).enabled = false;
			break;
		case 2:
			(gameObject.GetComponent<QueenAnneFire> ()).enabled = false;
			break;
		case 3:
			(gameObject.GetComponent<QueenAnneSpawnMine> ()).enabled = false;
			break;
		case 4:
			(gameObject.GetComponent<QueenAnneSpawnShootingStars> ()).enabled = false;
			break;

		default:
			break;
		}
	}


}
