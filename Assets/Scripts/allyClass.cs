using UnityEngine;
using System.Collections;

public class allyClass : baseClass {


	public int threat;
	public const int threatBase = 10;
	public float threatMultiplyer;

	// Use this for initialization
	void Start () {
		threatMulipler = 1;
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
			threat += (threatBase*threatMulipler);
		}

		else if (action == 1) //defense
		{
			threat -= (int)((threatBase*threatMulipler) / 2);
		}

		else//unique, based on ability,ect cannot be 0 or 1 though
		{
			threat += (action* threatMulipler);
		}
	}
}
