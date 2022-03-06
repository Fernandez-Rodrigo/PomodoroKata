using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SceneView : MonoBehaviour, ISceneView
{
    [SerializeField]
    TextMeshProUGUI[] resultsText;

    ScenePresenter scenePresenter;

    void Start()
    {
        scenePresenter = new ScenePresenter(this);
    }
    public void SetTextColor(TextMeshProUGUI resultText, Color color)
    {
       resultText.color = color;
    }

    public void ActualizarColor_Lister() {
        scenePresenter.ActualizarColor(resultsText);
    }
}
