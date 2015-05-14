using UnityEngine;
using System.Collections;

public class DamageUpScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		Aphelion aphelion = col.gameObject.GetComponent<Aphelion>();
		if(aphelion)
		{
			aphelion.increaseDamageBy(gameObject.GetComponent<DamageUp>().getDamageUp());
			
			GameObject.FindGameObjectWithTag("Handler").GetComponent<ShowTextAbove>().showText("+"+gameObject.GetComponent<DamageUp>().getDamageUp()+" dmg",transform,Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
