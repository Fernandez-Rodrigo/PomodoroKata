using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Assets.Scripts.Pomodoro.Enums;

public class PomodoroView : MonoBehaviour, IPomodoroView
{

    public Image loadingBar;
    [SerializeField]
    private Image restingLoadingBar;
    [SerializeField]
    private TextMeshProUGUI pomodoroText;
    [SerializeField]
    private TextMeshProUGUI pomodoroStateText;
    [SerializeField]
    private MainSceneView mainSceneView;

    public PomodoroPresenter _pomodoroPresenter;

    private float counter;
    void Awake()
    {
        _pomodoroPresenter = new PomodoroPresenter(this);
    }

    void Update()
    {
        ManageStates();
        _pomodoroPresenter.ManageStates();
        //TODO : hacerlo con unirx
        _pomodoroPresenter.RefreshFillAmount();
        _pomodoroPresenter.RefreshRestingFillAmount();

        _pomodoroPresenter.RefreshStateText();
    }
    public void SetStateText(string str)
    {
        pomodoroStateText.text = str;
    }
    public void SetPomodoroTimeText(string str)
    {
        pomodoroText.text = str;
    }
    public void SetLoadingBarFillAmount(float fillAmount)
    {
        loadingBar.fillAmount = fillAmount;
    }
    public void SetRestingBarFillAmount(float fillAmount)
    {
        restingLoadingBar.fillAmount = fillAmount;
    }
    public float GetCurrentStudyTime()
    {
        return _pomodoroPresenter.GetStudyTime();
    }
    public float GetCurrentRestingTime()
    {
        return _pomodoroPresenter.GetRestingTime();
    }

    public IEnumerator CountDown()
    {
        for (counter = GetCurrentStudyTime(); counter > 0; counter--)
        {
            yield return new WaitForSeconds(1);
            _pomodoroPresenter.StudyCountDown();
            Debug.Log(GetCurrentStudyTime());
        }
        StartCoroutine(RestCountDown());
    }

    IEnumerator RestCountDown()
    {
        for (counter = _pomodoroPresenter.GetRestingTime(); counter > 0; counter--)
        {
            yield return new WaitForSeconds(1);
            _pomodoroPresenter.RestingCountDown();
            Debug.Log(GetCurrentRestingTime());
        }
        yield return new WaitForSeconds(1);
        mainSceneView.ChangeCurrentPomodoro();
    }
    private void ManageStates()
    {
        switch (_pomodoroPresenter.GetState())
        {
            case States.Stoped:
                mainSceneView.SetInputStartStopState(false, true, false);
                break;
            case States.Starting:
                mainSceneView.SetStartTime();
                mainSceneView.SetInputStartStopState(true, true, false);
                break;
            case States.Initialized:
                mainSceneView.SetInputStartStopState(false, false, true);
                break;
            case States.Resting:
                mainSceneView.SetInputStartStopState(false, false, false);
                break;
            case States.Finished:
                break;
        }
    }
}
