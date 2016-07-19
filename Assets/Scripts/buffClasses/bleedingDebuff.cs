using UnityEngine;
using System.Collections;

public class bleedingDebuff : buffClass {//deals little dmg over a very short time

	bool firstRun = true;
	// Use this for initialization
	void create (int duration,baseClass user,double percentBoost,bool isBuffed,bool isDebuffed) {
		base.create(duration,false, false,user,13,isBuffed,isDebuffed);
		this.percentBoost = percentBoost;
	}

	// Update is called once per frame
	void Update () {
		//TODO put def up pic w/ duration
	}

	public void applyBuff()
	{
		if (firstRun) {
			if (buffBuffed)
				percentBoost = percentBoost + ((1 - percentBoost) * 0.5);
			if (buffDebuffed)
				percentBoost = percentBoost - ((1 - percentBoost) * 0.5);
			firstRun = false;
		}
		user.stats [2] -= (int)(user.maxHp * percentBoost);
		manager.deathCheck (user);
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		return;
	}
}