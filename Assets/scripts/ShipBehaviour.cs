using UnityEngine;
using System.Collections;

public class ShipBehaviour : MonoBehaviour {
	public float Speed = 10.0f;
    public Vector2 MinMaxX = Vector2.zero;
	public GameObject PrefabAmmo = null;
	public GameObject GunPosition = null;

	private int updateCount=0;
	private int direction=1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		updateCount++;
		if(updateCount % 15 == 0){
		  do{
		      direction = Random.Range(-1, 2);
			}while(direction == 0);
			Instantiate(PrefabAmmo, GunPosition.transform.position, PrefabAmmo.transform.rotation);
		}
		transform.position = new Vector3(Mathf.Clamp(transform.position.x + direction * Speed * Time.deltaTime, MinMaxX.x, MinMaxX.y), transform.position.y, transform.position.z);
	}
}
