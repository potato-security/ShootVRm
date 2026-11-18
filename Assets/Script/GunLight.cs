using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GunLight : MonoBehaviour {     //枪光、频率代码
    SteamVR_TrackedObject trackedObj; //引用脚本代码

    public float shootRate = 2; //射击频率 
    private ParticleSystem particleSystem;

	// Use this for initialization
	void Start () {
        particleSystem = this.GetComponentInChildren<ParticleSystem>();
        trackedObj = this.transform.parent.GetComponent<SteamVR_TrackedObject>(); //获取脚本代码
    }

    // Update is called once per frame
    void Update()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);//获取设备功能
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GetComponent<Light>().enabled = true;  //枪光控制
        particleSystem.Play();

        Invoke("ClearEffec",0.05f);
    }

    void ClearEffec()
    {
        GetComponent<Light>().enabled = false;
    }
}
