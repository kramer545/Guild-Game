using UnityEngine;
using System.Collections;

public class manaBuff : buffClass {//returns percent of max HP to user


	// Use this for initialization
	void Start (int duration,baseClass user,double percentBoost) {
		base.Start(duration,true, false,user);
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
		user.stats [3] += (int)(user.maxMana * percentBoost);
		manager.overManaCheck (user);
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		return;
	}
}