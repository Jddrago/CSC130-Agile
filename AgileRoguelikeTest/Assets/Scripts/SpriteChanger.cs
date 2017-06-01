using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour {

    public GameObject image,player;
    public Sprite sprite1,sprite2,sprite3,sprite4;
    public RuntimeAnimatorController player1,player2,player3,player4;

    public void ChangeSprites()
    {
        if (image.GetComponent<Image>().sprite.Equals(sprite1))
        {
            image.GetComponent<Image>().sprite = sprite2;
            player.GetComponent<Animator>().runtimeAnimatorController = player2;
        }
        else if (image.GetComponent<Image>().sprite.Equals(sprite2))
        {
            image.GetComponent<Image>().sprite = sprite3;
            player.GetComponent<Animator>().runtimeAnimatorController = player3;
        }
        else if (image.GetComponent<Image>().sprite.Equals(sprite3))
        {
            image.GetComponent<Image>().sprite = sprite4;
            player.GetComponent<Animator>().runtimeAnimatorController = player4;
        }
        else if (image.GetComponent<Image>().sprite.Equals(sprite4))
        {
            image.GetComponent<Image>().sprite = sprite1;
            player.GetComponent<Animator>().runtimeAnimatorController = player1;
        }
    }
}
