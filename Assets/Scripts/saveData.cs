using UnityEngine;
using System.Collections;


public class saveData{

	public static saveData saved;
	const int maxMembers = 200;//max people allowed to store in guild

	public allyClass[] guildMembers;

	//Resources
	public int copper;//money, 100 copper = 1 silver, 100 silver = 1 gold
	public int silver;
	public int gold;
	public int platnium;//premium currency
	public int stone;
	public int metal;
	public int wood;
	public int magic;
	public int reputation;
	public int prestige;
	public int guildPoints;
	public int guildLevel;

	// Use this for initialization
	void Start () {
		if (guildMembers == null)
			guildMembers = new allyClass[maxMembers];
		if (saved == null)
			saved = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
