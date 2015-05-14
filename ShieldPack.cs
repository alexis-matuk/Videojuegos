using UnityEngine;
using System.Collections;

public class ShieldPack : MonoBehaviour {

	int shield;
	
	public int getShield()
	{
		float percentageHp = GameObject.FindGameObjectWithTag("Player").GetComponent<Aphelion>().getInitialShield() * 0.15f;
		shield = (int) Mathf.Ceil(percentageHp);
		return shield;
	}
}
