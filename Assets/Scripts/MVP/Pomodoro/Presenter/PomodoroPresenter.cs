using Assets.Scripts.Pomodoro.Enums;
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

    public float GetStudyTime()
    {
        return pomodoro.GetStudyTime();
    }
    public float GetRestingTime()
    {
        return pomodoro.GetRestingTime();
    }
    public void SetStudyTime(float time)
    {
        pomodoro.SetStudyAndRestingTime(time);
    }
    public void StudyCountDown()
    {
        pomodoro.StudyCountDown();
    }
    public void RestingCountDown()
    {
        pomodoro.RestingCountDown();
    }
    public void SetResting()
    {
        pomodoro.SetResting();
    }
    public void SetInitialized()
    {
        pomodoro.SetInitialized();
    }
    public void SetStoped()
    {
        pomodoro.SetStoped();
    }
    public void SetFinished()
    {
        pomodoro.SetFinished();
    }
    public States GetState()
    {
        return pomodoro.GetState();
    }
    public float GetDefaultInitTime()
    {
        return pomodoro.GetDefaultInitTime();
    }
}
