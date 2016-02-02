using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {
	public bool recording=true;
	private ReplaySystem[] replaySystems;

	void Start(){
		replaySystems = FindObjectsOfType<ReplaySystem>();
	}

	void Update () {
//		Debug.Log(CrossPlatformInputManager.GetButton("Fire1"));
		if (CrossPlatformInputManager.GetButton("Fire1")){
			if(recording){
				recording=false;
				foreach ( ReplaySystem system in replaySystems){
					system.lastRecordedFrame=0;
				}
			}
		
		}else{
			if(!recording){
			recording=true;
			foreach ( ReplaySystem system in replaySystems){
					system.lastRecordedFrame=0;
				}
			}
		}
	}
}
