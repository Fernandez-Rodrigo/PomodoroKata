using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assets.Scripts.Pomodoro.Enums;

public class PomodoroShould
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
        Assert.AreEqual(25, pomodoro.GetStudyTime());
    }

    [Test]
    public void LetUserSetUpTimer()
    {
        //Arrange
        Pomodoro pomodoro = new Pomodoro();

        //Act
        pomodoro.SetStudyAndRestingTime(50);

        //Assert
        Assert.AreEqual(50, pomodoro.GetStudyTime());
    }

    [Test]
    public void StartAtStopedState()
    {
        //Arrange
        Pomodoro pomodoro = new Pomodoro();

        //Act
        pomodoro.GetState();

        //Assert
        Assert.AreEqual(States.Starting, pomodoro.GetState());
    }

    [Test]
    public void RestTimeWhenCountdown()
    {
        //Arrange
        Pomodoro pomodoro = new Pomodoro();
        float timeStart = pomodoro.GetStudyTime();
        pomodoro.SetInitialized();
        //Act
        pomodoro.StudyCountDown();
        float timeBeforeCountdown = pomodoro.GetStudyTime();

        //Assert
        Assert.Less(timeBeforeCountdown, timeStart);
    }

    [Test]
    public void CalculateRestingTime()
    {
        //Arrange
        Pomodoro pomodoro = new Pomodoro();

        //Act
        pomodoro.SetStudyAndRestingTime(50);

        //Assert
        Assert.AreEqual(10, pomodoro.GetRestingTime());
    }

}



//public class PomodoroStoped : IPomodoroStates
//{
//    private float timeLeft;
//    public PomodoroStoped()
//    {
//        timeLeft = 25;
//    }
//    /*ESTADOS
//     * PARADO
//     * Inicializado / corriendo
//     * DETENIDO / Finalizado
//     * Descanso
//     */
//    public float GetTimeLeft()
//    {
//        return timeLeft;
//    }

//    public void SetTimeLeft(float selectedTime)
//    {
//        timeLeft = selectedTime;
//    }
//}


//public class PomodoroInitialized : IPomodoroStates
//{
//    private float timeLeft;
//    public PomodoroInitialized(float _timeLeft)
//    {
//        timeLeft = _timeLeft;
//    }

//    public float GetTimeLeft()
//    {
//        return timeLeft;
//    }
    
//}
//public interface IPomodoroStates {
//    float GetTimeLeft();
//}


