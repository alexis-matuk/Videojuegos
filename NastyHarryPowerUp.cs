using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//script que cambia la bala de aphelion a NastyHarry
public class NastyHarryPowerUp : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		BulletFireScript aphelion = col.GetComponent<BulletFireScript>();
		if(aphelion)//si aphelion agarra el powerup
		{
			aphelion.setCurrentBullet(5);//cambiar bala
			GameObject.Find("currentPowerUp").GetComponent<Image>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
			Destroy (gameObject);
		}
	}
}
