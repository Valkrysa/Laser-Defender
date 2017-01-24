using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	private int score = 0;
	private Text text;
	
	void Start(){
		text = GetComponent<Text>();
		Reset();
	}
	
	public void Reset(){
		score = 0;
		text.text = "0";
	}
	
	public void Score(int points){
		score += points;
		text.text = score.ToString();
	}
	
}
