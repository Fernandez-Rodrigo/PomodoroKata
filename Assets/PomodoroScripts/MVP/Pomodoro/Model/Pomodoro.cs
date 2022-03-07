using Assets.Scripts.Pomodoro.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pomodoro 
{
    //TODO: SEPARAR EL MODELO EN 3 CLASES, una que maneje los pomodoros, uno los descansos, y otro el ciclo.
    private const float DEFAULT_INIT_TIME = 25;
    private float totalRestingTime;
    private float restingTime;
    private float initialTime;
    private float timeLeft;
    private States state;
    private float finalRestingTime;
    public Pomodoro()
    {
        timeLeft = DEFAULT_INIT_TIME;
        state = States.Starting;
        restingTime = 5;
    }

    public float GetStudyTime()
    {
        return timeLeft;
    }
    public void SetStudyAndRestingTime(float selectedTime)
    {
        timeLeft = selectedTime;
        restingTime = Mathf.Floor(selectedTime  * 5 / 25);
        if (restingTime == 0) restingTime = 1;
        initialTime = selectedTime;
        totalRestingTime = restingTime;
        //  finalRestingTime = totalRestingTime * 4;
        finalRestingTime = 10;
    }
    public float GetRestingTime()
    {
        return restingTime;
    }
    public float GetInitialTime()
    {
        return initialTime;
    }
    public float GetTotalRestingTime()
    {
        return totalRestingTime;
    }
    public States GetState()
    {
        return state;
    }
    public void StudyCountDown()
    {
        timeLeft = state == States.Initialized ? timeLeft - 1 : timeLeft;
        if (timeLeft <= 0)
        {
            SetResting();
        }
    }
    public void RestingCountDown()
    {
        restingTime = state == States.Resting ? restingTime - 1 : restingTime;
        if (restingTime <= 0)
        {
            SetFinished();
        }
    }
    public void FinalRestingCountDown()
    {
        finalRestingTime--;
    }
    public void SetInitialized()
    {
        state = States.Initialized;
    }
    public void SetStoped()
    {
        state = States.Stoped;
    }
    public void SetStarting()
    {
        state = States.Starting;
    }
    public void SetResting()
    {
        state = States.Resting;
    }
    public void SetFinished()
    {
        state = States.Finished;
    }
    public float GetDefaultInitTime() {
        return DEFAULT_INIT_TIME;
    }
    public float GetFinalRestingTime() {
        return finalRestingTime;
    }
}
