using UnityEngine;
using System.Collections;

public class buffClass : MonoBehaviour {

	public bool isBuff;//false if debuff
	public bool oneTime;//onetime boost, or boost every tick?
	public int duration;
	public int percentBoost;
	public baseClass user;

	// Use this for initialization
	public void Start (int duration,bool isBuff,bool oneTime,baseClass user) {
		this.duration = duration;
		this.isBuff = isBuff;
		this.oneTime = oneTime;
		this.user = user;
		if (oneTime)
			oneTimeBuff ();
	}

	// Update is called once per frame
	void Update () {
		//TODO visual stuff, like turns remaining, etc
	}

	public bool applyBuff()
	{
		return false;
	}

	public void oneTimeBuff()
	{
		 return;
	}

	public bool tickBuff()
	{
		duration--;
		if (duration <= 0){//returns true to remove buff from unit
			revertBuff();
			return true;
		}
		else
			return false;
	}

	public void revertBuff()
	{
		return;
	}
}