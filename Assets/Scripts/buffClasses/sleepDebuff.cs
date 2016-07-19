using UnityEngine;
using System.Collections;

public class sleepDebuff : buffClass {//puts user to sleep


	// Use this for initialization
	void create (int duration,baseClass user,double percentBoost,bool isBuffed,bool isDebuffed) {
		base.create(duration,false, true,user,20,isBuffed,isDebuffed);
		this.percentBoost = percentBoost;
	}

	// Update is called once per frame
	void Update () {
		//TODO put def up pic w/ duration
	}

	public void oneTimeBuff()
	{
		user.isSleeping = true;
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		user.isSleeping = false;
	}
}