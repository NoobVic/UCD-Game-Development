using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {
	public int speed;
	public int BulletSpeed;
	public Rigidbody Bullet;
	public Transform FPonit;
	private float Horizontal;
	private float Vertical;
	private float Timer = 0;
	GameController gameController = GameController.getInstance();

	void Start () {
		// gameController.SetHpValue(3);	//Set up the initialized value
	}
	
	void Update () {
        // in this one, the move controlled by Horizontal and Vertical
		Horizontal=Input.GetAxis("Horizontal");
		Vertical=Input.GetAxis("Vertical");
        if (gameController.gameState == 0)	// if the game in running
		{
			transform.Translate(new Vector3(Horizontal,0,Vertical)*speed*Time.deltaTime);
			transform.Rotate(Vector3.up, Horizontal);
			if (Input.GetKeyDown(KeyCode.Space))
			{
				gameController.SetShotCount();

				Rigidbody clone;

				clone = (Rigidbody)Instantiate(Bullet,FPonit.position,FPonit.rotation);

				clone.velocity = transform.TransformDirection(Vector3.forward*BulletSpeed); 
			}
		}

		if (!gameController.CheckNormalModel() & gameController.gameState == 0)
		{
			Timer += Time.deltaTime;
			gameController.ShowLeftTime(60-Timer);
			if(Timer>60){
				gameController.SetGameState(1);
				gameController.ShowLeftTime(0.0f);
			}
		}
	}
}
