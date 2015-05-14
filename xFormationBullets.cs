using UnityEngine;
using System.Collections;

//clase que maneja las balas de XWing
public class xFormationBullets : MonoBehaviour {
	public GameObject bullet;

	void Start () {
	foreach(Transform child in transform)//por cada posición hija dentro de la formación
		{
			GameObject bala = (GameObject) Instantiate(bullet, child.position, child.rotation);//instanciar una bala
			bala.GetComponent<Bullet>().setDamage(GameObject.FindGameObjectWithTag("Player").GetComponent<Aphelion>().getDamage());
		}
	}
	//El powerUp XWing instancia un objecto xFormation, que permanece vivo por 0.001 segundos, pero
	//cuando inicia instancía balas en cada una de sus posiciones hijas
	
	//obtener bala
	public GameObject getBullet()
	{
		return bullet;
	}
}
