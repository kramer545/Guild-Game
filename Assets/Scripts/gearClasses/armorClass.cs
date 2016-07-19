using UnityEngine;
using System.Collections;

public class armorClass : gearClass {
	
	public int physDef;
	public int magDef;
	public int dodgeBonus;
	public int armorType;

	// Use this for initialization
	public void create (int rarity,string name,int lvlReq,int[] bonusStats,int physDef,int magDef,int dodgeBonus,int armorType) {
		base.create(rarity,name,lvlReq,bonusStats);
		this.physDef = physDef;
		this.magDef = magDef;
		this.dodgeBonus = dodgeBonus;
		this.armorType = armorType;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool canBeEquipped(int lvl,int armorType)
	{
		if(base.canBeEquipped(lvl))
		{
			if (armorType >= this.armorType)
				return true;
		}
		return false;
	}
}
