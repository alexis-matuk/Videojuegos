using UnityEngine;
using System.Collections;

//script principal para disparar el láser. WIP
public class laserFire : MonoBehaviour {
	int damage;
	GameObject aphelion;
	
	void Start () {
		aphelion = GameObject.FindGameObjectWithTag("Player");//referencia a aphelion
		damage = aphelion.GetComponent<Aphelion>().getDamage();//referencia al daño de aphelion
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.DrawRay(aphelion.transform.FindChild("tip").position, aphelion.transform.FindChild("tip").up*1000, Color.cyan);
		//dibujar rayo para debug
	
		RaycastHit hit;
		Ray rasho = new Ray(aphelion.transform.FindChild("tip").position, aphelion.transform.FindChild("tip").up);//rayo a disparar
		transform.position = aphelion.transform.FindChild("tip").position;
		transform.rotation = aphelion.transform.FindChild("tip").rotation;
		if(Physics.Raycast(rasho, out hit, Mathf.Infinity))//hacer un raycast hacia adelante
		{	
			float distance = Vector2.Distance(hit.point, aphelion.transform.FindChild("tip").position);//distancia a la pared golpeada
			transform.localScale = new Vector3(gameObject.transform.localScale.x, distance*Mathf.PI+50, 0);//cambiar tamaño del láser
			gameObject.GetComponent<BoxCollider2D>().size = new Vector2(gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x, gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y);//cambiar collider de láser
			
		}	
	}
	
	/*
		probar:
		hacer el raycast
		si esta tocando
			mientras no haya una colisión, aumentar la escala en y
		cuando haya colision dejar de escalar
	*/
	
	//regresar daño
	public int getDamage()
	{
		return damage+5;
	}
}
