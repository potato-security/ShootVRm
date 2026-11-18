using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombies3 : MonoBehaviour   //第三类地方受伤状态代码
{
    public float attackDistance = 2;
    public float findDistance = 10;
    public float Speed = 1;
    Vector3 Goal = new Vector3(200, 10, 100);
    private Animator anim;
    public Transform player;
    private NavMeshAgent agent;
    // Use this for initialization

    void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        anim = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        Debug.Log(distance);
        if (distance < findDistance)
        {//追
            anim.SetBool("Find", true);
            agent.SetDestination(player.position);
            if (distance < attackDistance)
            {//攻击
                anim.SetBool("Attack", true);
                agent.ResetPath();
            }
            else
            {//睡眠
                anim.SetBool("Attack", false);
                agent.SetDestination(player.position);
            }
        }
        else
        {//睡眠
            anim.SetBool("Find", false);
            agent.ResetPath();
        }
    }
}

