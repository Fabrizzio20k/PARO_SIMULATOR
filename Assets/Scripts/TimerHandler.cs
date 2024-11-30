using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerIndicator;

    private float _timer;

    void Start()
    {
        _timer = 300f; // 5 minutes
        timerIndicator.text = "00:00:00"; // Start with "00:00:00"
        timerIndicator.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > 0)
        {
            // Decrease the timer by Time.deltaTime, which accounts for frame time
            _timer -= Time.deltaTime;

            // Calculate minutes, seconds, and milliseconds
            int minutes = Mathf.FloorToInt(_timer / 60);
            int seconds = Mathf.FloorToInt(_timer % 60);
            int milliseconds = Mathf.FloorToInt((_timer * 100f) % 100); // Getting the last 2 digits for milliseconds

            // Format as "MM:SS:FF", ensuring 2 digits with leading zeroes
            timerIndicator.text = string.Format("{0:D2}:{1:D2}:{2:D2}", minutes, seconds, milliseconds);

            // Change the timer color based on the remaining time
            if (minutes > 5)
            {
                timerIndicator.color = Color.white;
            }
            else if (minutes > 2)
            {
                timerIndicator.color = Color.yellow;
            }
            else
            {
                timerIndicator.color = Color.red;
            }
        }
        else
        {
            // When the timer reaches zero, show "00:00:00"
            timerIndicator.text = "00:00:00";
            timerIndicator.color = Color.red;
        }
    }
}
