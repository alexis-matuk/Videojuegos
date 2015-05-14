using UnityEngine;
using System.Collections;

public class TempShield : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		Aphelion aphelion = col.gameObject.GetComponent<Aphelion>();
		if(aphelion)
		{
			aphelion.spawnShield();
			Destroy(gameObject);
		}
	}
}
