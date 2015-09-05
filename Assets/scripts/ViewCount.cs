using UnityEngine;
using System.Collections;

public class ViewCount : MonoBehaviour{

	private float _views;
	private UnityEngine.UI.Text _viewDisplay;

	public float _bonusMult;

	// Use this for initialization
	void Start () {
		_bonusMult = 10.0f;
		_views = 1;
		_viewDisplay = GameObject.Find ("NumberOfViews").GetComponent<UnityEngine.UI.Text> ();
		if(_viewDisplay == null)
			Debug.Log ("display is null");
	}
	
	// Update is called once per frame
	void Update () {
		_views =  _views + Time.deltaTime * _bonusMult;
		_viewDisplay.text = Mathf.Floor(_views).ToString ();
	}

	public void addViews(int viewNumber){
		_views = _views + viewNumber;
	}
}
