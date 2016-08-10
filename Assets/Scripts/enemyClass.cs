﻿using UnityEngine;
using System.Collections;

public class enemyClass : baseClass {

	int targetStance;

	// Use this for initialization

	public void create (string name,int[] stats,int role,int attackType) {
		base.create(name,stats,role,attackType, false);
		//testing purposes, fix after
		hitChance = 90;
		dmg = 10;
	}

	public override void action()//default to attack highest threat party member
	{
		(manager.highestThreat ()).attacked (this);
	}
}