using UnityEngine;
using System.Collections;


public class WebcamStateManager : MonoBehaviour {
	
	private Animator _loopAnimatior;
	private WebcamStateEnum _currentState;
	private int _level = 0;
	private float hSliderValue = 0.1f;

	void Awake () {
		//Retrieve the Game object
		_loopAnimatior = GameObject.Find ("WebcamAnim").GetComponent<Animator>();
		_currentState = WebcamStateEnum.none;
	}

	void Start(){
		Debug.Log ("total lenght : " + getTotalLenghtOfClips ());
		_loopAnimatior.speed = 10.0f;
	}
	
	void Update () {
		AnimatorStateInfo state = _loopAnimatior.GetCurrentAnimatorStateInfo (0);
		if (state.shortNameHash == Animator.StringToHash (WebcamStateEnum.idle1.ToString ())) {
			_currentState = WebcamStateEnum.idle1;
			//Debug.Log ("patafoin");
		} else if (state.shortNameHash == Animator.StringToHash (WebcamStateEnum.idle2.ToString ())) {
			_currentState = WebcamStateEnum.idle2;
			//Debug.Log ("plop");
		} else if (state.shortNameHash == Animator.StringToHash (WebcamStateEnum.littlefear.ToString ())) {
			_currentState = WebcamStateEnum.littlefear;
			//Debug.Log ("pif");
		} else if (state.shortNameHash == Animator.StringToHash (WebcamStateEnum.bigfear.ToString ())) {
			_currentState = WebcamStateEnum.bigfear;
			//Debug.Log ("patapon");
		} else if (state.shortNameHash == Animator.StringToHash (WebcamStateEnum.bad.ToString ())) {
			_currentState = WebcamStateEnum.bad;
			//Debug.Log ("pouf");
		} else if (state.shortNameHash == Animator.StringToHash (WebcamStateEnum.bad2.ToString ())) {
			_currentState = WebcamStateEnum.bad2;
			//Debug.Log ("pouf");
		} else {
			_currentState = WebcamStateEnum.none;
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

	public void changeSpeed(float newSpeed){
		if(_loopAnimatior != null) {
			_loopAnimatior.speed = newSpeed;
		}
	}

}
