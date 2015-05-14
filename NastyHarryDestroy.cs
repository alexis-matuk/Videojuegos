using UnityEngine;
using System.Collections;

//script que destruye el objeto NastyHarry
public class NastyHarryDestroy : MonoBehaviour {

	//destruir después de 0.2 segundos en la pantalla
	void OnEnable()
	{
		Invoke ("Destroy", 0.2f);
	}
	
	void Destroy()
	{
		Destroy (gameObject);
	}
}
