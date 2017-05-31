using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCharacterControl : MonoBehaviour {

    public static GlobalCharacterControl Instance;
    [SerializeField]
    public GameObject Character;
    public int tester;

    void Awake()
    {
        Debug.Log(Instance);
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.Log(Character.GetComponent<SpriteRenderer>().sprite);
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
