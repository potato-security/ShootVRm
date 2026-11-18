using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {      //僵尸攻击伤害代码

    private float attack = 20;//攻击伤害
    public float attackTime = 1;//攻击所需时长
    private float timer;//攻击开始计时


    void Start()
    {
        timer = 0;
    }
	void Update()
	{
		timer += Time.deltaTime;
	}
    public void OnCollisionStay (Collision col)
    {
        if (timer >= attackTime)
        {
			col.collider.GetComponent<PlayHealth>().TakeDamage(attack);
			timer = 0;
        }
    }
}
