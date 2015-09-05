using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WebcamStateManager : MonoBehaviour {
	
	private Animator _loopAnimatior;
	private GameObject _gamerGO;
	private WebcamStateEnum _currentState;
	private Dictionary<WebcamStateEnum, Sprite> _gamerSpriteList;

	void Awake () {
		//Retrieve the Game object
		_gamerGO = GameObject.Find ("GamerAnim");
		_loopAnimatior = GameObject.Find ("WebcamAnim").GetComponent<Animator>();
		_currentState = WebcamStateEnum.none;

		//Load the sprite for the gamer
		_gamerSpriteList = new Dictionary<WebcamStateEnum, Sprite> ();
		Sprite bigFearSprite = Resources.Load<Sprite> ("Gamer/gamer_fear") as Sprite;
		Sprite littleFearSprite = Resources.Load<Sprite> ("Gamer/gamer_fear_medium") as Sprite;
		Sprite idle1 = Resources.Load<Sprite> ("Gamer/gamer_idle_f1");
		Sprite idle2 = Resources.Load<Sprite> ("Gamer/gamer_idle_f2") as Sprite;
		Sprite nope1 = Resources.Load<Sprite> ("Gamer/gamer_nope_1") as Sprite;
		Sprite nope2 = Resources.Load<Sprite> ("Gamer/gamer_nope_2") as Sprite;

		_gamerSpriteList.Add (WebcamStateEnum.bigfear, bigFearSprite);
		_gamerSpriteList.Add (WebcamStateEnum.littlefear, littleFearSprite);
		_gamerSpriteList.Add (WebcamStateEnum.idle1, idle1);
		_gamerSpriteList.Add (WebcamStateEnum.idle2, idle2);
		_gamerSpriteList.Add (WebcamStateEnum.bad, nope1);
		_gamerSpriteList.Add (WebcamStateEnum.bad2, nope2);
	
	}

	void Start(){
		_loopAnimatior.speed = 10.0f;
	}
	
	void Update () {
		AnimatorStateInfo state = _loopAnimatior.GetCurrentAnimatorStateInfo (0);
		if (state.shortNameHash == Animator.StringToHash (WebcamStateEnum.idle1.ToString ())) {
			_currentState = WebcamStateEnum.idle1;
		} else if (state.shortNameHash == Animator.StringToHash (WebcamStateEnum.idle2.ToString ())) {
			_currentState = WebcamStateEnum.idle2;
			setState(WebcamStateEnum.bigfear);
		} else if (state.shortNameHash == Animator.StringToHash (WebcamStateEnum.littlefear.ToString ())) {
			_currentState = WebcamStateEnum.littlefear;
		} else if (state.shortNameHash == Animator.StringToHash (WebcamStateEnum.bigfear.ToString ())) {
			_currentState = WebcamStateEnum.bigfear;
		} else if (state.shortNameHash == Animator.StringToHash (WebcamStateEnum.bad.ToString ())) {
			_currentState = WebcamStateEnum.bad;
		} else if (state.shortNameHash == Animator.StringToHash (WebcamStateEnum.bad2.ToString ())) {
			_currentState = WebcamStateEnum.bad2;
		} else {
			_currentState = WebcamStateEnum.none;
		}
		//Update the state of the gamer
		if (_gamerGO != null) {
			_gamerGO.GetComponent<SpriteRenderer> ().sprite = _gamerSpriteList [_currentState];
		} else {
			Debug.Log("gamer is null");
		}
	}

	public float getTotalLenghtOfClips(){
		float length = 0.0f;
		if(_loopAnimatior != null) {
			UnityEditor.Animations.AnimatorController ac = _loopAnimatior.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;
			AnimationClip[] clips = ac.animationClips;
			for(int i = 0; i < clips.Length; i++) {
				length += clips[i].length;
			}
		}
		return length;
	}

	public WebcamStateEnum getCurrentState(){
		return _currentState;
	}

	public void setState(WebcamStateEnum state){
		_loopAnimatior.speed = 1.0f;
		_loopAnimatior.CrossFade (state.ToString (), 0f);
	}

	public void changeSpeed(float newSpeed){
		if(_loopAnimatior != null) {
			_loopAnimatior.speed = newSpeed;
		}
	}

}
