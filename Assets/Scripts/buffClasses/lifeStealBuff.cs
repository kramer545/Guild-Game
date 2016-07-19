using UnityEngine;
using System.Collections;

public class lifeStealBuff : buffClass {//buffs healing DONE to user 


	// Use this for initialization
	void create (int duration,baseClass user,double percentBoost) {
		base.create(duration,true, true,user,9);
		this.percentBoost = percentBoost;
	}

	// Update is called once per frame
	void Update () {
		//TODO put def up pic w/ duration
	}

	public void oneTimeBuff()
	{
		user.activateLifeSteal (buffBuffed);
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		user.lifeSteal = false;
	}
}