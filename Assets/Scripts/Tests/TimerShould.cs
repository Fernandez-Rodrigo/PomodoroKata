using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TimerShould
{
    
    

    [Test]
    public void TimerShouldSimplePasses()
    {
        
    }

    [Test]
    public void StartAtTwentyFiveMinutesByDefault()
    {
        //Arrange
        Pomodoro pomodoro = new Pomodoro();

        //Assert
        Assert.AreEqual(25, pomodoro.GetTimeLeft());
    }

    [Test]
    public void LetUserSetUpTimer()
    {
        //Arrange
        Pomodoro pomodoro = new Pomodoro();

        //Act
        pomodoro.SetTimeLeft(50);

        //Assert
        Assert.AreEqual(50, pomodoro.GetTimeLeft());
    }

    [Test]
    public void StartAtParadoState()
    {
        //Arrange
        Pomodoro pomodoro = new Pomodoro();

        //Act
        pomodoro.GetState();

        //Assert
        Assert.AreEqual("Stoped", pomodoro.GetState());
    }

    [Test]
    public void RestTimeWhenCountdown()
    {
        //Arrange
        Pomodoro pomodoro = new Pomodoro();
        float timeStart = pomodoro.GetTimeLeft();
        pomodoro.SetInitialized();
        //Act
        pomodoro.CountDown();
        float timeBeforeCountdown = pomodoro.GetTimeLeft();

        //Assert
        Assert.Less(timeBeforeCountdown, timeStart);
    }

    [Test]
    public void CantFinishIfIsNotResting()
    {
        //Arrange
        Pomodoro pomodoro = new Pomodoro();
        string timeStart = pomodoro.GetState();
        //Act

    }
    [Test]
    public void CantRestIfIsNotInitialized()
    {
        //Arrange
        Pomodoro pomodoro = new Pomodoro();
        string timeStart = pomodoro.GetState();
        //Act

    }

}



public class PomodoroStoped : IPomodoroStates
{
    private float timeLeft;
    public PomodoroStoped()
    {
        timeLeft = 25;
    }
    /*ESTADOS
     * PARADO
     * Inicializado / corriendo
     * DETENIDO / Finalizado
     * Descanso
     */
    public float GetTimeLeft()
    {
        return timeLeft;
    }

    public void SetTimeLeft(float selectedTime)
    {
        timeLeft = selectedTime;
    }
}


public class PomodoroInitialized : IPomodoroStates
{
    private float timeLeft;
    public PomodoroInitialized(float _timeLeft)
    {
        timeLeft = _timeLeft;
    }

    public float GetTimeLeft()
    {
        return timeLeft;
    }
    
}
public interface IPomodoroStates {
    float GetTimeLeft();
}


