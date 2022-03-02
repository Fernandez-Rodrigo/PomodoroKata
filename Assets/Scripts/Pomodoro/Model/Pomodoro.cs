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
        state = "Parado";

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

    
}
