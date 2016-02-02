using UnityEngine;
using System.Collections;

public class CameraPivotPoint : MonoBehaviour {
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("PlayerBall");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position;
	}
}
