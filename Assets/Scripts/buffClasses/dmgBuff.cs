using UnityEngine;
using System.Collections;

public class dmgBuff : buffClass {//buffs phys/magic dmg for user

	int statChangeTwo;

	// Use this for initialization
	void create (int duration,baseClass user,double percentBoost,bool isBuffed,bool isDebuffed) {
		base.create(duration,true, true,user,4,isBuffed,isDebuffed);
		this.percentBoost = percentBoost;
	}
	
	// Update is called once per frame
	void Update () {
		//TODO put dmg up pic w/ duration
	}

	public void oneTimeBuff()
	{
		if (buffBuffed)
			percentBoost = percentBoost + ((1 - percentBoost) * 0.5);
		if (buffDebuffed)
			percentBoost = percentBoost - ((1 - percentBoost) * 0.5);
		if(user.attackType == 0)
			statChange = (int)(user.stats [4] * percentBoost);
		else if (user.attackType == 1)
			statChangeTwo = (int)(user.stats [7] * percentBoost);
		else//buff both phys and magic at half effectiveness each
		{
			statChange = (int)(user.stats [4] * (percentBoost/2));
			statChangeTwo = (int)(user.stats [7] * (percentBoost/2));
		}
		user.stats [4] += statChange;
		user.stats [7] += statChangeTwo;
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		user.stats [4] -= statChange;
		user.stats [7] -= statChangeTwo;
	}
}
