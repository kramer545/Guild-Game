using UnityEngine;
using System.Collections;

public class spdBuff : buffClass {//buffs spd for user


	// Use this for initialization
	void create (int duration,baseClass user,double percentBoost,bool isBuffed,bool isDebuffed) {
		base.create(duration,true, true,user,11,isBuffed,isDebuffed);
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
		statChange = ((int)(user.stats [6] * percentBoost)) - user.stats [6];
		user.stats [6] = user.stats [6] + statChange;
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		user.stats [6] = user.stats [6] - statChange;
	}
}