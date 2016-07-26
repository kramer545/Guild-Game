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
		enemyClass enemy;
		allyClass ally;
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
				enemy = new enemyClass();
				enemy.create ("Test DPS", stats, 0,0,enemies[0]);
				manager.dps [0] = enemy;
				//dps 2
				enemy = new enemyClass();
				enemy.create ("Test DPS 2", stats, 0,0,enemies[1]);
				manager.dps [1] = enemy;
				//tank
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
				enemy = new enemyClass();
				enemy.create ("Test Tank", stats, 4,0,enemies[2]);
				manager.tanks[0] = enemy;
				//tank 2
				enemy = new enemyClass();
				enemy.create ("Test Tank 2", stats, 4,0,enemies[3]);
				manager.tanks[1] = enemy;
				//healer
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
				enemy = new enemyClass();
				enemy.create ("Test healer", stats, 8,0,enemies[4]);
				manager.healers[0] = enemy;
				manager.enemys [0] = manager.dps [0];
				manager.enemys [1] = manager.dps [1];
				manager.enemys [2] = manager.tanks [0];
				manager.enemys [3] = manager.tanks [1];
				manager.enemys [4] = manager.healers [0];

				//allys now
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
				ally = new allyClass();
				ally.create ("Test DPS ally", stats,0, 0,allies[0]);
				ally.weaponMain = new weaponClass();
				ally.weaponMain.create (0, "Test Weapon 1", 0, wStats, 0, 0, 75, 0);
				ally.updateChar();
				manager.party [0] = ally;
				//dps 2
				ally = new allyClass();
				ally.create ("Test DPS 2 ally", stats,0, 0,allies[1]);
				ally.weaponMain = new weaponClass();
				ally.weaponMain.create (0, "Test Weapon 1", 0, wStats, 0, 0, 75, 0);
				ally.updateChar();
				manager.party [1] = ally;
				//tank
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
				ally = new allyClass();
				ally.create ("Test Tank ally", stats,0, 4,allies[2]);
				ally.weaponMain = new weaponClass();
				ally.weaponMain.create (0, "Test Weapon 1", 0, wStats, 0, 0, 75, 0);
				ally.updateChar();
				manager.party[2] = ally;
				//tank 2
				ally = new allyClass();
				ally.create ("Test Tank 2 ally", stats,0, 4,allies[3]);
				ally.weaponMain = new weaponClass();
				ally.weaponMain.create (0, "Test Weapon 1", 0, wStats, 0, 0, 75, 0);
				ally.updateChar();
				manager.party[3] = ally;
				//healer
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
				ally = new allyClass();
				ally.create ("Test healer ally", stats,0,8,allies[4]);
				ally.weaponMain = new weaponClass();
				ally.weaponMain.create (0, "Test Weapon 1", 0, wStats, 0, 0, 75, 0);
				ally.updateChar();
				manager.party[4] = ally;
				break;
			}
		}
	}
}
