using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    [SerializeField]
    public GameObject Char;
    public Animator animator;

    // Use this for initialization
    void Start () {
        Char.GetComponent<Animator>().runtimeAnimatorController = GlobalCharacterControl.Instance.Character.GetComponent<Animator>().runtimeAnimatorController;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveToGlobal()
    {
        //Debug.Log(Char.GetComponent<SpriteRenderer>().sprite);
        GlobalCharacterControl.Instance.Character.GetComponent<Animator>().runtimeAnimatorController = Char.GetComponent<Animator>().runtimeAnimatorController;
        //Debug.Log(GlobalCharacterControl.Instance.Character.GetComponent<SpriteRenderer>().sprite);
        //Debug.Log(GlobalCharacterControl.Instance);
    }

}
