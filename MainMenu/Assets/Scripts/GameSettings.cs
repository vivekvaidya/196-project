using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour {

	public Toggle TakenWins; //boolean for last taken wins
	public bool take; 


	public Toggle Player; //boolean for double vs single player
	public bool playerStatus;


	public Dropdown dropdown; //int for difficulty
	int difficulty; //0,1,2

	public Dropdown BSize; //board size
	int boardSize; //0,1,2


	
	// Update is called once per frame
	void Update () {
		take = TakenWins.isOn;
		playerStatus = Player.isOn;
		difficulty = dropdown.value; //0,1,2
		boardSize = BSize.value; //0,1,2
	}
}
