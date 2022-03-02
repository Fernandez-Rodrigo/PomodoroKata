using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomodoroPresenter
{
    IPomodoroView pomodoroView;
    Pomodoro pomodoro;
    public PomodoroPresenter(IPomodoroView _pomodoroView)
    {
        pomodoro = new Pomodoro();
        pomodoroView = _pomodoroView;   
    }

    public float GetTimeLeft()
    {
        return pomodoro.GetTimeLeft();
    }

    public void SetTimeLeft(float time)
    {
        pomodoro.SetTimeLeft(time);
    }

}
