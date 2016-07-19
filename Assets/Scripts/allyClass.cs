using UnityEngine;
using System.Collections;

public class allyClass : baseClass {


	public int threat;
	public const int threatBase = 10;
	public double threatMultiplier;
	public int[] baseStats;

	public weaponClass weaponMain;
	public weaponClass weaponOff;
	public armorClass helmet;
	public armorClass chest;
	public armorClass shoulder;
	public armorClass gloves;
	public armorClass pants;
	public armorClass boots;
	public gearClass ringOne;
	public gearClass ringTwo;
	//maybe add more rings?
	public gearClass amulet;

	// Use this for initialization
	public void create (string name, int[] stats, int role,int attackType) {
		base.create( name,stats,role,attackType, true);
	}

	public void updateChar()
	{
		if ((weaponOff == null) || (weaponOff is shieldClass))
		{
			hitChance = weaponMain.accuracy;
		}
		else
		{
			hitChance = (weaponMain.accuracy + weaponOff.accuracy) / 2;
		}
	}

	// Update is called once per frame
	void Update () {
	}

	public void createingBuff()
	{
		return;
	}

	public void action()
	{
		base.action ();
		threat += 10;
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

	public int dmgCalc() {
		if(attackType == 0)//phys attack
		{
			dmg =(int)(((stats [4] * physMult) + weaponMain.physDmg + weaponOff.physDmg) - stats [5]);
			if (dmg < (stats [0] * 10))//if dmg is below attacker level times 10, set it to min dmg
				dmg = (stats [0] * 10);

		}
		else if (attackType == 1)//magic attack
		{
			dmg = (int)(((stats [7] * magMult) + weaponMain.magDmg + weaponOff.magDmg) - stats [8]);
			if (dmg < (stats [0] * 10))//if dmg is below attacker level times 10, set it to min dmg
				dmg = (stats [0] * 10);
		}
		else//both phys and magic, TODO take another look at weapon Dmg for both phys and mag
		{
			dmg = (int)(((stats [4] * physMult) + weaponMain.physDmg) - stats [5]);
			if (dmg < 0)//if phys dmg is below zero, set to min dmg
				dmg = (int)((stats [0] * 10) / 2);
			if ((((stats [7] * magMult) + weaponMain.magDmg+weaponOff.magDmg) - stats [8]) > 0)
				dmg += (int)(((stats [7] * magMult) + weaponMain.magDmg+weaponOff.magDmg) - stats [8]);
			else
				dmg +=(int)((stats [0] * 10) / 2);
		}
		Debug.Log (charName + " will do " + dmg + " dmg");
		return dmg;
	}

	public void attacked(baseClass attacker)
	{
		base.attacked (attacker);
		threat -= 10;
	}
}
