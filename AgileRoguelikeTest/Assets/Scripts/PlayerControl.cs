using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public GameObject Char;

	// Use this for initialization
	void Start () {
        Char = GlobalCharacterControl.Instance.Char;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveToGlobal()
    {
        GlobalCharacterControl.Instance.Char = Char;
    }

}
