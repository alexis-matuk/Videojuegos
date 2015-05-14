using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//script para cambiar la bala de Aphelion a onda
public class WavePowerUp : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		BulletFireScript aphelion = col.GetComponent<BulletFireScript>();
		if(aphelion)//si aphelion toca el powerUp
		{
			aphelion.setCurrentBullet(2);//cambiar bala
			GameObject.Find("currentPowerUp").GetComponent<Image>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
			GameObject.Find("currentPowerUp").GetComponent<RectTransform>().sizeDelta = new Vector2(120,80);
			Destroy (gameObject);
		}
	}
}
