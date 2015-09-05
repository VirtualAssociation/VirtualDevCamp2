using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private ViewCount _viewCount;
	private WebcamStateManager _webcamStateManager;
	private int _previousFearPoint = 0;
	private GameObject _comboGO;
	private float _lastComboTime = 0.0f;
	private bool _combo =false;

	void Awake(){
		_viewCount = GameObject.Find ("MainRoot").GetComponent<ViewCount> ();
		_webcamStateManager = GameObject.Find ("MainRoot").GetComponent<WebcamStateManager> ();
		_comboGO = GameObject.Find ("ComboPrefab");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (_combo && Time.time >= _lastComboTime + 1) {
			_combo = false;
		}
		_comboGO.SetActive (_combo);
	}

	public void addFearPoint(int fearPoint)
	{
		Debug.Log (fearPoint);

		//Apply the fear points
		switch (fearPoint) {
		case 0:
			_viewCount.setMultiplier (50.0f);
			_webcamStateManager.setState(WebcamStateEnum.bad);
			break;
		case 1:
			_viewCount.setMultiplier (150.0f);
			_webcamStateManager.setState(WebcamStateEnum.littlefear);
			break;
		case 2:
			_viewCount.setMultiplier (250.0f);
			_webcamStateManager.setState(WebcamStateEnum.bigfear);
			break;
		}

		//Check for combos
		if (fearPoint != 0 && fearPoint >= _previousFearPoint) {
			_lastComboTime = Time.time;
			_combo = true;
		}

		_previousFearPoint = fearPoint;
	}

}