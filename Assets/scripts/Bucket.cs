using UnityEngine;
using System.Collections;

public class Bucket : MonoBehaviour {

  private static int bucketNumber = 1;

  public float Speed = 10.0f;
  public Vector2 MinMaxX = Vector2.zero;

	 void destroyNextBucket() {
		print("destroy");
	}

	void Start(){
		transform.name = ("Bucket"+Bucket.bucketNumber);
		Bucket.bucketNumber++;
	}

  void Update ()
  {
	
		transform.position = new Vector3(Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal") * Speed * Time.deltaTime, MinMaxX.x, MinMaxX.y), transform.position.y,
		                                 transform.position.z);
  }

	void OnTriggerEnter(Collider other)
	{
		Destroy (other.gameObject);
	}
}
