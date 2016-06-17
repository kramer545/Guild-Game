using UnityEngine;
using System.Collections;

public class baseClass : MonoBehaviour {

	public string charName;
	public string className;
	public int[] stats;
	public int role;
	public int multiplier;
	public int maxHp;
	public bool negStatus;
	public bool buffed;
	public bool debuffed;
	const int CT_BASE = 40;
	const int CT_LOW = 30;
	const int CT_HIGH = 80;
	const int CT_CAP = 100;
	public BattleManager manager;
	public int dmg;//basic attack dmg
	public int armor;//basic attack defense
	public bool defended = false;//if defended last turn, need to reset armor/defense
	public int blockChance;
	public int dodgeChance;
	public int critChance;
	public int critDmg;
	public const int BLOCK_REDUCTION = 2;
	public bool friendly;
	public bool isAlive;
	public bool skillActivated;
	public float physMult;
	public float magMult;
	public weaponClass weapon;
	public int attackType;
	public const float HEAL_MULTIPLIER = 5;
	public bool healerSubclass;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//call animation loop?
	}

	public bool IncrementCT()
	{
		int temp = CTBase * multiplier;
		if (temp < CTLow)
			temp = CTLow;
		else if (temp > CTHigh)
			temp = CTHigh;
		stats [10] += temp;
		if (stats [10] >= CTCap) {
			stats [10] = -CTCap;
			return true;//true if we reached CT cap
		} else
			return false;//false if CT cap not reached
	}

	public void startingBuff()
	{
		//buffs/debuffs applied automatically at start of battle, ex: passive effects
	}

	public void action()
	{
		if(defended)
		{
			defended = false;
			armor = (int)(armor / 1.2);
		}

		if(skillActivated)//TODO figuare this out!
		{
			
		}

		else
		{
			if(role < 8)//DPS/Tank main
			{
				baseClass oneShot = manager.instaKillCheck (this.dmg, friendly);
				if (oneShot != null)
				{
					oneShot.attacked (this);
				}
				else if((role == 2) || (role == 6))//healer subrole
				{
					if(manager.allyHealthCheck(this,friendly))//if true, ally was healed
					{
						return;
					}
				}
				else if ((role == 7) || (role == 3))//support subrole
				{
					//TODO support stuff
				}
				else
				{
					manager.targetEnemy.attacked (this);
				}
			}

			else if ((role >= 8) && (role < 12))//Healer main
			{
				baseClass oneShot = manager.instaKillCheck (this.dmg, friendly,90);
				if(manager.allyHealthCheck(this,friendly))//if true, ally was healed
				{
					return;
				}
				else if (oneShot != null)
				{
					oneShot.attacked (this);
				}
				else if (role == 11)//support ally
				{
					//TODO do support stuff
				}
				else
				{
					manager.targetEnemy.attacked (this);
				}
			}

			else//Support main
			{
				baseClass oneShot = manager.instaKillCheck (this.dmg, friendly);
				if(role == 15)//healer subclass
				{
					if (manager.allyHealthCheck(this,friendly,65))
					{
						return;
					}
					else if (oneShot != null)
					{
						oneShot.attacked (this);
					}
					else
					{
						manager.targetEnemy.attacked (this);
					}
				}
				else if (oneShot != null)
				{
					oneShot.attacked (this);
				}
				else if (role == 11)//support ally
				{
					//TODO do support stuff
				}
				else
				{
					manager.targetEnemy.attacked (this);
				}
			}
		}
		//depends on class, role and situation
		//what happens on this units turn
	}

	public void onDeath()
	{
		isAlive = false;
		stats [10] = 0;
		//manager.
	}

	public void defend()
	{
		threat = (int)(threat * 0.9);
		armor = (int)(armor * 1.2);
		defended = true;
	}

	public void attacked(baseClass attacker)
	{
		int rand = (int)Random.Range (0, 100);
		int dmg;
		//calculating dmg stage
		if(attacker.attackType == 0)//phys attack
		{
			dmg =(((attacker.stats [4] * attacker.physMult) + attacker.weapon.physDmg) - stats [5]);
			if (dmg < (attacker.stats [0] * 10))//if dmg is below attacker level times 10, set it to min dmg
				dmg = (attacker.stats [0] * 10);

		}
		else if (attacker.attackType == 1)//magic attack
		{
			dmg = (((attacker.stats [7] * attacker.magMult) + attacker.weapon.magDmg) - stats [8]);
			if (dmg < (attacker.stats [0] * 10))//if dmg is below attacker level times 10, set it to min dmg
				dmg = (attacker.stats [0] * 10);
		}
		else//both phys and magic
		{
			dmg = (((attacker.stats [4] * attacker.physMult) + attacker.weapon.physDmg) - stats [5]);
			if (dmg < 0)//if phys dmg is below zero, set to min dmg
				dmg = (int)((attacker.stats [0] * 10) / 2);
			if ((((attacker.stats [7] * attacker.magMult) + attacker.weapon.magDmg) - stats [8]) > 0)
				dmg += (((attacker.stats [7] * attacker.magMult) + attacker.weapon.magDmg) - stats [8]);
			else
				dmg +=(int)((attacker.stats [0] * 10) / 2);
		}

		//checking for dodges, blocks and crits, then applys dmg
		if((rand <= dodgeChance) && (attacker.attackType != 1))//dodging, no dmg, can't dodge magic
		{
			Debug.Log ("Attack Dodged");
			//TODO print dodge statement/animation
			//no dmg done
		}

		else if (rand < blockChance)//blocking, reduces dmg
		{
			rand = (int)Random.Range (0, 100);
			if (attacker.attackType == 2)//blocking magic is only 50% effective
			{
				stats [2] -= dmg/(BLOCK_REDUCTION/2);
			}
			else
			{
				if(rand < attacker.critChance)//if enemy crits
				{
					stats [2] = (stats [2] - (int)((dmg * attacker.critDmg) / blockReduction));
					if (stats [2] <= 0)
						manager.removeUnit (this,friendly);
				}
				else
				{
					stats [2] = (stats [2] - (int)((dmg) / blockReduction));
					if (stats [2] <= 0)
						manager.removeUnit (this,friendly);
				}
			}
		}

		else//no special effects
		{
			rand = (int)Random.Range (0, 100);
			if((rand < attacker.critChance) && (attacker.attackType != 2))//if enemy crits(cant crit if magic attack)
			{
				stats [2] -= dmg*attacker.critDmg;
				if (stats [2] <= 0)
					manager.removeUnit (this,friendly);
			}
			else
			{
				stats [2] -= dmg;
				if (stats [2] <= 0)
					manager.removeUnit (this,friendly);
			}
		}
	}
}
