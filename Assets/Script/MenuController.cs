using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class MenuController : MonoBehaviour {       //菜单材质切换代码
    public SteamVR_TrackedObject trackedObj;
    public Renderer BtnRender; //读取某物体材质组件
    public Material BtnMat;
    public Material BtnMat2;//新材质
    void OnTriggerStay(Collider collider)
    {
        StartButton StartBtn = collider.GetComponent<StartButton>();

        if (StartBtn !=null)
        {
            SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
            if(device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                StartBtn.BtnDown();
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        BtnRender.material = BtnMat2;
    }
    void OnTriggerExit(Collider collider)
    {
        BtnRender.material = BtnMat;
    }
}
