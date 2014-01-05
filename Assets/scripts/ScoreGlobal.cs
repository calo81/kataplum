using UnityEngine;
using System.Collections;

public class ScoreGlobal : MonoBehaviour {

	public int Score = 0; 
	public string gameOver = "";

	void OnGUI()
	{
		GUI.Label(new Rect(10,10, 200, 30), "Score "+Score);
		GUI.Label(new Rect(500,300, 200, 30), gameOver);
	}

	public void GameOver() {
		gameOver = "GAME OVER!";
	}
}
