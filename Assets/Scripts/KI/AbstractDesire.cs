using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractDesire {

	protected string name;
	protected float currentDegree=.1f;
	protected float maxDegree=5f;
	protected float defaultIncrease=0;
	protected float defaultDecrease=0;
	protected int severity=1;
	protected NPCAI owner;

	public string GetName ()
	{
		return name;
	}

	/// <summary>
	/// Returns the degree/relative severity of the desire
	/// </summary>
	/// <returns>The degree.</returns>
	public float GetDegree ()
	{
		return currentDegree/maxDegree;
	}

	public float GetTotalValue ()
	{
		return currentDegree;
	}

	public float GetMaxValue ()
	{
		return maxDegree;
	}

	public void SetMaxValue (float amount)
	{
		maxDegree=Mathf.Clamp(amount,.1f,float.PositiveInfinity);
	}

	public void SetSeverity(int severity)
	{
		this.severity=severity;
	}

	public int GetSeverity(){
		return severity;
	}

	public void IncreaseSeverity ()
	{
		currentDegree+=defaultIncrease;
	}

	public void IncreaseSeverity (float amount)
	{
		currentDegree+=amount;
	}

	public void SetDefaultIncrease (float amount)
	{
		defaultIncrease=amount;
	}

	public void ReduceSeverity ()
	{
		currentDegree-=defaultDecrease;
		if(currentDegree<0)
			currentDegree=.1f;
	}

	public void ReduceSeverity (float amount)
	{
		currentDegree-=amount;
		if(currentDegree<0)
			currentDegree=.1f;
	}

	public void SetDefaultReduction (float amount)
	{
		defaultDecrease=amount;
	}

	public void SetOwner(NPCAI owner){
		this.owner = owner;
	}

	public abstract Transform SearchWayToSatisfy ();
	public abstract void Execute();

	public class DesireComparer: IComparer<AbstractDesire>{
		public int Compare (AbstractDesire x, AbstractDesire y)
		{
			return (int)(x.GetDegree()*100-y.GetDegree()*100);
		}
	}
}
