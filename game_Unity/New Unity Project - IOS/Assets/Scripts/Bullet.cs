using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Bullet : MonoBehaviour {
	public float aliveTime = 5f;
	private float CreatTime = 0f;
	public GameObject effect;

	public AudioClip successAudio;
	public AudioClip FailAudio;
	GameController gameController = GameController.getInstance();
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

	void OnCollisionEnter (Collision collision) {
		pointCube pointCube = collision.transform.GetComponent<pointCube>();
		GameObject clone;

		clone = (GameObject)Instantiate(effect,transform.position,transform.rotation);
		
		if (collision.gameObject.name != "Terrain")
		{
			if (pointCube.CheckIsRight())
			{
				AudioManager.instance.AudioPlay(successAudio);
			}
			else{
				// In education mode, error will not be counted on HP
				if(!gameController.CheckNormalModel()){
					gameController.SetHpValue(gameController.HpValue-1);
				}
				AudioManager.instance.AudioPlay(FailAudio);
			}
			if (!gameController.CheckNormalModel())
			{
				gameController.CreatQuestion();
			}
			else{
				gameController.CreatNormalQuestion();
			}
		}

		Destroy(transform.gameObject);
	}
}
