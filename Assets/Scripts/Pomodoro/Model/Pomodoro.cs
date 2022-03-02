using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pomodoro 
{
    private float timeLeft;
    private string state;
    System.Threading.Timer TheTimer = null;
    public Pomodoro()
    {
        timeLeft = 25;
        state = "Stoped";

        //TheTimer = new System.Threading.Timer(
        //this.Tick, null, 0, 500);
    }

    public float GetTimeLeft()
    {
        return timeLeft;
    }

    public void SetTimeLeft(float selectedTime)
    {
        timeLeft = selectedTime;
    }

    public string GetState()
    {
        return state;
    }

    public void CountDown()
    {
        timeLeft = state == "Initialized" ? timeLeft - 1 : timeLeft;
        if (timeLeft <= 0)
        {
            SetResting();
        }
    }

    //public void SetState(string _state)
    //{
    //    state = _state;
    //}
    public void SetInitialized()
    {
        state = "Initialized";
    }
    public void SetStoped()
    {
        state = "Stoped";
    }
    public void SetResting()
    {
        state = "Resting";
    }
    public void SetFinished()
    {
        state = "Finished";
    }
}
