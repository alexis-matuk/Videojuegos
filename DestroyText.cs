using UnityEngine;
using System.Collections;

public class DestroyText : MonoBehaviour {

	//invocar después de 3 segundos
	void OnEnable()
	{
		Invoke ("Destroy", .7f);
	}
	
	//destruir bala
	void Destroy()
	{
		gameObject.SetActive(false);
		Destroy (gameObject);
	}
	
	//cancelar invocación
	void OnDisable()
	{
		CancelInvoke();
	}
}
