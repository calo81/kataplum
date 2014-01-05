using UnityEngine;
using System.Collections;

public class Bucket : MonoBehaviour {

  private static int bucketNumber = 1;
  private bool frozen = false;

  public float Speed = 10.0f;
  public Vector2 MinMaxX = Vector2.zero;
	
	void Start(){
		transform.name = ("Bucket"+Bucket.bucketNumber);
		Bucket.bucketNumber++;
	}

	public void freeze(){
		this.frozen = true;
	}
	
	public void unfreeze(){
		this.frozen = false;
	}

	void Awake() {
		bucketNumber = 1;  
	}

  void Update ()
  {
	if(!frozen){
		transform.position = new Vector3(Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal") * Speed * Time.deltaTime, MinMaxX.x, MinMaxX.y), transform.position.y,
		                                 transform.position.z);
		}
  }

	void OnTriggerEnter(Collider other)
	{
		audio.Play();
		Destroy (other.gameObject);
		ScoreGlobal score = FindObjectOfType(typeof(ScoreGlobal)) as ScoreGlobal;
		score.Score += 100;
	}
	
}
