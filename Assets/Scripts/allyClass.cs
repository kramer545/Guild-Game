using UnityEngine;
using System.Collections;

public class allyClass : baseClass {


	public int threat;
	public const int threatBase = 10;
	public double threatMultiplier;

	// Use this for initialization
	void Start () {
		threatMultiplier = 1;
	}

	// Update is called once per frame
	void Update () {

	}

	public void startingBuff()
	{
		
	}

	public void action()
	{
		
	}

	public void incrementThreat(int action)
	{
		if(action == 0)//basic attack
		{
			threat += (int)(threatBase*threatMultiplier);
		}

		else if (action == 1) //defense
		{
			threat -= (int)((threatBase*threatMultiplier) / 2);
		}

		else//unique, based on ability,ect cannot be 0 or 1 though
		{
			threat += (int)(action* threatMultiplier);
		}
	}

	public void defend()
	{
		threat = (int)(this.threat * 0.9);
		armor = (int)(armor * 1.2);
		defended = true;
	}
}
