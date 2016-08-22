using UnityEngine;
using System.Collections;
using System.IO;

public class classClass {

	public string className;
	public int classNum;
	public baseClass unit;
	public int attackType;
	public bool canShield;
	public bool canSupport;
	public bool canHeal;
	string[] names;
	const int numNames = 259;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void create()
	{
		return;
	}
		
	public void levelUp(int level)//what stats level up by what amount
	{
		return;
	}

	public baseClass generateUnit(int level)//make a unit of this type
	{
		return null;
	}

	public string generateName()
	{
		if(names == null){//if no names loaded, read names from file
			string filename = "names.txt";
			StreamReader reader = new StreamReader (File.Open (filename, FileMode.Open));
			if(reader == null){
				Debug.Log ("Error opening file");
				return "";
			}
			names = new string[numNames];
			for (int x = 0; x < numNames; x++)
				names [x] = reader.ReadLine ();
			reader.Close ();
		}
		return names [Random.Range (0, numNames)];
	}
}
