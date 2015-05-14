using UnityEngine;
using System.Collections;

//script para destrucción de bala enemiga
//funciona igual que el script BulletDestroy. referirse a dicho script
public class EnemyBulletDestroy : MonoBehaviour {

	void OnEnable()
	{
		if(gameObject.GetComponent<HoleBulletFire>())
		{
			Invoke("Destroy",20f);
		}
		else
			Invoke ("Destroy", 3f);
	}
	
	void Destroy()
	{
		gameObject.SetActive(false);
		Destroy (gameObject);
	}
	
	void OnDisable()
	{
		CancelInvoke();
	}
}
