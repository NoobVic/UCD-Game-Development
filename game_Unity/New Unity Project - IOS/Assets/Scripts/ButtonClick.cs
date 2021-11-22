using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{

    GameController gameController = GameController.getInstance();

    public void fireCount()
    {
        if (gameController.gameState == 0)
        {
            gameController.FireCount++;
        }
    }
}
