using UnityEngine;
using System.Collections;

//script para destruir las explosiones instanciadas
public class ExplosionDestroy : MonoBehaviour {

	//destruir explosión después de 2 segundos que esté en la escena
	void OnEnable()
	{
		Invoke ("Destroy", 2f);
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
