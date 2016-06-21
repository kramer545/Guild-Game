using UnityEngine;
using System.Collections;

public class spdDebuff : buffClass {//debuffs spd for user


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
		user.stats [6] = user.stats [6] * percentBoost;
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		user.stats [6] = user.stats [6] / percentBoost;
	}
}