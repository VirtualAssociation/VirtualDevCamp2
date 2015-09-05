using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private ViewCount _viewCount;
	private WebcamStateManager _webcamStateManager;

	void Awake(){
		_viewCount = GameObject.Find ("MainRoot").GetComponent<ViewCount> ();
		_webcamStateManager = GameObject.Find ("MainRoot").GetComponent<WebcamStateManager> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addFearPoint(int fearPoint)
	{
		Debug.Log (fearPoint);

		switch (fearPoint) {
		case 0:
			_viewCount.setMultiplier (20.0f);
			_webcamStateManager.setState(WebcamStateEnum.bad);
			break;
		case 1:
			_viewCount.setMultiplier (100.0f);
			_webcamStateManager.setState(WebcamStateEnum.littlefear);
			break;
		case 2:
			_viewCount.setMultiplier (200.0f);
			_webcamStateManager.setState(WebcamStateEnum.bigfear);
			break;
		}
	}

}