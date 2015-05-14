using UnityEngine;
using System.Collections;

//script que ayuda al desarrollo del juego
public class drawGiz : MonoBehaviour {

	//función que sirve para cuando se editan cosas en la escena
	void OnDrawGizmos()
	{
		//dibujar una esfera en la posicion del objeto que tenga este script
		Gizmos.DrawWireSphere(transform.position, 10);
	}
}
