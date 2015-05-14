using UnityEngine;
using System.Collections;

//script para destruir xBullet
public class XDestroy : MonoBehaviour {

	//destruir la formación X después de 0.001 segundos que lleve instanciada
	void OnEnable()
	{
		Invoke ("Destroy", 0.001f);
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
