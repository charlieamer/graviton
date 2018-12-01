using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUi : MonoBehaviour
{
    private UnityEngine.UI.Text TimerText;
    
    void Start()
    {
        TimerText = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int ms = Mathf.FloorToInt((Time.timeSinceLevelLoad % 1.0f) * 1000.0f);
        int s = Mathf.FloorToInt(Time.timeSinceLevelLoad) % 60;
        int m = Mathf.FloorToInt(Time.timeSinceLevelLoad) / 60;
        TimerText.text = string.Format("{0:D2}:{1:D2}:{2:D3}", m, s, ms);
    }
}
