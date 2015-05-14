using UnityEngine;
using System.Collections;

public class ShieldPackScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		Aphelion aphelion = col.gameObject.GetComponent<Aphelion>();
		if(aphelion)
		{
			aphelion.increaseShieldBy(gameObject.GetComponent<ShieldPack>().getShield());
			GameObject.FindGameObjectWithTag("Handler").GetComponent<ShowTextAbove>().showText("+"+gameObject.GetComponent<ShieldPack>().getShield().ToString()+" def",transform,Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
