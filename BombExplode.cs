using UnityEngine;
using System.Collections;

public class BombExplode : MonoBehaviour {

	GameObject explosion;
	bool inside;
	Collider2D aph;
	
	void Start()
	{
		explosion = Resources.Load<GameObject>("Prefabs/explosion");
	}
	
	void OnEnable()
	{
		Invoke ("Destroy", 4f);
	}
	
	void Destroy()
	{
		if(inside)
		{
			aph.gameObject.GetComponent<AphelionHit>().insideBomb();
		}
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		transform.FindChild("ActualCollider").GetComponent<SpriteRenderer>().enabled = false;
		Instantiate(explosion, transform.position, transform.rotation);
	}
	
	void OnDisable()
	{
		CancelInvoke();
	}
	
	void OnTriggerStay2D(Collider2D col)
	{
		if(col.gameObject.GetComponent<Aphelion>())
		{
			inside = true;
			aph = col;
		}
	}
}
