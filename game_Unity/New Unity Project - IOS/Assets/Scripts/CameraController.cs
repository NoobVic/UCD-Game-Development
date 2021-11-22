using UnityEngine;
using System.Collections;
// View is the TPS mode
public class CameraController : MonoBehaviour 
{
    public Transform target;
    public float distanceUp=3f;
    public float distanceAway = 5f;
    public float smooth = 2f;
    public float camDepthSmooth = 5f;
	GameController gameController = GameController.getInstance();
    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update () 
    {   
        if (!target & gameController.CurTank )
        {
            target = gameController.CurTank.transform.Find("CameraFocus").transform;
        }
       // Use the scroll for camera close control
        if ((Input.mouseScrollDelta.y < 0 && Camera.main.fieldOfView >= 3) || Input.mouseScrollDelta.y > 0 && Camera.main.fieldOfView <= 80)
        {
            Camera.main.fieldOfView += Input.mouseScrollDelta.y * camDepthSmooth * Time.deltaTime;
        }
    }

    void LateUpdate()
    {
        if (target)
        {
            //Position
            Vector3 disPos = target.position + Vector3.up * distanceUp - target.forward * distanceAway;   transform.position=Vector3.Lerp(transform.position,disPos,Time.deltaTime*smooth);
            //Direction
            transform.LookAt(target.position);
        }
    }
}
