using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Change : MonoBehaviour     //手柄原盘切换手柄模型代码
{
    SteamVR_TrackedObject trackedObj; //引用脚本代码
    public GameObject knife;
    public GameObject tweezers;
    public GameObject scissors;
    public GameObject Model;

    // Use this for initialization
    void Start()
    {
        trackedObj = this.transform.GetComponent<SteamVR_TrackedObject>(); //获取脚本代码
    }

    // Update is called once per frame
    void Update()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);//获取设备功能
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y > 0.5f)
            {
                knife.SetActive(true);
                tweezers.SetActive(false);
                scissors.SetActive(false);
                Model.SetActive(false);
            }
            else if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y < -0.5f)
            {
                knife.SetActive(false);
                tweezers.SetActive(true);
                scissors.SetActive(false);
                Model.SetActive(false);
            }

            else if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x > 0.5f)
            {
                knife.SetActive(false);
                tweezers.SetActive(false);
                scissors.SetActive(true);
                Model.SetActive(false);
            }
            else if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x < -0.5f)
            {
                knife.SetActive(false);
                tweezers.SetActive(false);
                scissors.SetActive(false);
                Model.SetActive(true);
            }
        }
    }
}
