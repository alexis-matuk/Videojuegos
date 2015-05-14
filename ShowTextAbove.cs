using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowTextAbove : MonoBehaviour {
	GameObject txt;

	public void showText(string t, Transform trans, Quaternion rotation)
	{
		txt = Resources.Load<GameObject>("Prefabs/Texto");
		GameObject showedText = (GameObject) Instantiate(txt, trans.position, rotation);
		showedText.GetComponent<TextMesh>().text = t;
	}
}
