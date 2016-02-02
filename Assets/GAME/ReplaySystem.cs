using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour {

	private const int bufferFrames = 1000;
	private MyKeyFrame[] keyFrames = new MyKeyFrame [bufferFrames];
	private Rigidbody rigidBody;
	public int lastRecordedFrame=0;

	private GameManager gameManager;

	void Start(){
		rigidBody = GetComponent<Rigidbody>();
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	} 

	void Record ()
	{
		Debug.Log ("Recording");
		rigidBody.isKinematic = false;
		int frame = lastRecordedFrame;
		keyFrames [frame] = new MyKeyFrame (Time.time, transform.position, transform.rotation);
		lastRecordedFrame +=1;
		if(frame>bufferFrames){lastRecordedFrame=0;}

	}	 

	void Playback (){
		Debug.Log ("Playing Back");
		rigidBody.isKinematic = true;
		int frame =lastRecordedFrame;

		if(frame>bufferFrames){frame=0;lastRecordedFrame=0;}
		if(keyFrames[frame] != null){
		transform.position = keyFrames[frame].position;
		transform.rotation = keyFrames[frame].rotation;
			lastRecordedFrame += 0;
		}else{frame=0;lastRecordedFrame=0;}
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(gameManager.recording);
		if (!gameManager.recording){
			Playback();
		}else{
			Record();
		}
	}
}

public class MyKeyFrame {
	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;

	public MyKeyFrame (float aTime, Vector3 aPosition, Quaternion aRotation) {
		frameTime = aTime;
		position = aPosition;
		rotation = aRotation;

	}

}
