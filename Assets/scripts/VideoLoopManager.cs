using UnityEngine;
using System.Collections;


public class VideoLoopManager : MonoBehaviour {
	
	private Animator _loopAnimatior;
	private StateEnum _currentState;
	private int _level = 0;
	private float hSliderValue = 0.1f;

	void Awake () {
		//Retrieve the Game object
		_loopAnimatior = GameObject.Find ("LoopAnim").GetComponent<Animator>();
		_currentState = StateEnum.none;
	}

	void Start(){
		Debug.Log ("total lenght : " + getTotalLenghtOfClips ());
		_loopAnimatior.speed = 10.0f;
	}
	
	void Update () {
		AnimatorStateInfo state = _loopAnimatior.GetCurrentAnimatorStateInfo (0);
		if (state.shortNameHash == Animator.StringToHash (StateEnum.patafoin.ToString ())) {
			_currentState = StateEnum.patafoin;
			//Debug.Log ("patafoin");
		} else if (state.shortNameHash == Animator.StringToHash (StateEnum.plop.ToString ())) {
			_currentState = StateEnum.plop;
			//Debug.Log ("plop");
		} else if (state.shortNameHash == Animator.StringToHash (StateEnum.pif.ToString ())) {
			_currentState = StateEnum.pif;
			//Debug.Log ("pif");
		} else if (state.shortNameHash == Animator.StringToHash (StateEnum.patapon.ToString ())) {
			_currentState = StateEnum.patapon;
			//Debug.Log ("patapon");
		} else if (state.shortNameHash == Animator.StringToHash (StateEnum.pouf.ToString ())) {
			_currentState = StateEnum.pouf;
			//Debug.Log ("pouf");
		} else {
			_currentState = StateEnum.none;
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

	public StateEnum getCurrentState(){
		return _currentState;
	}

	public void changeSpeed(float newSpeed){
		if(_loopAnimatior != null) {
			_loopAnimatior.speed = newSpeed;
		}
	}

	/*void onGui(){

		hSliderValue = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), hSliderValue, 1.0F, 10.0F);

		if (GUI.Button (new Rect (10, 70, 50, 30), "Apply"))
			changeSpeed (hSliderValue);
	}*/

}
