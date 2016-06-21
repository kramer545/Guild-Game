using UnityEngine;
using System.Collections;

public class allDebuff : buffClass {//slightly debuffs all users stats (atk/magic is split though based on attack type)


	// Use this for initialization
	void Start (int duration,baseClass user,int percentBoost) {
		base.Start(duration,true, true,user);
		this.percentBoost = percentBoost;
	}

	// Update is called once per frame
	void Update () {
		//TODO put def up pic w/ duration
	}

	public void oneTimeBuff()
	{
		user.stats [5] = user.stats [5] * percentBoost;
		user.stats [6] = user.stats [6] * percentBoost;
		user.stats [8] = user.stats [8] * percentBoost;
		user.stats [9] = user.stats [9] * percentBoost;
		if (user.attackType == 0)
			user.stats [4] = user.stats [4] * percentBoost;
		else if (user.attackType == 1)
			user.stats [7] = user.stats [7] * percentBoost;
		else {
			user.stats [4] = user.stats [4] * (percentBoost/2);
			user.stats [7] = user.stats [7] * (percentBoost / 2);
		}
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		user.stats [5] = user.stats [5] / percentBoost;
		user.stats [6] = user.stats [6] / percentBoost;
		user.stats [8] = user.stats [8] / percentBoost;
		user.stats [9] = user.stats [9] / percentBoost;
		if (user.attackType == 0)
			user.stats [4] = user.stats [4] / percentBoost;
		else if (user.attackType == 1)
			user.stats [7] = user.stats [7] / percentBoost;
		else {
			user.stats [4] = user.stats [4] / (percentBoost/2);
			user.stats [7] = user.stats [7] / (percentBoost / 2);
		}
	}
}