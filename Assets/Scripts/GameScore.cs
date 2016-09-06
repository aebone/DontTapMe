using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScore : MonoBehaviour {

	public Text ScoreText;
	int score;

	public int Score 
	{
		get { 
			return this.score;
		}
		set { 
			this.score = value;
			UpdateScoreText ();
		}
	}

	// Update score text
	void UpdateScoreText() {
		ScoreText.text = score.ToString();
	}
}
