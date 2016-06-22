using UnityEngine;
using System.Collections;

public class bleedingDebuff : buffClass {//deals little dmg over a very short time


	// Use this for initialization
	void Start (int duration,baseClass user,double percentBoost,bool isBuffed,bool isDebuffed) {
		base.Start(duration,false, false,user);
		this.percentBoost = percentBoost;
	}

	// Update is called once per frame
	void Update () {
		//TODO put def up pic w/ duration
	}

	public void applyBuff()
	{
		if (buffBuffed)
			percentBoost = percentBoost + ((1 - percentBoost) * 0.5);
		if (buffDebuffed)
			percentBoost = percentBoost - ((1 - percentBoost) * 0.5);
		user.stats [2] -= (int)(user.maxHp * percentBoost);
		manager.deathCheck (user);
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		return;
	}
}