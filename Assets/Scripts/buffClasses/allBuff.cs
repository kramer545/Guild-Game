using UnityEngine;
using System.Collections;

public class allBuff : buffClass {//slightly buffs all users stats (atk/magic is split though based on attack type)

	int [] statChange = new int[6];
	// Use this for initialization
	void create (int duration,baseClass user,double percentBoost,bool isBuffed,bool isDebuffed) {
		base.create(duration,true, true,user,1,isBuffed,isDebuffed);
		this.percentBoost = percentBoost;
	}

	// Update is called once per frame
	void Update () {
		//TODO put def up pic w/ duration
	}

	public void oneTimeBuff()
	{
		if (buffBuffed)
			percentBoost = percentBoost + ((1 - percentBoost) * 0.5);
		if (buffDebuffed)
			percentBoost = percentBoost - ((1 - percentBoost) * 0.5);
		statChange[0] = (int)(user.stats [5] * percentBoost)-user.stats[5];
		statChange[1] = (int)(user.stats [6] * percentBoost)-user.stats[6];
		statChange[2] = (int)(user.stats [8] * percentBoost)-user.stats[8];
		statChange[3] = (int)(user.stats [9] * percentBoost)-user.stats[9];
		if (user.attackType == 0)
			statChange[4] = (int)(user.stats [4] * percentBoost)-user.stats[4];
		else if (user.attackType == 1)
			statChange[5] = (int)(user.stats [7] * percentBoost)-user.stats[7];
		else {
			statChange [4] = (int)(user.stats [4] * (percentBoost + ((1 - percentBoost) * 0.5))) - user.stats [4];
			statChange [5] = (int)(user.stats [7] * (percentBoost + ((1 - percentBoost) * 0.5))) - user.stats [7];
		}
		user.stats [4] = user.stats [4] + statChange [4];
		user.stats [5] = user.stats [5] + statChange [0];
		user.stats [6] = user.stats [6] + statChange [1];
		user.stats [7] = user.stats [7] + statChange [5];
		user.stats [8] = user.stats [8] + statChange [2];
		user.stats [9] = user.stats [9] + statChange [3];

	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		user.stats [4] = user.stats [4] - statChange [4];
		user.stats [5] = user.stats [5] - statChange [0];
		user.stats [6] = user.stats [6] - statChange [1];
		user.stats [7] = user.stats [7] - statChange [5];
		user.stats [8] = user.stats [8] - statChange [2];
		user.stats [9] = user.stats [9] - statChange [3];
	}
}