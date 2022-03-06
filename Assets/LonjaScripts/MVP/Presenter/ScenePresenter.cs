using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScenePresenter
{
    ISceneView _sceneView;
    public ScenePresenter(ISceneView sceneView) {
        _sceneView = sceneView;
    }

    public void ActualizarColor(TextMeshProUGUI[] resultTexts) {
        List<float> numbers = new List<float>();

        foreach (TextMeshProUGUI results in resultTexts) {
            _sceneView.SetTextColor(results, Color.red);
            numbers.Add(float.Parse(results.text));
        }

        float maximumNumber = numbers.Max();

        int indexToColor = numbers.FindIndex(x => x == maximumNumber);

        _sceneView.SetTextColor(resultTexts[indexToColor], Color.green);
    }
}
