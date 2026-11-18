using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp3 : MonoBehaviour {     //第三类僵尸受伤状态代码
    private int score;
    public float hp = 100;
    public float time = 0;

    //private Animator anim;

    void Awake()
    {
        //anim = this.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            TakeDamage(20);
            Debug.Log("减血");
        };
    }

    public void TakeDamage(float damage)//遭受伤害
    {
        if (hp <= 0) return;
        this.hp -= damage;  //减血

        if (this.hp <= 0)  //再次判断
        {
            //anim.SetBool("Death", true);
            Destroy(gameObject, time);
            score = score+100;
            Debug.Log(score);
            PlayerPrefs.SetInt("Score", score);
        }
    }
}
