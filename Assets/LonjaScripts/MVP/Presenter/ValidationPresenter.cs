using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidationPresenter
{
    IValidationView validationView;


    public ValidationPresenter(IValidationView _validationView)
    {
        validationView = _validationView;
    }

    public void ValidationField(GameObject field)
    {
        if (!VerifyInputToExist(field)) return;

        if (field.GetComponent<InputField>().text.StartsWith("-"))
        {
            validationView.SetValidatedText("");
        }
        if (field.GetComponent<InputField>().text.Equals(""))
        {
            validationView.SetValidatedText("0");
        }
    }
    private bool VerifyInputToExist(GameObject field) {
        if (field.GetComponent<InputField>()) return true;
        else return false;
    }
}
