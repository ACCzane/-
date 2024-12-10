using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Rendering;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Singleton;
    public int day;
    public int hour;
    public int minute;

    private bool isCountingTime = false;
    private float duration = 0;
    private int mySpeed;

    private void Awake() {
        if(Singleton != null&&Singleton != this)
        {
            Destroy(gameObject);
            return;
        }

        Singleton = this;
        DontDestroyOnLoad(gameObject);
        isCountingTime = false;
        EventHandler.UpdateTimeUI += CheckTimer;
    }

    public void StartNewDay(int hour){
        day++;
        this.hour = hour;
        minute = 0;
        isCountingTime = true;
    }

    /// <summary>
    /// 开启一段新计时
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="speed">游戏内10分钟对应现实几秒</param>
    /// <returns></returns>
    public IEnumerator StartNewPeriord(int start, int end, int speed){
        hour = start;
        minute = 0;
        isCountingTime = true;
        mySpeed = speed;

        //TODO:进入时触发

        while(hour < end){
            yield return new WaitForSeconds(1 * speed);
            minute += 10;
            if(minute >= 60){
                minute = minute % 60;
                hour++;
            }
            //更新UI
            EventHandler.UpdateTimeUI(hour, minute);
        }

        //TODO:退出时触发
    }

    private void Update()
    {
        if (isCountingTime == false) return;
        duration += Time.deltaTime;
        if(duration >= mySpeed)
        {
            duration = 0;
            minute += 10;
            if (minute >= 60)
            {
                minute = minute % 60;
                hour++;
            }

            EventHandler.UpdateTimeUI(hour, minute);

            if(hour >= 19)
            {
                isCountingTime = false;
            }
        }
    }

    private void CheckTimer(int a,int b) { }//空函数，用来确保订阅非空
}
