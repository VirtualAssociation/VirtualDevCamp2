using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private ViewCount _viewCount;

	void Awake(){
		_viewCount = GameObject.Find ("MainRoot").GetComponent<ViewCount> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void addViews(int numberOfViews){
		_viewCount.addViews (numberOfViews);
	}

	public void addFearPoint(int fearPoint)
	{
		Debug.Log (fearPoint);
	}

}