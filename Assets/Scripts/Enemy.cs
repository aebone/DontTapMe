using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {

	float RotateZ = -50.0f;
	public GameObject GameManagerObject;
	public GameObject ScoreText;
	public Text HighScoreText;
	public static bool isStarted;

	public int score;
	public int highScore = 0;
	string highScoreKey = "HighScore";

	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetInt(highScoreKey, 0); 
		HighScoreText.text = highScore.ToString();
	}

	// Update is called once per frame
	void Update () {
		if (isStarted) {
			transform.Rotate (
				0.0f * Time.deltaTime, //x
				0.0f * Time.deltaTime, //y
				RotateZ * Time.deltaTime //z
			);
		}
	}

	void OnMouseDown() {
		score = ScoreText.GetComponent<GameScore> ().Score;
		if(score>highScore){
			PlayerPrefs.SetInt(highScoreKey, score);
			PlayerPrefs.Save();
			highScore = score;
		}
		HighScoreText.text = highScore.ToString();
		GameManagerObject.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.Gameover);
	}

	public void ActiveChangeDirections() {
		InvokeRepeating ("ChangeDirections", 15, 15);
	}

	public void ActiveIncreaseSpeed() {
		InvokeRepeating ("IncreaseSpeed", 10, 10);
	}
		
	public void DesactiveChangeDirections() {
		CancelInvoke ("ChangeDirections");
	}

	public void DesactiveIncreaseSpeed() {
		CancelInvoke ("IncreaseSpeed");
		RotateZ = -50.0f;
	}

	void ChangeDirections() {
		if (RotateZ > 0)
			RotateZ = -RotateZ;
		else if (RotateZ < 0) 
			RotateZ = System.Math.Abs(RotateZ);
	}

	void IncreaseSpeed() {
		if (RotateZ > 0)
			RotateZ = (-RotateZ) - 15.0f;
		else if (RotateZ < 0) 
			RotateZ = System.Math.Abs(RotateZ) + 15.0f;
	} 
}