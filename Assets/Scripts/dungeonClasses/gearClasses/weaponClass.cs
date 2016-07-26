using UnityEngine;
using System.Collections;

public class weaponClass : gearClass {

	public int physDmg;
	public int magDmg;
	public int accuracy;
	public int weaponType;

	// Use this for initialization
	public void create (int rarity,string name,int lvlReq,int[] bonusStats,int physDmg,int magDmg,int accuracy,int weaponType) {
		base.create(rarity,name,lvlReq,bonusStats);
		this.physDmg = physDmg;
		this.magDmg = magDmg;
		this.accuracy = accuracy;
		this.weaponType = weaponType;
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