﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public int hp = 4;



	// Use this for initialization
	void Start () {
		
	}

    public void DamageWall(int loss)
    {
        hp -= loss;
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
