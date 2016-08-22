using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(10,100,100,60),"Dungeons")){
			SceneManager.LoadScene ("test");
		}

		if(GUI.Button(new Rect(10,300,100,60),"Warrior Test")){
			baseClass test = new Warrior ().generateUnit (3,true);
			Debug.Log (test.charName + " "+ test.stats[0] + " "+ test.stats[2]);
		}
	}

	public void generateAlly()
	{
		int rank = saveData.saved.guildLevel;//depending on guild level, there is a level range
		int lower,higher;
		switch(rank){
		case(1):{//levels 1-3
				lower = 1;
				higher = 3;
				break;
			}
		default:{
				lower = 1;
				higher = 80;
				Debug.Log ("Error with guild level when making new ally");
				break;
			}
		}
		int level = (int)Random.Range (lower, higher+1);//max is exclusive, so put in max+1 to get max
	}
}
