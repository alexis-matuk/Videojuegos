using UnityEngine;
using System.Collections;

public class SpeedUp : MonoBehaviour {

	public float getSpeed()
	{
		float percentageSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<Aphelion>().getInitialSpeed() * 0.15f;
		return percentageSpeed;
	}
}
