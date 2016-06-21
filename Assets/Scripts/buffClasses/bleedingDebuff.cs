using UnityEngine;
using System.Collections;

public class bleedingDebuff : buffClass {//deals little dmg over a very short time


	// Use this for initialization
	void Start (int duration,baseClass user,int percentBoost) {
		base.Start(duration,true, false,user);
		this.percentBoost = percentBoost;
	}

	// Update is called once per frame
	void Update () {
		//TODO put def up pic w/ duration
	}

	public void applyBuff()
	{
		user.stats [2] -= user.maxHp * percentBoost;
		manager.deathCheck (user);
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		return;
	}
}