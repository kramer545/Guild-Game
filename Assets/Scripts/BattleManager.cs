using UnityEngine;
using System.Collections.Generic;
using System;

public class BattleManager : MonoBehaviour  {

	public baseClass[] party = new baseClass[5];
	public baseClass[] enemys = new baseClass[5];
	//split enemys into subsections for tactics
	public allyClass[] dps = new allyClass[5];
	public allyClass[] healers = new allyClass[5];
	public allyClass[] supports = new allyClass[5];
	public allyClass[] tanks = new allyClass[5];

	public enemyClass[] enemyDps = new enemyClass[5];
	public enemyClass[] enemyHealers = new enemyClass[5];
	public enemyClass[] enemySupports = new enemyClass[5];
	public enemyClass[] enemyTanks = new enemyClass[5];

	public baseClass targetEnemy;
	public baseClass targetThreat;
	public int command;
	Queue <baseClass> turnOrder = new Queue<baseClass>();
	baseClass curUnit;
	public bool nextTurn;//used to create the next turn/units actions
	bool battleOver;
	public GameObject DmgText;

	// Use this for initialization 
	void Start(){
		DmgText.GetComponent<UnityEngine.UI.Text> ().text = "";
	}

	public void create () {
		nextTurn = false;
		battleOver = false;
		applyPassives();//create with inital buffs/passive effects
		makeTurnOrder();
		command = 0;//Auto act
		//load art/music assets
		//create turns
		StartCoroutine (turnWait ());
	}
	
	// Update is called once per frame
	void Update () {
		if(nextTurn)
		{
			nextTurn = false;
			curUnit = turnOrder.Dequeue();
			curUnit.action();
			if (turnOrder.Count < 8)
			{
				makeTurnOrder();
			}
			StartCoroutine (turnWait());
			//curUnit.action will set nextTurn to true when it is done(has art efffects/etc to do)
		}

		if (battleOver)
		{
			//TODO
			nextTurn = false;
			return;
		}
	}

	IEnumerator<UnityEngine.WaitForSeconds> turnWait()
	{
		yield return new WaitForSeconds (1);
		nextTurn = true;
	}


	void applyPassives()
	{
		foreach (baseClass x in party)
		{
			if(x!=null)
				x.createingBuff ();
		}

		foreach (baseClass x in enemys)
		{
			if (x == null)
				continue;
			x.createingBuff();
			int a = 0;
			int b = 0;
			int c = 0;
			int d = 0;
			if (targetEnemy == null)//find lowest HP enemy, first target
				targetEnemy = x;
			else if (x.stats [2] > targetEnemy.stats [2])
				targetEnemy = x;

			if(x.role == 0)
			{
				dps [a] = x;
				a++;
			}
			else if (x.role == 4)
			{
				tanks [b] = x;
				b++;
			}
			else if (x.role == 8)
			{
				healers [c] = x;
				c++;
			}
			else
			{
				supports [d] = x;
				d++;
			}
		}
	}

	void makeTurnOrder()
	{
		baseClass[] sameCT = new baseClass[party.Length + enemys.Length];
		int z = 0;
		while (turnOrder.Count < 8)
			
		{
			foreach(baseClass x in party)
			{
				if (x == null)
					continue;
				if (x.IncrementCT ())//if CT over 100, add to sameCT
				{
					sameCT [z] = x;
					z++;
				}
			}
			foreach(baseClass x in enemys)
			{
				if (x == null)
					continue;
				if(x.IncrementCT())
				{
					sameCT [z] = x;
					z++;
				}
			}
			if(sameCT[0] != null)
			{
				Array.Sort (sameCT, new CTComparer());
				for (int x = 0;x<sameCT.Length;x++)
				{
					if (sameCT [x] == null)
						break;
					turnOrder.Enqueue (sameCT [x]);
					sameCT [x] = null;
				}
			}
			z = 0;
		}
	}

	public class CTComparer : IComparer<baseClass>
	{
		public int Compare(baseClass x, baseClass y)
		{
			if (x == null){
				return -1;
			}
			if (y == null)
				return 1;
			if (x.stats [10] >= y.stats [10])
				return 1;
			else
				return -1;
		}
	}

	void Battlecommand(baseClass target)
	{
		switch(command)
		{
		case(0):
			{
				foreach (baseClass x in enemys)
				{
					if (x.stats [2] > targetEnemy.stats [2])
						targetEnemy = x;
				}
				break;
			}
		case(1):
			{
				targetEnemy = null;
				foreach (baseClass x in dps)
				{
					if (targetEnemy == null)//find lowest HP enemy, first target
						targetEnemy = x;
					else if (x.stats [2] > targetEnemy.stats [2])
						targetEnemy = x;
				}
				break;
			}
		case(2):
			{
				targetEnemy = null;
				foreach (baseClass x in healers)
				{
					if (targetEnemy == null)//find lowest HP enemy, first target
						targetEnemy = x;
					else if (x.stats [2] > targetEnemy.stats [2])
						targetEnemy = x;
				}
				break;
			}

		case(3):
			{
				targetEnemy = null;
				foreach (baseClass x in supports)
				{
					if (targetEnemy == null)//find lowest HP enemy, first target
						targetEnemy = x;
					else if (x.stats [2] > targetEnemy.stats [2])
						targetEnemy = x;
				}
				break;
			}
		case(4):
			{
				targetEnemy = null;
				foreach (baseClass x in tanks)
				{
					if (targetEnemy == null)//find lowest HP enemy, first target
						targetEnemy = x;
					else if (x.stats [2] > targetEnemy.stats [2])
						targetEnemy = x;
				}
				break;
			}
		case(5):
			{
				//party focus's on DPS, deal with individually?
				break;
			}
		case(6):
			{
				//party focus's on healing, deal with individually?
				break;
			}
		case(7):
			{
				//party focus's on defense/healing, deal with individually?
				break;
			}
		case(8):
			{
				//party focus's on healing specific target, deal with individually?
				break;
			}
		case(9):
			{
				//party focus's on supporting specific target
				break;
			}
		case(10):
			{
				targetEnemy = target;
				break;
			}
		}
	}

	public void removeUnit(baseClass unit)//remove unit from turn order, likely from death
	{
		Debug.Log (unit.charName + " is dead and removed");
		Queue <baseClass> tempOrder = new Queue<baseClass>();
		unit.stats [2] = 0;
		int deadAllys = 0;
		int deadEnemys = 0;
		if(unit.friendly)
		{
			for(int x = 0;x<5;x++)
			{
				if (party [x] == unit)
					party [x] = null;
				if (party [x] == null)
					deadAllys++;
			}
		}
		else
		{
			for(int x = 0;x<5;x++)
			{
				if (enemys [x] == unit)
					enemys [x] = null;
				if (enemys [x] == null)
					deadEnemys++;
				if (unit.role < 4) {
					if (dps [x] == unit)
						dps [x] = null;
				} else if (unit.role < 8) {
					if (tanks [x] == unit)
						tanks [x] = null;
				} else if (unit.role < 12) {
					if (healers [x] == unit)
						healers [x] = null;	
				} else {
					if (supports [x] == unit)
						supports [x] = null;
				}
			}
		}
		while (turnOrder.Count > 0)//move turnOrder to temp, removing unit if found
		{
			baseClass tempUnit = turnOrder.Dequeue();
			if (tempUnit != unit)
				tempOrder.Enqueue (tempUnit);
		}
		while (tempOrder.Count > 0)//move temp back to turnOrder, without unit if it was in there
			turnOrder.Enqueue (tempOrder.Dequeue());
		if (turnOrder.Count < 8)//increment turn order up to at least 8
			makeTurnOrder ();
		unit.onDeath ();
		if(deadAllys == 5)
		{
			Debug.Log ("Battle Lost");
			battleOver = true;
		}
		else if (deadEnemys == 5)
		{
			Debug.Log ("Battle Won");
			battleOver = true;
		}
		return;
	}

	public baseClass highestThreat()
	{
		allyClass max = null;
		foreach(allyClass x in party)//loop until find max that isnt null
		{
			max = x;
			if (max != null)
				break;
		}
		foreach (allyClass x in party)
		{
			if (x == null)
				continue;
			if (x.threat > max.threat)
				max = x;
		}
		return max;
	}

	public bool allyHealthCheck(baseClass healer,bool ally,int healPercent)
	{
		baseClass lowest = null;
		int heal = (int)(healer.stats [7] * baseClass.HEALING_MULTIPLIER);
		if(ally)//player party
		{
			foreach(baseClass x in party)
			{
				if (x == null)
					continue;
				if((x.stats[2] <= x.maxHp - heal) || ((((x.stats[2]/(x.maxHp))*100) < healPercent)))
				{
					if (lowest == null)
						lowest = x;
					else
					{
						if(lowest.stats[2] > x.stats[2])
								lowest = x;
					}
				}
			}
			if (lowest != null) {
				lowest.stats [2] += heal;
				overHealCheck (lowest);
				return true;
			} else
				return false;
		}
		else//enemy healing a enemy
		{
			foreach(baseClass x in enemys)
			{
				if (x == null)
					continue;
				if((x.stats[2] <= x.maxHp - heal) || ((((x.stats[2]/(x.maxHp))*100) < healPercent)))
				{
					if (lowest == null)
						lowest = x;
					else
					{
						if(lowest.stats[2] > x.stats[2])
						{
							lowest = x;
						}
					}
				}
			}
			if (lowest != null) {
				lowest.stats [2] += heal;
				overHealCheck (lowest);
				return true;
			} else
				return false;
		}
	}

	public baseClass instaKillCheck(int dmg,bool ally)//check if unit can be one shot
	{
		if(ally)//search enemys
		{
			foreach (baseClass x in enemys) {
				if (x == null)
					continue;
				if ((x.stats [2] - (dmg - x.armor)) <= 0)
					return x;
			}
		}
		else//search party
		{
			foreach (baseClass x in party) {
				if (x == null)
					continue;
				if ((x.stats [2] - (dmg - x.armor)) <= 0)
					return x;
			}
		}
		return null;
	}

	public bool deathCheck(baseClass unit)
	{
		if (unit.stats[2]<=0)
		{
			removeUnit (unit);
			return true;
		}
		return false;
	}

	public bool overHealCheck(baseClass unit)
	{
		if (unit.stats[2] > unit.maxHp)
		{
			unit.stats [2] = unit.maxHp;
			return true;
		}
		return false;
	}

	public bool overManaCheck(baseClass unit)
	{
		if(unit.stats[3] >= unit.maxMana){
			unit.stats [3] = unit.maxMana;
			return true;
		}
		return false;
	}

	public void printDmg(int dmg)
	{
		DmgText.GetComponent<UnityEngine.UI.Text> ().text = "-"+dmg;
	}

}
