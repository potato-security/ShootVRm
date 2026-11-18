using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {        //分数UI代码
    public Text text;
 
	void Start () {
       int scorevule = PlayerPrefs.GetInt("Score");
        text.text = "当前积分为："+ scorevule;
    }
}
