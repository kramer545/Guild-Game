using UnityEngine;
using System.Collections;

public class shieldClass : weaponClass {

	public int blockBonus;
	public int physDef;
	public int magDef;

	// Use this for initialization
	public void create (int rarity,string name,int lvlReq,int[] bonusStats,int physDmg,int magDmg,int blockBonus,int physDef,int magDef) {
		base.create(rarity,name,lvlReq,bonusStats);
		this.physDmg = physDmg;
		this.magDmg = magDmg;
		this.accuracy = 0;//not used in accuracy calculations
		this.weaponType = 5;//TODO number weapon types, change this number to the shield type
		this.physDef = physDef;
		this.magDef = magDef;
	}

	// Update is called once per frame
	void Update () {

	}

	public bool canBeEquipped(int lvl,int weaponType)
	{
		if(base.canBeEquipped(lvl))
		{
			if (weaponType >= this.weaponType)
				return true;
		}
		return false;
	}
}