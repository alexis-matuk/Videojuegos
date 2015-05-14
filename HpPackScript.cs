using UnityEngine;
using System.Collections;

public class HpPackScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		Aphelion aphelion = col.gameObject.GetComponent<Aphelion>();
		if(aphelion)
		{
			aphelion.increaseHealthBy(gameObject.GetComponent<HpPack>().getHp());
			GameObject.FindGameObjectWithTag("Handler").GetComponent<ShowTextAbove>().showText("+"+gameObject.GetComponent<HpPack>().getHp().ToString()+" hp",transform,Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
