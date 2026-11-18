using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Move: MonoBehaviour       //手柄圆盘控制移动代码（未优化，强行移动）
{  // 手柄位置

    SteamVR_TrackedObject tracked;
   // Camera
    public Transform mCamera;
    //头盔
    public Transform mCameraHead;
    //public GameObject mCameraHead1;
    // 速度
    public float speed;
   // Vector3 rz;

    void Awake()
    {        //获取手柄控制
        tracked = GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start()
    {
        transform.localEulerAngles = new Vector3(0, mCameraHead.localEulerAngles.y, 0);
        transform.localPosition = new Vector3(mCameraHead.localPosition.x, 0, mCameraHead.localPosition.z);
       // rz = new Vector3(0, 0, mCameraHead1.transform.position.z);
    }

    // Update is called once per frame
    void Update()

    {
        
   //     Vector3 rz = new Vector3(0, 0, mCameraHead1.transform.position.z);
        var deviceright = SteamVR_Controller.Input((int)tracked.index);
        //按下圆盘键
        
         if (deviceright.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
         {
            
                Vector2 ve = deviceright.GetAxis();
                float angle = VectorAngle(new Vector2(1, 0), ve);
                //下
                if (angle > 45 && angle < 135)
                {
                    mCamera.Translate(-mCameraHead.forward * Time.deltaTime * speed);
                }
                //上
                else if (angle < -45 && angle > -135)
                {
                    //Debug.Log("上");
                    mCamera.Translate(mCameraHead.forward * Time.deltaTime * speed);
                }
                //左
                else if ((angle < 180 && angle > 135) || (angle < -135 && angle > -180))
                {
                    //Debug.Log("左");
                    mCamera.Translate(-mCameraHead.right * Time.deltaTime * speed);
                }
                //右
                else if ((angle > 0 && angle < 45) || (angle > -45 && angle < 0))
                {
                    //Debug.Log("右");
                    mCamera.Translate(mCameraHead.right * Time.deltaTime * speed);
                }
            
            
        }
    }   // 根据在圆盘才按下的位置，返回一个角度值

    float VectorAngle(Vector2 from, Vector2 to)
    {
        float angle;
        Vector3 cross = Vector3.Cross(from, to);
        angle = Vector2.Angle(from, to);
        return cross.z > 0 ? -angle : angle;//三木运算
  //      Vector3 mCamearaHeadZ = mCameraHead1.transform.position;
 //        mCamearaHeadZ.z= rz.z;
    }
}
