using UnityEngine;
using System.Collections;

//clase que maneja la rotación de Aphelion
public class aphelionRotation : MonoBehaviour {
	public float rotationSpeed = 0.0f;
	float tempAngle = 0;
	
	void Update () {
		#if UNITY_EDITOR_WIN
		Vector3 dir = new Vector3(Input.GetAxis("HorizontalRotateWin")*Time.timeScale, Input.GetAxis("VerticalRotateWin")*Time.timeScale, 0);//vector dirección
		
		#endif
		
		#if UNITY_EDITOR_OSX
		Vector3 dir = new Vector3(Input.GetAxis("HorizontalRotate")*Time.timeScale, Input.GetAxis("VerticalRotate")*Time.timeScale, 0);//vector dirección
		#endif
		
		if(Mathf.Abs(dir.x)<0.01 || Mathf.Abs(dir.y)<0.01)//.01 se considera como no moviéndose
		{
			transform.rotation = Quaternion.Euler(0,0,tempAngle);//dejar la nave en su rotación actual
		}
		else{
			float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;//transformar de vector dirección a ángulo
			transform.rotation = Quaternion.Euler(0,0,angle);//rotar a Aphelion
			tempAngle = angle;
		}
	}
}
