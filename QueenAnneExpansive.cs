using UnityEngine;
using System.Collections;

public class QueenAnneExpansive : MonoBehaviour {

	GameObject expansiveWave; 
	GameObject exp;
	int cont=0;
	
	// Use this for initialization
	void OnEnable () {
		expansiveWave = Resources.Load<GameObject> ("Prefabs/Expansiva");
		exp=(GameObject) Instantiate (expansiveWave, new Vector3(0,0,412), Quaternion.identity);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (cont < 1) {
			expand ();
			if (exp.transform.localScale.x > 270) {
				Destroy (exp);
				cont++;
			}
		} else if (cont == 1) {
			cont = 0;
			gameObject.GetComponent<QueenAnneAI>().setInactive(1);
		}
	}

	void expand()
	{
		exp.transform.localScale += new Vector3(1.5f,1.5f,0);
	}
}
