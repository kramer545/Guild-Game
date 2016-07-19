﻿using UnityEngine;
using System.Collections;

public class hitChanceBuff : buffClass {

	public const int BASE_INCREASE = 25; //25% base increase to hit chance
	public int bonus = 0;

	// Use this for initialization
	void create (int duration,baseClass user,double percentBoost,bool isBuffed,bool isDebuffed) {
		base.create(duration,true, true,user,8,isBuffed,isDebuffed);
		this.percentBoost = percentBoost;
	}

	// Update is called once per frame
	void Update () {
		//TODO put def up pic w/ duration
	}

	public void oneTimeBuff()
	{
		if (buffBuffed)
			bonus += 10;
		if (buffDebuffed)
			bonus -= 10;
		user.hitChance = user.hitChance + BASE_INCREASE + bonus;
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		user.hitChance = user.hitChance - BASE_INCREASE - bonus;
	}
}