using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Pomodoro.Enums;

public class MainSceneView : MonoBehaviour
{
    public InputField timeInput;
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button stopButton;
    [SerializeField]
    private PomodoroView[] pomodoroView;
    private int currentPomodoroIndex;
    private PomodoroView currentPomodoro;
    void Start()
    {
        currentPomodoro = pomodoroView[0];
        currentPomodoroIndex = 0;
        timeInput.text = currentPomodoro._pomodoroPresenter.GetDefaultInitTime().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = currentPomodoro.GetCurrentStudyTime().ToString();
    }

    public void ChangeCurrentPomodoro()
    {
        currentPomodoroIndex++;
        if (currentPomodoroIndex == pomodoroView.Length) {
            //TODO: ultimo descanso
            currentPomodoroIndex = 0;
            return;
        }
        currentPomodoro = pomodoroView[currentPomodoroIndex];
        currentPomodoro.GetComponent<PomodoroView>().enabled = true;
        //StartCoroutine(StartNextPomodoro());
        SetStartTime();
        StartCountDown();
    }
    public void SetStartTime()
    {
        if (timeInput.text.StartsWith("-")) timeInput.text = "";
        currentPomodoro._pomodoroPresenter.SetStudyTime(timeInput.text == "" ? 0 : float.Parse(timeInput.text));
    }
    public void SetInputStartStopState(bool inputBtnState, bool startBtnState, bool stopBtnState)
    {
        SwitchDisableInput(inputBtnState, timeInput);
        SwitchDisableButton(startBtnState, startButton);
        SwitchDisableButton(stopBtnState, stopButton);
    }
    public void SwitchDisableButton(bool isActive, Button btn)
    {
        btn.enabled = isActive;
        btn.GetComponent<Image>().color = isActive ? Color.white : Color.grey;
    }
    public void SwitchDisableInput(bool isActive, InputField inp)
    {
        inp.enabled = isActive;
        inp.GetComponent<Image>().color = isActive ? Color.white : Color.grey;
    }
    public void StartCountDown()
    {
        if (currentPomodoro._pomodoroPresenter.GetState() == States.Initialized) return;
        currentPomodoro._pomodoroPresenter.SetInitialized();
        StartCoroutine(currentPomodoro.CountDown());
    }
    public void StopCountDown()
    {
        currentPomodoro._pomodoroPresenter.SetStoped();
        StopAllCoroutines();
    }
}
