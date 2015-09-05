using UnityEngine;
using System.Collections;

public class ViewCount : MonoBehaviour{

	private float _views;
	private float _nextTimeToResetMult;
	private UnityEngine.UI.Text _viewDisplay;

	public float _bonusMult;

	// Use this for initialization
	void Start () {
		_bonusMult = 1.0f;
		_views = 1;
		_viewDisplay = GameObject.Find ("NumberOfViews").GetComponent<UnityEngine.UI.Text> ();
		if(_viewDisplay == null)
			Debug.Log ("display is null");
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= _nextTimeToResetMult) {
			Debug.Log("reset mult");
			_bonusMult = 10.0f;
		}
		_views =  _views + Time.deltaTime * _bonusMult;
		_viewDisplay.text = Mathf.Floor(_views).ToString ();
	}

	public void setMultiplier(float mult){
		_bonusMult = mult;
		_nextTimeToResetMult = Time.time + 5;
	}
}
