using UnityEngine;
using System.Collections;

public class defDebuff : buffClass {//debuffs both phys/magic def for user

	int statChangeTwo;
	// Use this for initialization
	void Start (int duration,baseClass user,double percentBoost,bool isBuffed,bool isDebuffed) {
		base.Start(duration,false, true,user,15,isBuffed,isDebuffed);
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
		statChange = ((int)(user.stats [5] * percentBoost)) - user.stats [5];
		statChangeTwo = ((int)(user.stats [8] * percentBoost)) - user.stats [8];
		user.stats [5] = user.stats [5] - statChange;
		user.stats [8] = user.stats [8] - statChangeTwo;
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		user.stats [5] = user.stats [5] + statChange;
		user.stats [8] = user.stats [8] + statChangeTwo;
	}
}