using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PomodoroView : MonoBehaviour, IPomodoroView
{
    [SerializeField]
    private InputField timeInput;
    PomodoroPresenter _pomodoroPresenter;
    private bool countDown = false;
    void Start()
    {
       _pomodoroPresenter = new PomodoroPresenter(this);
    }

    void Update()
    {
        if (countDown)
            RestTime();
    }

    public float GetTime()
    {//TODO: cambiar
        return float.Parse(timeInput.text); 
    }

    private void RestTime()
    {
        _pomodoroPresenter.SetTimeLeft(_pomodoroPresenter.GetTimeLeft() - Time.deltaTime);
    }

    public void StartCountDown()
    {
        countDown = true;
    }

    public void StopCountDown()
    {
        countDown = false;
    }
       
}
