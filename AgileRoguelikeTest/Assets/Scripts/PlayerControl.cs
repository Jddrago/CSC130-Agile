using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    [SerializeField]
    public GameObject Char;

	// Use this for initialization
	void Start () {
        Char.GetComponent<SpriteRenderer>().sprite = GlobalCharacterControl.Instance.Character.GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveToGlobal()
    {
        //Debug.Log(Char.GetComponent<SpriteRenderer>().sprite);
        GlobalCharacterControl.Instance.Character.GetComponent<SpriteRenderer>().sprite = Char.GetComponent<SpriteRenderer>().sprite;
        //Debug.Log(GlobalCharacterControl.Instance.Character.GetComponent<SpriteRenderer>().sprite);
        //Debug.Log(GlobalCharacterControl.Instance);
    }

}
