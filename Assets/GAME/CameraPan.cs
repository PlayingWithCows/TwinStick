using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class CameraPan : MonoBehaviour {

	private GameObject player;
	public Transform cameraPivotPoint;
	private GameObject camParent;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("PlayerBall");
		transform.LookAt(player.transform);

		if (GameObject.Find ("CameraPivotPoint")){
			cameraPivotPoint = GameObject.Find ("CameraPivotPoint").transform;	
		}else {
			camParent = new GameObject ("CameraPivotPoint"); 
			camParent.transform.position = player.transform.position;
			transform.parent = camParent.transform; 
		}
			

		}
	
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(player.transform);
		cameraPivotPoint.transform.Rotate (Vector3.up, (CrossPlatformInputManager.GetAxis("RHoriz")*70)*Time.deltaTime, Space.World);

	}


}
