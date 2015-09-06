using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public float chrono = 120;
	private GameObject _losingPanel;

	void Start () {
		_losingPanel = GameObject.Find ("LosingPanel");
		_losingPanel.SetActive (false);
	}

	public void StartGame(){

	}

	void Update(){
		if (Time.time >= chrono) {
			TimeEnd();
		}
	}


	public void TimeEnd(){
		string numberofviews = GameObject.Find ("NumberOfViews").GetComponent<UnityEngine.UI.Text>().text;
		GameObject.Find("MainRoot").GetComponent<ViewCount>().stopCount ();
		_losingPanel.SetActive (true);
		GameObject.Find ("Main Camera").GetComponent<AudioSource> ().Stop ();
		UnityEngine.UI.Text text = GameObject.Find ("score").GetComponent<UnityEngine.UI.Text>();

		text.text = " Your score : " + numberofviews + " views";

	}
}


