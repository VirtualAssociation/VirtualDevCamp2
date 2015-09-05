using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameEvent : MonoBehaviour {

	public Sprite[] AnimationSprites;
	public int NumberOfLoops = 10;
	public float FrameDuration = 0.2f;
	public Vector3 ActingAnimationPosition;

	private int _currentLoop, _currentFrame, _frameCount;
	private float _currentTime;
	private bool _animDone = true;
	private Image _image;
	private Vector3 _initialPosition;

	void Start () {
		_currentLoop = 0;
		_currentFrame = 0;
		_frameCount = AnimationSprites.Length;

		_image = GetComponent<Image>();
		UpdateImage ();

		_initialPosition = GetComponent<Transform> ().position;
	}

	void Update () {

		if (_animDone)
			return;

		UpdatePosition ();

		float delta = Time.time - _currentTime;

		if (delta > FrameDuration)
		{
			if(_currentFrame+1 < _frameCount)
			{
				GoToNextFrame();
				_currentTime = Time.time;
			}
			else if (_currentLoop+1 < NumberOfLoops)
			{
				GoToNextLoop();
				_currentTime = Time.time;
			}
			else
			{
				StopAnimation();
			}
		}
	}

	void UpdateImage()
	{
		_image.sprite = AnimationSprites [_currentFrame];
	}

	void UpdatePosition()
	{
		Transform trf = GetComponent<Transform>();
		trf.position = _initialPosition + ActingAnimationPosition;
	}

	public void StartAnimation()
	{
		_animDone = false;
	}

	void StopAnimation()
	{
		_animDone = true;
		_currentFrame = 0;
		_currentLoop = 0;
		_image.sprite = AnimationSprites [_currentFrame];
		Transform trf = GetComponent<Transform>();
		trf.position = _initialPosition;
	}

	void GoToNextFrame()
	{
		_currentFrame += 1;
		UpdateImage ();
	}

	void GoToNextLoop()
	{
		_currentLoop += 1;
		_currentFrame = 0;
		UpdateImage ();
	}

	void DoEventAction()
	{
		Debug.Log ("Player is clicking on " + "");
	}


}