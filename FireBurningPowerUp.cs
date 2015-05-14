using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//script que cambia la bala de aphelion a fireBurning
public class FireBurningPowerUp : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		BulletFireScript aphelion = col.GetComponent<BulletFireScript>();
		if(aphelion)//si el aphelion agarra el powerUp
		{
			aphelion.setCurrentBullet(4);//cambiar bala
			GameObject.Find("currentPowerUp").GetComponent<Image>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
			Destroy (gameObject);
		}
	}
}
