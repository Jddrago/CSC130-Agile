using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MovingObject {

    private Animator animator;
    public float restartLevelDelay = 1;
    private int playerHP = 10;
    public Text PlayerHealthText;

    protected override void OnCantMove<T>(T component)
    {
        if (component.tag == "Enemy")
        {
            Enemy hitEnemy = component as Enemy;
            hitEnemy.DamageEnemy(baseDamage);
        }
        else
        {
            Wall hitWall = component as Wall;
            if(hitWall.tag != "OuterWall")
            {
                hitWall.DamageWall(baseDamage);
            }
        }
    }

    // Use this for initialization
    protected override void Start () {
        animator = GetComponent<Animator>();
        playerHP = GlobalCharacterControl.Instance.playerHP;
        PlayerHealthText.text = "HP: " + playerHP;
        base.Start();
	}

    public void SaveToGlobal()
    {
        GlobalCharacterControl.Instance.playerHP = playerHP;
    }

    protected override void AttempedMove<T>(int xDir, int yDir)
    {
        base.AttempedMove<T>(xDir, yDir);
        RaycastHit2D hit;
        if (Move(xDir, yDir, out hit)) { }
        GameManager.instance.playersTurn = false;
    }

    // Update is called once per frame
    void Update () {
        if (!GameManager.instance.playersTurn) return;
        int horizontal = 0;
        int vertical = 0;
        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");
        if (horizontal != 0)
        {
            vertical = 0;
            if (horizontal < 0) { animator.SetTrigger("walkWest"); }
            else if (horizontal > 0) { animator.SetTrigger("walkEast"); }
        }
        if (horizontal != 0 || vertical != 0)
        {
            if (horizontal == 0 && vertical < 0) { animator.SetTrigger("walkSouth"); }
            else if (horizontal == 0 && vertical > 0) { animator.SetTrigger("walkNorth"); }
            AttempedMove<Wall>(horizontal, vertical);
        }
        animator.SetTrigger("Idle");
        SaveToGlobal();
    }

    private void Restart()
    {
        SceneManager.LoadScene(2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Exit")
        {
            Invoke("Restart",restartLevelDelay);
            //enabled = false;
        }
    }

    public void DamagePlayer(int loss)
    {
        playerHP -= loss;
        PlayerHealthText.text = "HP: " + playerHP;
        CheckForGameOver();
    }

    private void CheckForGameOver()
    {
        if (playerHP <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
