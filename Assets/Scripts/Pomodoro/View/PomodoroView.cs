using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PomodoroView : MonoBehaviour, IPomodoroView
{
    [SerializeField]
    private InputField timeInput;
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button stopButton;
    PomodoroPresenter _pomodoroPresenter;
    private float counter;
    private bool restingExecuted;
    void Start()
    {
        _pomodoroPresenter = new PomodoroPresenter(this);
        timeInput.text = "25";
    }

    void Update()
    {
        if (_pomodoroPresenter.GetState() == "Stoped")
        {
            SetStartTime();
            SetInputActive(true);
            SetStartActive(true);
            SetStopActive(false);
        }
        if (_pomodoroPresenter.GetState() == "Initialized")
        {
            SetInputActive(false);
            SetStartActive(false);
            SetStopActive(true);
        }
        if (_pomodoroPresenter.GetState() == "Resting")
        {
            if (!restingExecuted)
            {
                restingExecuted = true;
                StartCoroutine();
            }
            
        }
        
        //TODO : hacerlo con unirx
        timeText.text = GetCurrentTime().ToString();
    }

    public void SetStartTime()
    {//TODO: cambiar
        // TODO: corregir validaciones
        if (timeInput.text != "")
            _pomodoroPresenter.SetTimeLeft(float.Parse(timeInput.text));
    }

    public float GetCurrentTime()
    {
        return _pomodoroPresenter.GetTimeLeft();
    }
    public void StartCountDown()
    {
        if (_pomodoroPresenter.GetState().Equals("Initialized"))
        {
            return;
        }
        _pomodoroPresenter.SetInitialized();
        StartCoroutine(CountDown());
    }
    private void SetInputActive(bool isActive)
    { //TODO: refactorizar
        if (isActive)
        {
            timeInput.enabled = true;
            timeInput.GetComponent<Image>().color = Color.white;
        }
        else
        {
            timeInput.enabled = false;
            timeInput.GetComponent<Image>().color = Color.grey;
        }
    }
    private void SetStartActive(bool isActive)
    {
        if (isActive)
        {
            startButton.enabled = true;
            startButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            startButton.enabled = false;
            startButton.GetComponent<Image>().color = Color.grey;
        }
    }
    private void SetStopActive(bool isActive)
    {
        if (isActive)
        {
            stopButton.enabled = true;
            stopButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            stopButton.enabled = false;
            stopButton.GetComponent<Image>().color = Color.grey;
        }
    }
    public void StopCountDown()
    {
        _pomodoroPresenter.SetStoped();
        StopAllCoroutines();
    }


    IEnumerator CountDown()
    {
        for (counter = GetCurrentTime(); counter > 0; counter--)
        {
            _pomodoroPresenter.CountDown();
            Debug.Log(GetCurrentTime());
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator RestCountDown()
    {
        for (counter = GetRestingTime(); counter > 0; counter--)
        {
            _pomodoroPresenter.RestCountDown();
            yield return new WaitForSeconds(1);
        }
    }
}
