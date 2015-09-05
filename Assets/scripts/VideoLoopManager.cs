using UnityEngine;
using System.Collections;


public class VideoLoopManager : MonoBehaviour {
	
	private Animator _loopAnimatior;
	private StateEnum _currentState;

	void Awake () {
		//Retrieve the Game object
		_loopAnimatior = GameObject.Find ("LoopAnim").GetComponent<Animator>();
		_currentState = StateEnum.none;
	}


	void Update () {
		AnimatorStateInfo state = _loopAnimatior.GetCurrentAnimatorStateInfo (0);
		if (state.shortNameHash == Animator.StringToHash (StateEnum.patafoin.ToString ())) {
			_currentState = StateEnum.patafoin;
			Debug.Log ("patafoin");
		} else if (state.shortNameHash == Animator.StringToHash (StateEnum.plop.ToString ())) {
			_currentState = StateEnum.plop;
			Debug.Log ("plop");
		} else if (state.shortNameHash == Animator.StringToHash (StateEnum.pif.ToString ())) {
			_currentState = StateEnum.pif;
			Debug.Log ("pif");
		} else if (state.shortNameHash == Animator.StringToHash (StateEnum.patapon.ToString ())) {
			_currentState = StateEnum.patapon;
			Debug.Log ("patapon");
		} else if (state.shortNameHash == Animator.StringToHash (StateEnum.pouf.ToString ())) {
			_currentState = StateEnum.pouf;
			Debug.Log ("pouf");
		} else {
			_currentState = StateEnum.none;
		}
	}

}
