using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectScript : MonoBehaviour {

	public float aliveTime = 5f;
	private float CreatTime = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(CreatTime < aliveTime){
			CreatTime += Time.deltaTime;
		}
		else{
			Destroy(transform.gameObject);
		}
	}
}
