using UnityEngine;
using System.Collections;

public class floor : MonoBehaviour {

	private bool destroying = false;
	private long frame = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	  if(destroying){
			frame++;
	    if(frame % 20 == 0){
				Bomb[] bombs = FindObjectsOfType(typeof(Bomb)) as Bomb[];
				if(bombs.Length > 0){
					Destroy(bombs[bombs.Length - 1].gameObject);
				 audio.Play();
			    }else{
					destroying = false;
					frame = 1;
					Bucket[] buckets = FindObjectsOfType(typeof(Bucket)) as Bucket[];
					if(buckets.Length > 0){
					 resume();
					}else{
						gameOver();
					}
				}
	    }
	  }
	}

	void OnTriggerEnter(Collider other)
	{
		ShipBehaviour ship = FindObjectOfType(typeof(ShipBehaviour)) as ShipBehaviour;
		ship.freeze();
		ship.BombCount = 0;
		Bomb[] bombs = FindObjectsOfType(typeof(Bomb)) as Bomb[];
		foreach(Bomb bomb in bombs){
			bomb.freeze();
		}
		Bucket[] buckets = FindObjectsOfType(typeof(Bucket)) as Bucket[];
		foreach(Bucket numbucket in buckets){
			numbucket.freeze();
		}

		Destroy (other.gameObject);
		audio.Play();
		GameObject bucket = GameObject.Find("Bucket2");
		if(bucket == null){
			bucket = GameObject.Find("Bucket3");
		}
		if(bucket == null){
			bucket = GameObject.Find("Bucket1");
		}

		Destroy(bucket);
		destroying = true;
	}

	void resume(){
		Bucket[] buckets = FindObjectsOfType(typeof(Bucket)) as Bucket[];
		foreach(Bucket numbucket in buckets){
			numbucket.unfreeze();
		} 
		ShipBehaviour ship = FindObjectOfType(typeof(ShipBehaviour)) as ShipBehaviour;
		ship.unfreeze();
	}

	void gameOver() {
		ScoreGlobal score = FindObjectOfType(typeof(ScoreGlobal)) as ScoreGlobal;
		score.GameOver();
		Invoke("restart",3);
	}

	void restart() {
		Application.LoadLevel(0);
	}
}
