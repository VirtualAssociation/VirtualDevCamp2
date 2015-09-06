using UnityEngine;
using System.Collections;

public class ViewCount : MonoBehaviour{

	private float _views;
	private float _nextTimeToResetMult;
	private UnityEngine.UI.Text _viewDisplay;
	private GameObject _winningScreen;

	public float _bonusMult;

	// Use this for initialization
	void Start () {
		_winningScreen = GameObject.Find ("WinningPanel");
		_winningScreen.SetActive (false);
		_bonusMult = 20.0f;
		_views = 1;
		_viewDisplay = GameObject.Find ("NumberOfViews").GetComponent<UnityEngine.UI.Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= _nextTimeToResetMult) {
			_bonusMult = 20.0f;
		}
		_views =  _views + Time.deltaTime * _bonusMult;
		_viewDisplay.text = Mathf.Floor(_views).ToString ();

		if(_views >= 2345678){
			Debug.Log("Win");
			win();
		}
	}

	public void setMultiplier(float mult){
		_bonusMult = mult;
		_nextTimeToResetMult = Time.time + 5;
	}

	public void win(){
		GameObject.Find ("MainCamera").GetComponent<AudioSource> ().Stop ();
		_winningScreen.SetActive (true);
	}

	public void QuitGame(){
		Debug.Log ("Quit");
		Application.Quit ();
	}
}
