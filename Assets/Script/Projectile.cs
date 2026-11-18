using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {   //随机生成并范围发射
    public static Projectile Instance;
    public GameObject Prefabs;
	// Use this for initialization
	void Awake () {
        Projectile.Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ProjectileCube()
    {
        GameObject temp = GameObject.Instantiate<GameObject>(Prefabs);//实例化
        Vector3 RandomVec3 = Random.onUnitSphere;//采用球表面积随机数定为发射方向
        RandomVec3.y = Random.Range(10, 15);//随机数限定
        temp.GetComponent<Rigidbody>().velocity = RandomVec3;
    }
}
