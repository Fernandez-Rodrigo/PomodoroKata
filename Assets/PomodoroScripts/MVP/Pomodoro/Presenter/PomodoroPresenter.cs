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

    public void RefreshFillAmount() {
        float result = pomodoro.GetStudyTime() / pomodoro.GetInitialTime();
        pomodoroView.SetLoadingBarFillAmount(result);
    }
    public Pomodoro GetPomodoro() {
        return pomodoro;
    }
    public void RefreshRestingFillAmount()
    {
        float result = pomodoro.GetRestingTime() / pomodoro.GetTotalRestingTime();
        pomodoroView.SetRestingBarFillAmount(result);
    }
    public void RefreshStateText() {
        pomodoroView.SetStateText(pomodoro.GetState().ToString());
    }
    public void ManageStates() {
        switch (pomodoro.GetState())
        {
            case States.Starting:
                pomodoroView.SetPomodoroTimeText(pomodoro.GetStudyTime().ToString());
              //  pomodoro.SetStudyAndRestingTime();
                break;
            case States.Initialized:
                RefreshFillAmount();
                pomodoroView.SetPomodoroTimeText(pomodoro.GetStudyTime().ToString());
                break;
            case States.Resting:
                RefreshRestingFillAmount();
                pomodoroView.SetPomodoroTimeText(pomodoro.GetRestingTime().ToString());
                break;
            case States.Finished:
                pomodoroView.SetPomodoroTimeText(pomodoro.GetRestingTime().ToString());
                break;
        }
    }

    #region
    public float GetStudyTime()
    {
        return pomodoro.GetStudyTime();
    }
    public float GetRestingTime()
    {
        return pomodoro.GetRestingTime();
    }
    public float GetTotalRestingTime()
    {
        return pomodoro.GetTotalRestingTime();
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
    public void FinalRestingCountDown()
    {
        pomodoro.FinalRestingCountDown();
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
    public void SetStarting()
    {
        pomodoro.SetStarting();
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
    public float GetFinalRestingTime()
    {
        return pomodoro.GetFinalRestingTime();
    }
    #endregion
}
