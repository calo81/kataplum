using UnityEngine;
using System.Collections;

public class Bucket : MonoBehaviour {
	
  public float Speed = 10.0f;
  public Vector2 MinMaxX = Vector2.zero;

  void Update ()
  {
    transform.position = new Vector3(Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal") * Speed * Time.deltaTime, MinMaxX.x, MinMaxX.y), transform.position.y,
		                                 transform.position.z);
  }
}
