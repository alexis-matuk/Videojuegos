using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//script que cambia la bala de aphelion a XWing
public class XWingScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		BulletFireScript aphelion = col.GetComponent<BulletFireScript>();
		if(aphelion)//si aphelion toca el powerUp
		{
			aphelion.setCurrentBullet(1);//cambiar bala
			GameObject.Find("currentPowerUp").GetComponent<Image>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
			Destroy (gameObject);
		}
	}
}
