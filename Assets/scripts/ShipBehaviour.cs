using UnityEngine;
using System.Collections;

public class ShipBehaviour : MonoBehaviour {
	public float Speed = 100;
    public Vector2 MinMaxX = Vector2.zero;
	public GameObject PrefabAmmo = null;
	public GameObject GunPosition = null;
	public int BombsPerLevel = 30;

	private int updateCount=0;
	private int direction=1;
	public int BombCount = 0;
	private bool ChangingLevel = false;
	private bool frozen = false;
	private int BombsEveryNumberFrames = 90;
	private int FramesChangeDirection = 15;
	private int freezeCount = 0;
	private int level = 1;

	// Use this for initialization
	void Start () {
	
	}

	public void freeze(){
		this.freezeCount ++;
		this.frozen = true;
	}

	public void unfreeze(){
		this.freezeCount--;
		if(freezeCount == 0){
		  this.frozen = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if(ChangingLevel){
			Bomb[] bombs = FindObjectsOfType(typeof(Bomb)) as Bomb[];
			if(bombs.Length == 0){
				ChangingLevel = false;
				unfreeze();
			}
			return;
		}

		if(!frozen){
		 updateCount++;


		if(updateCount % FramesChangeDirection == 0){
		  do{
		    direction = Random.Range(-1, 2);
		  }while(direction == 0);
		}
		 if(updateCount % BombsEveryNumberFrames == 0){
			 Instantiate(PrefabAmmo, GunPosition.transform.position, PrefabAmmo.transform.rotation);
			 audio.Play();
			 BombCount++;
			 if(BombCount == BombsPerLevel){
					NextLevel();
			 }
		 }
		 transform.position = new Vector3(Mathf.Clamp(transform.position.x + direction * Speed * Time.deltaTime, MinMaxX.x, MinMaxX.y), transform.position.y, transform.position.z);
	   }
	}

	void NextLevel() {
		level++;
		freeze();
		ChangingLevel = true;
		BombCount = 0;
		BombsEveryNumberFrames -= 10; 
		if(BombsEveryNumberFrames == 0){
			BombsEveryNumberFrames = 1; 
		}
	}

	void OnGUI()
	{
		GUI.Label(new Rect(210,10, 200, 30), "Bombs remaining "+(BombsPerLevel-BombCount));
		GUI.Label(new Rect(420,10, 200, 30), "Level "+level);
	}
}
