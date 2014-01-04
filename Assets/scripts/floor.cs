using UnityEngine;
using System.Collections;

public class floor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{

		Destroy (other.gameObject);
		GameObject bucket = GameObject.Find("Bucket2");
		if(bucket == null){
			bucket = GameObject.Find("Bucket3");
		}
		if(bucket == null){
			bucket = GameObject.Find("Bucket1");
		}
		Destroy(bucket);
	}
}
