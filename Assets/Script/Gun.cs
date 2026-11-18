using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Gun : MonoBehaviour {      //枪扣动扳机效果代码


    SteamVR_TrackedObject trackedObj; //引用脚本代码

    public Transform GunPoint;
    public LineRenderer Line;
    public GameObject RayPoint;
    public GameObject gun;
    public GameObject shell;
    private float attack = 20;

    // Use this for initialization
    void Start () {
        trackedObj = this.transform.parent.GetComponent<SteamVR_TrackedObject>(); //获取脚本代码
        
    }
	
	// Update is called once per frame
	void Update () {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);//获取设备功能
        Ray ray = new Ray(GunPoint.position, GunPoint.forward);
        Line.SetPosition(0, ray.origin);
        //Animation animation = gun.GetComponent<Animation>();
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,100))
        {
            RayPoint.SetActive(true);
            RayPoint.transform.position = hit.point;
            Line.SetPosition(1, hit.point);
            if(hit.transform.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<EnemyHp3>().TakeDamage(attack);
            }
            //if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            //{
                
                //animation.wrapMode = WrapMode.Once;
                //animation.Play();
                //shell.SetActive(true);
                //if (hit.transform.tag == "Cube")
                //{
                 //   hit.transform.GetComponent<Rigidbody>().AddForce(ray.direction * 800);//标签cube被扣动扳机后受力
                

                //}
            //}
           // else if(device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            //{
                //shell.SetActive(false);
           // }
            
        }
        else
        {
            //animation.wrapMode = WrapMode.Once;
            //animation.Play();
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                //shell.SetActive(true);
            }
            else if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                //shell.SetActive(false);
            }
            RayPoint.SetActive(false);
            Line.SetPosition(1, ray.direction * 100);//射线起点终点
        }
	}
}
