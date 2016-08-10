using UnityEngine;
using System.Collections;

public class baseDungeon : MonoBehaviour {

	public string name;
	public string desc;//desc of area, like hows its a forest or castle etc, lore stuff?
	public int lowLvl;
	public int highLvl;
	public int avgLvl;
	public enemyClass[] dps = new enemyClass[5];
	public enemyClass[] tanks = new enemyClass[5];
	public enemyClass[] healers = new enemyClass[5];
	public enemyClass[] supports = new enemyClass[5];
	public BattleManager manager;

	public enemyClass[] enemies = new  enemyClass[5];
	public allyClass[] allies = new allyClass[5];

	// Use this for initialization
	public void create (string name, string desc,int low,int high,int avg) {
		this.name = name;
		this.desc = desc;
		this.lowLvl = low;
		this.highLvl = high;
		this.avgLvl = avg;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void generateEnemys()
	{
		return;
	}

	public void generateLoot(int battleNum)//make new gear for battles
	{
		return;
	}
}
