using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointCube : MonoBehaviour {
	public int point;
	public TextMesh Text;	// arithmetic rules
	public int index;

	GameController gameController = GameController.getInstance();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetPoint(string point){
		Text.text = point;
	}

	public bool CheckIsRight(){
		return gameController.CheckAnswer(index);
	}
}
