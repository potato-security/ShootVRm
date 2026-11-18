using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Games : MonoBehaviour {    //手柄枪模型代码
    SteamVR_TrackedObject trackedObj; //引用脚本代码

   // FixedJoint joint;//添加固定关节

    bool Gun = false;

    public GameObject GunMesh;//枪模型
    // Use this for initialization
    void Start () {
        trackedObj = this.transform.parent.GetComponent<SteamVR_TrackedObject>(); //获取脚本代码

    }
	
	// Update is called once per frame
	void Update () {
        if (!Gun)
        {
            SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);//获取设备功能
            if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
           {
                Projectile.Instance.ProjectileCube();
            }
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.name != "Uzi")
        {
            return;
        }
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);//获取设备功能
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            //   joint = this.gameObject.AddComponent<FixedJoint>();//添加固定关节
            //  joint.connectedBody = GetComponent<Collider>().GetComponent<Rigidbody>();//做连接（跟那个东西连接  连接位置  Rigidbody）
            GunMesh.SetActive(true);
            this.gameObject.SetActive(false);
            collider.gameObject.SetActive(false);  //隐藏地上的枪
        }
    }
    void OnTriggerEnter(Collider collider)
    {

        if (collider.name != "Uzi")
        {
            return;
        }
        Gun = true;
    }
    void OnTriggerExit(Collider collider)
    {

        if (collider.name != "Uzi")
        {
            return;
        }
        Gun = false;
    }
}
