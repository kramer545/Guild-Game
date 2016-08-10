using UnityEngine;
using System.Collections;

public class testDungeon : baseDungeon {


	// Use this for initialization
	public void Start () {
		base.create ("TEST", "For Test Purposes", 1, 100, 50);
		generateEnemys ();
		manager.create ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void generateEnemys()
	{
		//int num = Random.Range (0, 5);
		int num = 0;
		int[] stats = new int[11];
		int[] wStats = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		switch (num) {
		case(0)://2 dps, 2 tank, 1 healer, lvl 5, also includes the same with user party members
			{
				//dps first
				stats [0] = 5;
				stats [1] = 0;
				stats [2] = 20 + (5 * stats [0]);
				stats [3] = 20 + (5 * stats [0]);
				stats [4] = 8 + stats [0];
				stats [5] = 6 + stats [0];
				stats [6] = 6 + (int)(0.5 * stats [0]);
				stats [7] = 2 + (int)(0.2 * stats [0]);
				stats [8] = 4 + (int)(0.25 * stats [0]);
				stats [9] = 6 + (int)(0.5 * stats [0]);
				stats [10] = 0;
				enemies[0].create("Test DPS", stats, 0,0);
				stats = new int[11];
				stats [0] = 5;
				stats [1] = 0;
				stats [2] = 20 + (5 * stats [0]);
				stats [3] = 20 + (5 * stats [0]);
				stats [4] = 8 + stats [0];
				stats [5] = 6 + stats [0];
				stats [6] = 6 + (int)(0.5 * stats [0]);
				stats [7] = 2 + (int)(0.2 * stats [0]);
				stats [8] = 4 + (int)(0.25 * stats [0]);
				stats [9] = 6 + (int)(0.5 * stats [0]);
				stats [10] = 0;
				//dps 2
				enemies[1].create("Test DPS 2", stats, 0,0);
				//tank
				stats = new int[11];
				stats [0] = 5;
				stats [1] = 0;
				stats [2] = 30 + (7 * stats [0]);
				stats [3] = 20 + (5 * stats [0]);
				stats [4] = 7 + (int)(0.5 * stats [0]);
				stats [5] = 8 + stats [0];
				stats [6] = 5 + (int)(0.25 * stats [0]);
				stats [7] = 2 + (int)(0.2 * stats [0]);
				stats [8] = 6 + (int)(0.5 * stats [0]);
				stats [9] = 7 + (int)(0.5 * stats [0]);
				stats [10] = 0;
				enemies[2].create("Test tank", stats, 4,0);
				//tank 2
				stats = new int[11];
				stats [0] = 5;
				stats [1] = 0;
				stats [2] = 30 + (7 * stats [0]);
				stats [3] = 20 + (5 * stats [0]);
				stats [4] = 7 + (int)(0.5 * stats [0]);
				stats [5] = 8 + stats [0];
				stats [6] = 5 + (int)(0.25 * stats [0]);
				stats [7] = 2 + (int)(0.2 * stats [0]);
				stats [8] = 6 + (int)(0.5 * stats [0]);
				stats [9] = 7 + (int)(0.5 * stats [0]);
				stats [10] = 0;
				enemies[3].create("Test tank 2", stats, 4,0);
				//healer
				stats = new int[11];
				stats [0] = 5;
				stats [1] = 0;
				stats [2] = 20 + (4 * stats [0]);
				stats [3] = 50 + (8 * stats [0]);
				stats [4] = 4 + (int)(0.25 * stats [0]);
				stats [5] = 5 + (int)(0.25* stats [0]);
				stats [6] = 7 + (int)(0.5 * stats [0]);
				stats [7] = 8 +  stats [0];
				stats [8] = 6 + (int)(0.5 * stats [0]);
				stats [9] = 8 + (int)(0.5 * stats [0]);
				stats [10] = 0;
				enemies[4].create("Test healer", stats, 8,0);
				manager.enemyDps [0] = enemies [0];
				manager.enemyDps [1] = enemies [1];
				manager.enemyTanks [0] = enemies [2];
				tanks [1] = enemies [3];
				healers [0] = enemies [4];

				//allys now
				//dps first
				stats = new int[11];
				stats [0] = 5;
				stats [1] = 0;
				stats [2] = 20 + (5 * stats [0]);
				stats [3] = 20 + (5 * stats [0]);
				stats [4] = 8 + stats [0];
				stats [5] = 6 + stats [0];
				stats [6] = 6 + (int)(0.5 * stats [0]);
				stats [7] = 2 + (int)(0.2 * stats [0]);
				stats [8] = 4 + (int)(0.25 * stats [0]);
				stats [9] = 6 + (int)(0.5 * stats [0]);
				stats [10] = 0;
				allies[0].create("Test ally dps", stats, 0,0);
				allies[0].weaponMain = new weaponClass();
				allies[0].weaponMain.create (0, "Test Weapon 1", 0, wStats, 0, 0, 75, 0);
				allies[0].updateChar();
				//dps 2
				stats = new int[11];
				stats [0] = 5;
				stats [1] = 0;
				stats [2] = 20 + (5 * stats [0]);
				stats [3] = 20 + (5 * stats [0]);
				stats [4] = 8 + stats [0];
				stats [5] = 6 + stats [0];
				stats [6] = 6 + (int)(0.5 * stats [0]);
				stats [7] = 2 + (int)(0.2 * stats [0]);
				stats [8] = 4 + (int)(0.25 * stats [0]);
				stats [9] = 6 + (int)(0.5 * stats [0]);
				stats [10] = 0;
				allies[1].create("Test ally dps 2", stats, 0,0);
				allies[1].weaponMain = new weaponClass();
				allies[1].weaponMain.create (0, "Test Weapon 2", 0, wStats, 0, 0, 75, 0);
				allies[1].updateChar();
				//tank
				stats = new int[11];
				stats [0] = 5;
				stats [1] = 0;
				stats [2] = 30 + (7 * stats [0]);
				stats [3] = 20 + (5 * stats [0]);
				stats [4] = 7 + (int)(0.5 * stats [0]);
				stats [5] = 8 + stats [0];
				stats [6] = 5 + (int)(0.25 * stats [0]);
				stats [7] = 2 + (int)(0.2 * stats [0]);
				stats [8] = 6 + (int)(0.5 * stats [0]);
				stats [9] = 7 + (int)(0.5 * stats [0]);
				stats [10] = 0;
				allies[2].create("Test ally tank", stats, 4,0);
				allies[2].weaponMain = new weaponClass();
				allies[2].weaponMain.create (0, "Test Weapon 1", 0, wStats, 0, 0, 75, 0);
				allies[2].updateChar();
				//tank 2
				stats = new int[11];
				stats [0] = 5;
				stats [1] = 0;
				stats [2] = 30 + (7 * stats [0]);
				stats [3] = 20 + (5 * stats [0]);
				stats [4] = 7 + (int)(0.5 * stats [0]);
				stats [5] = 8 + stats [0];
				stats [6] = 5 + (int)(0.25 * stats [0]);
				stats [7] = 2 + (int)(0.2 * stats [0]);
				stats [8] = 6 + (int)(0.5 * stats [0]);
				stats [9] = 7 + (int)(0.5 * stats [0]);
				stats [10] = 0;
				allies[3].create("Test ally tank 2", stats, 4,0);
				allies[3].weaponMain = new weaponClass();
				allies[3].weaponMain.create (0, "Test Weapon 1", 0, wStats, 0, 0, 75, 0);
				allies[3].updateChar();
				//healer
				stats = new int[11];
				stats [0] = 5;
				stats [1] = 0;
				stats [2] = 20 + (4 * stats [0]);
				stats [3] = 50 + (8 * stats [0]);
				stats [4] = 4 + (int)(0.25 * stats [0]);
				stats [5] = 5 + (int)(0.25* stats [0]);
				stats [6] = 7 + (int)(0.5 * stats [0]);
				stats [7] = 8 +  stats [0];
				stats [8] = 6 + (int)(0.5 * stats [0]);
				stats [9] = 8 + (int)(0.5 * stats [0]);
				stats [10] = 0;
				allies[4].create("Test ally healer", stats, 8,0);
				allies[4].weaponMain = new weaponClass();
				allies[4].weaponMain.create (0, "Test Weapon 1", 0, wStats, 0, 0, 75, 0);
				allies[4].updateChar();
				manager.enemys [0] = enemies [0];
				manager.enemys [1] = enemies [1];
				manager.enemys [2] = enemies [2];
				manager.enemys [3] = enemies [3];
				manager.enemys [4] = enemies [4];
				manager.party[0] = allies [0];
				manager.party[1] = allies [1];
				manager.party[2] = allies [2];
				manager.party[3] = allies [3];
				manager.party[4] = allies [4];

				break;
			}
		}
	}
}
