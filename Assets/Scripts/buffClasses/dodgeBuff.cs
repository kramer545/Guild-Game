using System.Collections;

public class dodgeBuff : buffClass {//buffs crit chance for user

	public const int BASE_DODGE = 10;
	public int bonus = 0;
	// Use this for initialization
	void Start (int duration,baseClass user,double percentBoost) {
		base.Start(duration,true, true,user);
		this.percentBoost = percentBoost;
	}

	// Update is called once per frame
	void Update () {
		//TODO put def up pic w/ duration
	}

	public void oneTimeBuff()
	{
		if (buffBuffed)
			bonus += 5;
		if (buffDebuffed)
			bonus -= 5;
		user.dodgeChance = user.dodgeChance + BASE_DODGE + bonus;
	}

	public void revertBuff()//auto called by tickBuff when duration is up
	{
		user.dodgeChance = user.dodgeChance - BASE_DODGE - bonus;
	}
}