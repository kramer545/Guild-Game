using UnityEngine;
using System.Collections;

public class gearClass : MonoBehaviour {

	public int rarity;
	public string name;
	public int[] bonusStats;
	public int lvlReq;

	// Use this for initialization
	public void Start (int rarity,string name,int lvlReq,int[] bonusStats) {
		this.rarity = rarity;
		this.name = name;
		this.lvlReq = lvlReq;
		for (int x = 0; x < 11; x++)
			this.bonusStats [x] = bonusStats [x];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool canBeEquipped(int lvl)
	{
		if (lvl < lvlReq)
			return false;
		else
			return true;
	}
}
