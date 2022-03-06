using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ValidationFieldView : MonoBehaviour, IValidationView
{
    private ValidationPresenter _validationPresenter;
    private GameObject gameObject;

    private void Awake()
    {
        gameObject = GetComponent<RectTransform>().gameObject;
        _validationPresenter = new ValidationPresenter(this);
    }
    private void Update()
    {
        ValidateFields();
    }

    public void SetValidatedText(string text)
    {
        gameObject.GetComponent<InputField>().text = text;
    }

    public void ValidateFields()
    {
        _validationPresenter.ValidationField(gameObject);
    }

}
