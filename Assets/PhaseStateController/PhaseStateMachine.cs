using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PhaseStateMachine : MonoBehaviour
{
	PhaseBase currentPhase = null;
	[SerializeField]
	List<PhaseBase> phases = new List<PhaseBase>();

	public PhaseBase CurrentPhase {
		get { return currentPhase; }
	}

	/// <summary>
	/// Registers the phase.
	/// </summary>
	/// <param name="phase">Phase.</param>
	public void RegisterPhase (PhaseBase phase) {
		// Error Check
		if (Find (phase.PhaseName) != null) {
			Debug.LogError ("'" + phase.PhaseName + "' is already registed"); 
			return;
		} 

		phases.Add (phase);
	}

	/// <summary>
	/// Unredisters the phase.
	/// </summary>
	/// <param name="phase">Phase.</param>
	public void UnredisterPhase (PhaseBase phase) {
		phases.Remove (phase);

		//Error Check
		if (Find (phase.PhaseName) != null) {
			Debug.LogError ("failed to unregister '" + phase.PhaseName + "'"); 
		}
	}

	/// <summary>
	/// Goto the specified phaseName.
	/// </summary>
	/// <param name="phaseName">Phase name.</param>
	public bool Goto (string phaseName) {
		PhaseBase phase = Find (phaseName);

		if (phase == null) {
			Debug.LogWarning ("failed to move to phase " + phaseName);
			return false;
		}

		return Goto(phase);
	}

	/// <summary>
	/// Goto the specified nextPhase.
	/// </summary>
	/// <param name="nextPhase">Next phase.</param>
	public bool Goto (PhaseBase nextPhase){
		if (currentPhase != null) {
			currentPhase.OnExit (nextPhase);
		}

		PhaseBase prevPhase = currentPhase;
		currentPhase = nextPhase;

		if (nextPhase != null) {
			nextPhase.OnEnter (prevPhase);
		}

		return true;
	}

	/// <summary>
	/// Find the specified phaseName.
	/// </summary>
	/// <param name="phaseName">Phase name.</param>
	PhaseBase Find (string phaseName) {
		foreach (PhaseBase p in phases) {
			if(p.PhaseName == phaseName) {
				return p;
			}
		}

		return null;
	}
}
