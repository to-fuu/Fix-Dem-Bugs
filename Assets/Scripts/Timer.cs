using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    //HIGH QUALITY CODE UP AHEAD
    TextMeshProUGUI tm => GetComponent<TextMeshProUGUI>();

    void Update()
    {
        if (CPU.instance.startTIme == 0) return;
        if (CPU.gameended) return;

       int minutes = (int)((Time.time - CPU.instance.startTIme ) / 60f) % 60;
       int seconds = (int)((Time.time - CPU.instance.startTIme )) % 60;
        int milliseconds = (int)((Time.time - CPU.instance.startTIme) * 1000f) % 1000;

        tm.text =  minutes.ToString("D2") + ":" + seconds.ToString("D2") + ":" + milliseconds.ToString("D2");
    }
}
