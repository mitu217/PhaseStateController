using UnityEngine;
using System.Collections;

public class SamplePhaseController : MonoBehaviour {
	static SamplePhaseController instance;

	public SamplePhaseController Instance {
		get {
			if (instance == null) {
				instance = (SamplePhaseController)FindObjectOfType (typeof(SamplePhaseController));
				if (instance == null) {
					Debug.LogWarning (typeof(SamplePhaseController) + "is nothing");
				}
			}

			return instance;
		}
	}

	PhaseStateMachine stateMahine = new PhaseStateMachine ();
	public PhaseStateMachine StateMachine {
		get {
			return stateMahine;
		}
	}

	void Start () {
		// 最初のステートに遷移させる
		//stateMahine.Goto ("Init");
	}

	void OnDestroy () {
		instance = null;
	}
}
