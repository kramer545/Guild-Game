using UnityEngine;
using System.Collections;

public class manaBuff : buffClass {//returns percent of max mana to user


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
		user.stats [3] += user.maxMana * percentBoost;
		if (user.stats [3] > user.maxMana)
			user.stats [3] = user.maxMana;
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		return;
	}
}