using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Assets.Scripts.Pomodoro.Enums;

public class PomodoroView : MonoBehaviour, IPomodoroView
{

    [SerializeField]
    private Image loadingBar;
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
        //TODO : hacerlo con unirx
        loadingBar.fillAmount = mainSceneView.timeInput.text != "" ? GetCurrentStudyTime() / float.Parse(mainSceneView.timeInput.text) : 1;
        pomodoroStateText.text = _pomodoroPresenter.GetState().ToString();
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
            _pomodoroPresenter.StudyCountDown();
            Debug.Log(GetCurrentStudyTime());
            yield return new WaitForSeconds(1);
        }
        StartCoroutine(RestCountDown());
    }

    IEnumerator RestCountDown()
    {
        for (counter = _pomodoroPresenter.GetRestingTime(); counter > 0; counter--)
        {
            _pomodoroPresenter.RestingCountDown();
            Debug.Log(GetCurrentRestingTime());
            yield return new WaitForSeconds(1);
        }
        mainSceneView.ChangeCurrentPomodoro();
    }

    #region 
    //Nuevos metodos
    private void ManageStates()
    {
        switch (_pomodoroPresenter.GetState())
        {
            case States.Stoped:
                mainSceneView.SetStartTime();
                mainSceneView.SetInputStartStopState(true, true, false);
                pomodoroText.text = GetCurrentStudyTime().ToString();
                break;
            case States.Initialized:
                mainSceneView.SetInputStartStopState(false, false, true);
                pomodoroText.text = GetCurrentStudyTime().ToString();
                break;
            case States.Resting:
                mainSceneView.SetInputStartStopState(false, false, false);
                pomodoroText.text = GetCurrentRestingTime().ToString();
                break;
            case States.Finished:
                pomodoroText.text = GetCurrentRestingTime().ToString();
                break;
        }
    }

    #endregion
}
