using UnityEngine;
using System.Collections;

public class Warrior : classClass {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void create()
	{
		className = "Warrior";
		classNum = 0;
		attackType = 0;
		canShield = true;
		canHeal = false;
		canSupport = false;
	}

	public void levelUp(int level)//what stats level up by what amount
	{
		unit.stats [0] += 1;//lvl
		unit.stats [1] = 0;//refresh exp bar
		unit.stats [2] += 119; //9520 hp at 80
		unit.stats [3] += 20;//1600 mp at 80
		if (level % 2 == 0)//120 str at 80
			unit.stats [4] += 2;
		else
			unit.stats [4] += 1;
		if (level % 2 == 0)//120 def at 80
			unit.stats [5] += 2;
		else
			unit.stats [5] += 1;
		unit.stats [6] += 1;//80 spd at 80
		if (level % 3 == 0)//26 mag
			unit.stats [7] += 1;
		if (level % 2 == 0)//40 Mdef
			unit.stats [8] += 1;
		unit.stats [9] += 1;//80 luck
	}

	public baseClass generateUnit(int level,bool friendly)//make a unit of this type
	{
		create ();
		unit = new baseClass ();
		unit.create (generateName (), new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, attackType, friendly, classNum);
		unit.currClass = this;
		for (int x = 0; x < level; x++)
			levelUp (x+1);
		return unit;
	}
}
