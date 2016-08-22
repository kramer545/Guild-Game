using UnityEngine;
using System.Collections.Generic;
using System;

public class orderVisual : MonoBehaviour {

	public BattleManager manager;
	public GameObject[] units = new GameObject[9];
	public Queue <Sprite> sprites = new Queue<Sprite>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void moveOrder()
	{
		for(int x = 0;x<8;x++)
		{
			units [x].GetComponent<SpriteRenderer> ().sprite = units [x + 1].GetComponent<SpriteRenderer> ().sprite;
		}
		if(sprites.Count > 0)
			units [8].GetComponent<SpriteRenderer> ().sprite = sprites.Dequeue ();
	}
}
