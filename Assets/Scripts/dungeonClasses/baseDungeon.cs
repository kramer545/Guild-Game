using UnityEngine;
using System.Collections;

public class baseDungeon : MonoBehaviour {

	public string name;
	public string desc;//desc of area, like hows its a forest or castle etc, lore stuff?
	public int lowLvl;
	public int highLvl;
	public int avgLvl;
	public enemyClass[] dps;
	public enemyClass[] tanks;
	public enemyClass[] healers;
	public enemyClass[] supports;
	public BattleManager manager;

	public GameObject[] enemies = new GameObject[5];
	public GameObject[] allies = new GameObject[5];

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
