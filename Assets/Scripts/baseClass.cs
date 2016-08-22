using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class baseClass: MonoBehaviour {

	public string charName;
	public string className;
	public int[] stats = new int[11];
	public int[] baseStats = new int[11];
	public int role;
	public int multiplier;
	public int maxHp;
	public int maxMana;
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
	public int attackType;//0 = phys, 1 = magic, anything else is both
	public const float HEALING_MULTIPLIER = 1;
	public bool healerSubclass;
	public List<buffClass> buffs = new List<buffClass>();
	public float healMultiplier = 1;
	public bool lifeSteal = false;
	public const double LIFE_STEAL_PERCENT = 0.2;//20%
	public const double LIFE_STEAL_BONUS = 0.1;//10%
	public double lifeStealAmount;
	public bool inflictStatus;
	public int hitChance;
	public int barrierCharges;
	public bool isSleeping = false;
	public GameObject unit;
	public GameObject HpText;
	public int classNum;
	public int buffNum = 1;
	public classClass currClass;
	public int[] expLevels = {80,165,267,387,523,677,850,1041,1252,1482,1733,2005,2298,2613,2950,3311,3696,4105,4539,4999,5485,5999,6540,7109,7708,8336,8994,9684,10405,11159,11946,12767,13623,14514,
				15441,16405,17407,18447,19526,20646,21806,23007,24251,25538,26869,28245,29666,31134,32649,34212,35824,37486,39199,40963,42780,44650,46574,48554,50589,52682,54832,57041,59310,
		61640,64032,66486,69004,71586,74234,76949,79731,82582,85503,88494,91557,94693,97903,101188,104548,107986};//made using (log(x)^4.5)/18

	// Use this for initialization
	public void create (string name, int[] stats, int role,int attackType, bool friendly,int classNum) {
		charName = name;
		this.stats = stats;
		this.role = role;
		this.friendly = friendly;
		this.attackType = attackType;
		maxHp = stats [2];
		maxMana = stats [3];
		baseStats = stats;
		this.classNum = classNum;
		if(HpText != null){
			HpText.GetComponent<UnityEngine.UI.Text>().text = (maxHp + " / " + maxHp);
			this.transform.FindChild ("HealthBarFront").GetComponent<SpriteRenderer> ().material.color = Color.green;//set health bar green
		}
	}
	
	// Update is called once per frame
	void Update () {
		//call animation loop?
	}

	public bool doBuff(baseClass buffTarget)//action of trying to apply buff/debuff, returns true on success, false on failure
	{
		return false;
	}

	public bool IncrementCT()
	{
		int temp = CT_BASE * multiplier;
		if (temp < CT_LOW)
			temp = CT_LOW;
		else if (temp > CT_HIGH)
			temp = CT_HIGH;
		stats [10] += temp;
		if (stats [10] >= CT_CAP) {
			stats [10] = CT_CAP;
			return true;//true if we reached CT cap
		} else
			return false;//false if CT cap not reached
	}

	public void createingBuff()
	{
		//buffs/debuffs applied automatically at create of battle, ex: passive effects
		return;
	}

	public virtual void action()
	{
		baseClass oneShot = manager.instaKillCheck (this.dmg, friendly);
		if(defended)
		{
			defended = false;
			armor = (int)(armor / 1.2);
		}

		if(isSleeping)//turn skipped
		{
			Debug.Log (charName + " is asleep");
		}

		if(skillActivated)//TODO figuare this out!
		{
			oneShot = null;
			manager.nextTurn = true;
			return;
		}

		else
		{
			if(role < 8)//DPS/Tank main
			{
				if (manager == null)
					Debug.Log ("Manager is Null");
				if(oneShot != null)
				{
					oneShot.attacked (this);
				}
				else if((role == 2) || (role == 6))//healer subrole
				{
					if(manager.allyHealthCheck(this,friendly,50))//if true, ally was healed
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
				if(manager.allyHealthCheck(this,friendly,80))//if true, ally was healed
				{
					return;
				}
				else if (oneShot != null)
				{
					oneShot.attacked (this);
				}
				else if (role == 11)//support ally
				{
					supportBuff ();
				}
				else
				{
					manager.targetEnemy.attacked (this);
				}
			}

			else//Support main
			{
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
				else
				{
					supportBuff ();
				}
			}
		}
		oneShot = null;
		//depends on class, role and situation
		//what happens on this units turn
	}

	public void onDeath()
	{
		isAlive = false;
		stats [10] = 0;
		//manager.
	}

	public void iterateBuffs()
	{
		Queue<buffClass> removedBuffs = new Queue<buffClass>();
		foreach (buffClass x in buffs)
		{
			if (x.tickBuff ())
				removedBuffs.Enqueue (x);
		}
		while(removedBuffs.Count > 0)
			buffs.Remove (removedBuffs.Dequeue());
	}

	public void activateLifeSteal(bool buffed)
	{
		lifeSteal = true;
		lifeStealAmount = LIFE_STEAL_PERCENT;
		if (buffed)
			lifeStealAmount += LIFE_STEAL_BONUS;
	}

	public int dmgCalc()
	{
		return dmg;
	}
		

	public void attacked(baseClass attacker)
	{
		int rand = (int)Random.Range (0, 100);
		int dmg = attacker.dmgCalc();
		string attackMsg = attacker.charName + " attacked "+ this.charName+", ";

		if(barrierCharges > 0)
		{
			Debug.Log (attackMsg + "attack was absorbed by barrier");
			barrierCharges--;
		}
		if((rand >= (attacker.hitChance - dodgeChance)) && (attacker.attackType != 1) && (!isSleeping))//dodging, no dmg, can't dodge magic
		{
			Debug.Log (attackMsg + "attack was dodged ");
			attacker.GetComponent<Animator> ().Play ("attacking",-1,0);
			manager.printMiss ();
			//TODO print dodge statement/animation
			//no dmg done
			return;
		}

		//checking for dodges, blocks and crits, then applys dmg
		if ((rand < blockChance) && (!isSleeping))//blocking, reduces dmg
		{
			Debug.Log (attackMsg + "attack was blocked");
			if (attacker.attackType == 2)//blocking magic is only 50% effective
			{
				stats [2] -= dmg/(BLOCK_REDUCTION/2);
				manager.printDmg ((int)(dmg / (BLOCK_REDUCTION / 2)));
				if(attacker.lifeSteal){
					attacker.stats [2] += (int)((dmg / (BLOCK_REDUCTION / 2)) * LIFE_STEAL_PERCENT);
					manager.overHealCheck (attacker);
				}
				manager.deathCheck (this);
			}
			else
			{
				if(rand < attacker.critChance)//if enemy crits
				{
					Debug.Log (attackMsg + "Enemy Crit");
					stats [2] = (stats [2] - (int)((dmg * attacker.critDmg) / BLOCK_REDUCTION));
					manager.printDmg ((int)((dmg * attacker.critDmg) / BLOCK_REDUCTION));
					if(attacker.lifeSteal){
						attacker.stats [2] += (int)(dmg * attacker.critDmg * LIFE_STEAL_PERCENT);
						manager.overHealCheck (attacker);
					}
					manager.deathCheck (this);
				}
				else
				{
					Debug.Log (attackMsg);
					stats [2] = (stats [2] - (int)((dmg) / BLOCK_REDUCTION));
					manager.printDmg ((int)((dmg) / BLOCK_REDUCTION));
					if(attacker.lifeSteal){
						attacker.stats [2] += (int)((dmg / BLOCK_REDUCTION) * LIFE_STEAL_PERCENT);
						manager.overHealCheck (attacker);
					}
					manager.deathCheck (this);
				}
			}
		}

		else//no special effects
		{
			rand = (int)Random.Range (0, 100);
			if(((rand < attacker.critChance)|| (isSleeping)) && (attacker.attackType != 2))//if enemy crits(cant crit if magic attack)
			{
				Debug.Log (attackMsg + "Enemy Crit");
				stats [2] -= dmg*attacker.critDmg;
				manager.printDmg (dmg*attacker.critDmg);
				if(attacker.lifeSteal){
					attacker.stats [2] += (int)(dmg * attacker.critDmg * LIFE_STEAL_PERCENT);
					manager.overHealCheck (attacker);
				}
				manager.deathCheck (this);
			}
			else
			{
				manager.printDmg (dmg);
				stats [2] -= dmg;
				if(attacker.lifeSteal){
					attacker.stats [2] += (int)(dmg * LIFE_STEAL_PERCENT);
					manager.overHealCheck (attacker);
				}
				manager.deathCheck (this);
			}
		}
		HpText.GetComponent<UnityEngine.UI.Text> ().text = "";
		attacker.GetComponent<Animator> ().Play ("attacking",-1,0);
		GetComponent<Animator> ().Play ("attacked",-1,0);
		this.transform.FindChild ("HealthBarFront").transform.localScale = new Vector2 (((float)stats [2] / (float)maxHp) * 3.3333F, 3.3333F);
		if (((float)stats [2] / (float)maxHp) > 0.66f)
			this.transform.FindChild ("HealthBarFront").GetComponent<SpriteRenderer> ().material.color = Color.green;
		else if (((float)stats [2] / (float)maxHp) <= 0.66f)
			this.transform.FindChild ("HealthBarFront").GetComponent<SpriteRenderer> ().material.color = Color.yellow;
		if (((float)stats [2] / (float)maxHp) <= 0.33f)
			this.transform.FindChild ("HealthBarFront").GetComponent<SpriteRenderer> ().material.color = Color.red;
		HpText.GetComponent<UnityEngine.UI.Text>().text = stats[2] + " / " + maxHp;
		Debug.Log (charName + " has " + stats [2] + " HP left, "+ attacker.charName +" did "+dmg+" dmg");
	}

	public void levelUp()//Stats increase on level up
	{
		stats [0]++;//level + 1
		stats [1] = 0;//exp reset
		//... do later
	}

	public void supportBuff()
	{
		switch (classNum) {
		case(0):
			{
				break;
			}
		case(1):
			{
				foreach (allyClass x in manager.party) {
					if (x == null)
						continue;
					Debug.Log ("applied buff to " + x.charName);
					if (buffNum == 1) {
						dmgBuff dmg = new dmgBuff ();
						dmg.create (3, x, 10, false, false);
						x.buffs.Add (dmg);
						x.buffed = true;
						dmg.oneTimeBuff ();
					} else if (buffNum == 2) {
						defBuff def = new defBuff ();
						def.create (3, x, 10, false, false);
						x.buffs.Add (def);
						x.buffed = true;
						def.oneTimeBuff ();
					} else {
						spdBuff spd = new spdBuff ();
						spd.create (3, x, 10, false, false);
						x.buffs.Add (spd);
						x.buffed = true;
						spd.oneTimeBuff ();
					}
				}
				if (buffNum == 1) {
					buffNum = 2;
				} else if (buffNum == 2) {
					buffNum = 3;
				} else {
					buffNum = 1;
				}
				break;
			}
		default:{
				break;
			}
		}
	}
}
