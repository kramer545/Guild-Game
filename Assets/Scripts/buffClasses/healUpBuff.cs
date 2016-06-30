using UnityEngine;
using System.Collections;

public class healUpBuff : buffClass {//buffs healing DONE to user 


	// Use this for initialization
	void Start (int duration,baseClass user,double percentBoost,bool isBuffed,bool isDebuffed) {
		base.Start(duration,true, true,user,7,isBuffed,isDebuffed);
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
		user.healMultiplier = (float)(user.healMultiplier * percentBoost);
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		user.healMultiplier = 1;
	}
}