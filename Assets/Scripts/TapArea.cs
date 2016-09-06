using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TapArea : MonoBehaviour {

	public GameObject ScoreText;

	void OnMouseDown() {
		ScoreText.GetComponent<GameScore>().Score += 1;
	}
}