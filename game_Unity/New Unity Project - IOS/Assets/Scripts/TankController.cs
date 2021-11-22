using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        Horizontal = gameController.Hori;
        Vertical = gameController.Verti;
        // An error raised here because the joystick value cannot be obtained.
        if (gameController.gameState == 0)	// if the game in running
		{
			transform.Translate(new Vector3(Horizontal,0,Vertical)*speed*Time.deltaTime);
			transform.Rotate(Vector3.up, 0.1f * Horizontal);
            System.Console.WriteLine(Horizontal);
            if (gameController.FireCount > 0)
			{
                gameController.FireCount--;

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
