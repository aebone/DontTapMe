using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Reference to the game objects
	public GameObject InitialCanvas;
	public GameObject ScoreCanvas;
	public GameObject EnemyGO;
	public GameObject ScoreText; 
	public GameObject GameOver;
	public GameObject Logo;

	public enum GameManagerState
	{
		Opening,
		Gameplay,
		Gameover,
	}

	GameManagerState GMState;

	// Use this for initialization
	void Start () {
		GMState = GameManagerState.Opening;
	}

	// Function to update the game state
	void UpdateGameManagerState () {
		switch (GMState) {
		case GameManagerState.Opening:
			// Stop move
			Enemy.isStarted = false;

			break;
		case GameManagerState.Gameplay:
			// Reset the score
			ScoreText.GetComponent<GameScore> ().Score = 0;
			// Hide initial canvas
			InitialCanvas.SetActive (false);
			// Show score canvas
			ScoreCanvas.SetActive (true);
			// Start move
			Enemy.isStarted = true;
			// Start change directions
			EnemyGO.GetComponent<Enemy>().ActiveChangeDirections();
			// Start increase speed
			EnemyGO.GetComponent<Enemy>().ActiveIncreaseSpeed();
			break;
		case GameManagerState.Gameover:
			// Hide logo
			Logo.SetActive(false);
			// Diplay game over
			GameOver.SetActive(true);
			// Active opening canvas
			InitialCanvas.SetActive (true);
			// Hide score canvas
			ScoreCanvas.SetActive (false);
			// Show initial canvas
			InitialCanvas.SetActive (true);
			// Stop move
			Enemy.isStarted = false;
			// Stop change directions
			EnemyGO.GetComponent<Enemy>().DesactiveChangeDirections();
			// Stop increase speed
			EnemyGO.GetComponent<Enemy>().DesactiveIncreaseSpeed();
			break;
		}
	}

	// Function to set the game manager state
	public void SetGameManagerState(GameManagerState state) {
		GMState = state;
		UpdateGameManagerState ();
	}

	// Play button will call this function when the user clicks it
	public void StartGamePlay(){
		GMState = GameManagerState.Gameplay;
		UpdateGameManagerState ();
	}
}