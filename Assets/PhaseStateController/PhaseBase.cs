using UnityEngine;
using System.Collections;

public interface PhaseBase 
{
	/// <summary>
	/// フェーズの名称
	/// </summary>
	string PhaseName {
		get;
	}
		
	/// <summary>
	/// フェーズに入った時に呼ばれる
	/// </summary>
	/// <param name="prevPhase">Previous phase.</param>
	void OnEnter (PhaseBase prevPhase);

	/// <summary>
	/// フェーズを出るときに呼ばれる
	/// </summary>
	/// <param name="nextPhase">Next phase.</param>
	void OnExit (PhaseBase nextPhase);
}
