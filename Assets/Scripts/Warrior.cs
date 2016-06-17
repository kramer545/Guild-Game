using UnityEngine;
using System.Collections;

public class Warrior : allyClass {

	const double StanceModifier = 0.2;
	bool DeterminedSkill = false;//TODO change how skills are handled

	// Use this for initialization
	void Start () {
		charName = "Test McTestFace";
		className = "Warrior";
		stats [0] = 3;
		stats [1] = 0;
		stats [2] = 100;
		stats [3] = 0;
		stats [4] = 8;
		stats [5] = 8;
		stats [6] = 6;
		stats [7] = 1;
		stats [8] = 0;
		stats [9] = 3;
		stats [10] = 0;
		role = 1;
		maxHp = stats [2];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startingBuff()//apply skill based on role
	{
		if((role == 1) || (role == 0))//if dps main role
		{
			stats [4] += (int)(stats [4] * StanceModifier);
			threatMulipler = 1;
		}

		else//Tank main role
		{
			stats [5] += (int)(stats [5] * StanceModifier);
			threatMulipler = 1.3;
		}
	}

	public void action()
	{
		if(DeterminedSkill)
		{
			stats [2] += (int)(0.1 * maxHp);
			if (stats [2] > maxHp)
				stats [2] = maxHp;
			incrementThreat()
		}

		else if ((stats[2] <= (maxHp/4)) && (manager.command != 5) && (manager.command != 5))
		{
			defend (1);
		}

		else{
			 (manager.targetEnemy).attacked(this);
			incrementThreat(0)
		}
	}
}
