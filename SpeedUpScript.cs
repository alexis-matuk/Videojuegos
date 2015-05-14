using UnityEngine;
using System.Collections;

public class SpeedUpScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		Aphelion aphelion = col.gameObject.GetComponent<Aphelion>();
		if(aphelion)
		{
			aphelion.increaseSpeedBy(gameObject.GetComponent<SpeedUp>().getSpeed());
			GameObject.FindGameObjectWithTag("Handler").GetComponent<ShowTextAbove>().showText("+"+gameObject.GetComponent<SpeedUp>().getSpeed()+" speed",transform,Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
