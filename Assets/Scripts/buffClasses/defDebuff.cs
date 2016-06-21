using UnityEngine;
using System.Collections;

public class defDebuff : buffClass {//buffs both phys/magic def for user


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
		user.stats [5] = user.stats [5] * percentBoost;
		user.stats [8] = user.stats [8] * percentBoost;
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		user.stats [5] = user.stats [5] / percentBoost;
		user.stats [8] = user.stats [8] / percentBoost;
	}
}