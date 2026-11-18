using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class AddSpeechTestNoneless : MonoBehaviour  //口音判断代码
{
    public string[] keyWords = new string[] { "开始游戏", "开始", "退出游戏", "结束游戏", "退出" };
    // Use this for initialization
    public ConfidenceLevel confidenLevel = ConfidenceLevel.Medium;//置信度（中）
    PhraseRecognizer recognizer;//短语识别器
    void Start()
    {
        recognizer = new KeywordRecognizer(keyWords, confidenLevel);
        recognizer.OnPhraseRecognized += Display;  // 注册事件
        recognizer.Start();
    }

    public void Display(PhraseRecognizedEventArgs args)
    {
        string str = args.text;
        if (str == "开始游戏" || str == "开始")
        {
            SceneManager.LoadScene("final");
        }
        if (str == "退出游戏" || str == "退出" || str == "结束游戏")
        {
            SceneManager.LoadScene("Bathroom");

            //初始化各类信息
            //初始化各类信息
        }
    }
}