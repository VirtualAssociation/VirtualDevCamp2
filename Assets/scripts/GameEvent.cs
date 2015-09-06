using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameEvent : MonoBehaviour {


	public GameActionEnum ActionType;
	public Sprite[] AnimationSprites;
	public int NumberOfLoops = 10;
	public float FrameDuration = 0.2f;
	public Vector3 ActingAnimationPosition;

	private GameObject _catIdle;
	private Texture2D _cursorTexture;
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

		_cursorTexture = Resources.Load ("cursor") as Texture2D;
		if (ActionType == GameActionEnum.GA_CAT) {
			_catIdle = GameObject.Find ("cat_idle");
			_image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0); 
			_catIdle.SetActive (true);
		}
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

		if (ActionType == GameActionEnum.GA_CAT) {
			_image.color = new Color(_image.color.r, _image.color.g, _image.color.b,1); 
			_catIdle.SetActive(false);
		}
		_animDone = false;
		VideoGameScreen screen = (VideoGameScreen)(GameObject.Find ("VideoGameScreen").GetComponent ("VideoGameScreen"));
		screen.ApplyEvent (ActionType);
	}

	void StopAnimation()
	{
		if (ActionType == GameActionEnum.GA_CAT) {
			_image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0); 
			_catIdle.SetActive(true);
		}
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

	public void OnMouseOver(){
		Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.Auto);
	}

	public void OnMouseExit(){
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}


}