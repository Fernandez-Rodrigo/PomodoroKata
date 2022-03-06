using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITotalEarningView 
{
    void SetResultText(string value);
    string GetVieiraPrice();
    string GetCentollaPrice();
    string GetPulpoPrice();
    void SetVieiraPrice(string str);
    void SetCentollaPrice(string str);
    void SetPulpoPrice(string str);
      
}
