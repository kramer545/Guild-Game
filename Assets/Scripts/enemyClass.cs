using UnityEngine;
using System.Collections;

public class enemyClass : baseClass {

	int targetStance;

	// Use this for initialization
	void Start () {
		
	}

	public void action()//default to attack highest threat party member
	{
		(manager.highestThreat ()).attacked (this);
	}
}