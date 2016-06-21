using UnityEngine;
using System.Collections;

public class lifeStealBuff : buffClass {//buffs healing DONE to user 


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
		user.lifeSteal = true;
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		user.lifeSteal = false;
	}
}