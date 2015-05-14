using UnityEngine;
using System.Collections;

//clase que maneja la destrucción de la Bala
//este script es por seguridad en cuanto a el tiempo que permanecen instanciadas las balas
public class BulletDestroyScript : MonoBehaviour {

	//invocar después de 3 segundos
	void OnEnable()
	{
		Invoke ("Destroy", 3f);
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
