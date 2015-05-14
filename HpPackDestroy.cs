using UnityEngine;
using System.Collections;

public class HpPackDestroy : MonoBehaviour {

	//invocar después de 6 segundos
	void OnEnable()
	{
		Nuke n = gameObject.GetComponent<Nuke>();
		TempShield s = gameObject.GetComponent<TempShield>();
		if(n || s)
		{
			Invoke("Destroy",4f);//el nuke se detruye en 4 segundos
		}
		else
		{
		Invoke ("Destroy", 3f);//los demás consumables se destruyen en 3 segundos
		}
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
