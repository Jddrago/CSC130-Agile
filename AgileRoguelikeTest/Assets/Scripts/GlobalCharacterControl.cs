using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCharacterControl : MonoBehaviour {

    public static GlobalCharacterControl Instance;
    public GameObject Char;

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

    private void OnDestroy()
    {
        Debug.Log("Global character destroyed.");
    }
}
