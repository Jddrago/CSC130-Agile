using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCharacterControl : MonoBehaviour {

    public static GlobalCharacterControl Instance;
    [SerializeField]
    public GameObject Character;
    public Animator animator;
    public int playerHP = 10;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //Debug.Log("Rawr");
    }

    private void OnDestroy()
    {
        //Debug.Log("Global character destroyed.");
    }
}
