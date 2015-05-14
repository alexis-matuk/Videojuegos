using UnityEngine;
using System.Collections;

//script para que la cámara siga a Aphelion suavemente
public class SmoothFollowCSharp : MonoBehaviour {
/*Declaración de variables*/
	public Transform target;
	float smoothTime = 0.3f;
	Transform thisTransform;
	Vector2 velocity = new Vector2(0,0);
	public int leftBound;
	public int rightBound;
	public int lowerBound;
	public int upperBound;
	
	void Start()
	{
		thisTransform = transform;
	}
	
	void Update() 
	{
	//mover la cámara en X hasta pasar de leftBound o rightBound
		if(target.transform.position.x > leftBound && target.transform.position.x < rightBound)
		{
			float damp = Mathf.SmoothDamp(thisTransform.position.x, target.position.x, ref velocity.x, smoothTime);
			thisTransform.position = new Vector3(damp,transform.position.y,transform.position.z);
		}
		else if(target.transform.position.x > rightBound)
		{
			float damp = Mathf.SmoothDamp( thisTransform.position.x,rightBound, ref velocity.x, smoothTime);
			thisTransform.position = new Vector3(damp,transform.position.y,transform.position.z);
		}
		else if(target.transform.position.x < leftBound)
		{
			float damp = Mathf.SmoothDamp( thisTransform.position.x, leftBound, ref velocity.x, smoothTime);
			thisTransform.position = new Vector3(damp,transform.position.y,transform.position.z);
		}
		
	//mover la cámara en Y hasta pasar de upperBound o lowerBound
		if(target.transform.position.y > lowerBound && target.transform.position.y < upperBound)
		{
			float damp = Mathf.SmoothDamp( thisTransform.position.y, target.position.y, ref velocity.y, smoothTime);
			thisTransform.position = new Vector3(transform.position.x,damp,transform.position.z);
		}
		else if(target.transform.position.y > upperBound)
		{
			float damp = Mathf.SmoothDamp( thisTransform.position.y,upperBound, ref velocity.y, smoothTime);
			thisTransform.position = new Vector3(transform.position.x,damp,transform.position.z);
		}
		else if(target.transform.position.y < lowerBound)
		{
			float damp = Mathf.SmoothDamp( thisTransform.position.y, lowerBound, ref velocity.y, smoothTime);
			thisTransform.position = new Vector3(transform.position.x,damp,transform.position.z);
		}
	}
}
