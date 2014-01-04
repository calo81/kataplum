using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
	public Vector3 Direction = Vector3.down;

	public float Speed = 20.0f;

	public float Lifetime = 10.0f;

	void Start ()
	{
		Invoke("DestroyMe", Lifetime);
	}

	void Update ()
	{
		transform.position += Direction * Speed * Time.deltaTime;
	}

	void DestroyMe()
	{
		Destroy(gameObject);
	}
}
