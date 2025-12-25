using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    private float showWoning = 1f;//渐变过程时间
    private float isShowWon = 1f;//持续时间

    public GameObject Player;//游戏角色
    public CanvasGroup canvasGroupWon;
    public CanvasGroup canvasGroupFail;

    public AudioSource winAudio;
    public AudioSource failAudio;

    bool isWon=false;
    bool isFail = false;
    bool isplay = false;
    void OnTriggerEnter(Collider other)//检测其他碰撞体碰到自己，并获取其他碰撞体
    {
        if(other.gameObject==Player)//判断是否是游戏角色碰撞
        {
            isWon = true;
        }
    }

    public void GameIsFail()
    {
        isFail = true;
    }
    float timeCon = 0;
    void Update()
    {
        if(isWon)
        {
            isplay = true;
            EndShowWonTime(canvasGroupWon,false,winAudio,isplay);
        }
        else if(isFail)
        {
            //print("IsFail");
            isplay = true;
            EndShowWonTime(canvasGroupFail, true,failAudio,isplay);
        }
    }

    void EndShowWonTime(CanvasGroup canvasGroup,bool rePlay,AudioSource playAudio,bool isPlay)//游戏结束显示UI
    {
        if(isPlay)
        {
            if(playAudio==null)
            {
                Debug.Log("为空");
            }
            else
            {
                print("不为空");
            }
                playAudio.Play();

            isPlay = false;
        }
        timeCon = timeCon + Time.deltaTime;//逐帧累加时间
        canvasGroup.alpha = timeCon;//渐变过程
        if(timeCon>showWoning+isShowWon)
        {
            if(rePlay)
            {
                SceneManager.LoadScene(0);//重新加载游戏
            }
            else if(!rePlay)
            {
                Application.Quit();//游戏结束
            }
        }
    }
}
