using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {      //按钮转换场景代码

	public void BtnDown()
    {
        SceneManager.LoadScene("final");
    }
}
