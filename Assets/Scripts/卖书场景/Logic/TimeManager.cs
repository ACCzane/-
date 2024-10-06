using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Singleton;
    public int day;
    public int hour;
    public int minute;

    private void Awake() {
        if (Singleton != null) return;
        Singleton = this;
    }

    public void StartNewDay(int hour){
        day++;
        this.hour = hour;
        minute = 0;
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
}
