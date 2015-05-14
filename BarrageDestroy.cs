using UnityEngine;
using System.Collections;

public class BarrageDestroy : MonoBehaviour {
	
	
	void Update()
	{
		//destruir barrage si ya no tiene hijos
		if(gameObject.transform.childCount <= 0)
		{
			Destroy (this.gameObject);
		}
	}

}
