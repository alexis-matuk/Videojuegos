using UnityEngine;
using System.Collections;

public class FireCrossStream : MonoBehaviour {
	
	GameObject bullet;
	CrossStream cross;
	Sprite redBull;
	
	// Use this for initialization
	void Start () {
		bullet = Resources.Load<GameObject>("Prefabs/bullet_enemy");
		InvokeRepeating("Fire", Random.Range(0.2f,1f), 0.5f);//disparar cada número de segundos random
		cross = gameObject.GetComponent<CrossStream>();
		redBull = Resources.Load<Sprite>("Sprites/redBullet");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Fire()
	{
		foreach (Transform child in transform)
		{
				GameObject bull = (GameObject) Instantiate(bullet, child.position, child.rotation);
				bull.GetComponent<EnemyBullet>().setDamage(cross.getDamage());
				bull.GetComponent<SpriteRenderer>().sprite = redBull;//cambiar sprite
		}
	}
}
