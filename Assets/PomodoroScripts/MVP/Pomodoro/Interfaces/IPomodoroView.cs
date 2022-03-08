using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPomodoroView 
{
    void SetLoadingBarFillAmount(float fillAmount);
    void SetRestingBarFillAmount(float fillAmount);
    void SetStateText(string str);
    void SetPomodoroTimeText(string str);
    void StartCountDownCoroutine(float currentStudyTime, float currentRestingTime);
}
