using UnityEngine;
using System.Collections;

public class dmgBuff : buffClass {//buffs phys/magic dmg for user


	// Use this for initialization
	void Start (int duration,baseClass user,int percentBoost) {
		base.Start(duration,true, true,user);
		this.percentBoost = percentBoost;
	}
	
	// Update is called once per frame
	void Update () {
		//TODO put dmg up pic w/ duration
	}

	public void oneTimeBuff()
	{
		if(user.attackType == 0)
			user.stats [4] = (int)(user.stats [4] * percentBoost);
		else if (user.attackType == 1)
			user.stats [7] = (int)(user.stats [7] * percentBoost);
		else//buff both phys and magic at half effectiveness each
		{
			user.stats [4] = (int)(user.stats [4] * (percentBoost/2));
			user.stats [7] = (int)(user.stats [7] * (percentBoost/2));
		}
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		if(user.attackType == 0)
			user.stats [4] = (int)(user.stats [4] / percentBoost);
		else if (user.attackType == 1)
			user.stats [7] = (int)(user.stats [7] / percentBoost);
		else//buff both phys and magic at half effectiveness each
		{
			user.stats [4] = (int)(user.stats [4] / (percentBoost/2));
			user.stats [7] = (int)(user.stats [7] / (percentBoost/2));
		}
	}
}
