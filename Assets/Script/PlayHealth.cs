using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayHealth : MonoBehaviour {       //玩家血量状态代码
    public float hp = 100;
    public Slider slider;
    public Text text;
    public Text text1;
    public float time = 0;
    public GameObject image;
    void Update()
    {
        if (this.hp <= 0)
        {
            time += Time.deltaTime;
            Debug.Log(time);
            if (time >= 3)
            {
                TakeDamage(20);
                SceneManager.LoadScene("Bathroom");
            }
        }
    }

    public void TakeDamage(float damage)//遭受伤害
    {
        if (hp <= 0) return;
        this.hp -= damage;  //减血
        slider.value = hp * 0.01f;
        if (this.hp <= 0)  //再次判断
        {
            image.SetActive(true);
            text.text = "您已死亡";
            text1.text = "5秒后自动返回大厅！";
        }
    }

}
