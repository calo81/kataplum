using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
	public Vector3 Direction = Vector3.down;

	public float Speed = 20.0f;

	public float Lifetime = 10.0f;

	private bool frozen = false;

	public void freeze(){
		this.frozen = true;
	}
	
	public void unfreeze(){
		this.frozen = false;
	}

	void Update ()
	{
		if(!frozen){
		  transform.position += Direction * Speed * Time.deltaTime;
		}
	}
	
}
