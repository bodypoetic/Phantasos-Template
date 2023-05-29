using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class OLDTimeManager : MonoBehaviour
{
    public TextMeshProUGUI TextBox;
    
    public float _elapsedTime;

    private readonly DateTime _startDate = new DateTime(2023, 1, 16, 18, 57, 58);

    [SerializeField]
    public float _secondsPerDay = 1; // How much in-game days will pass in 1 real-time second

    public DateTime CurrentDate { get; private set; }

    public static OLDTimeManager Instance { get; private set; }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        var elapsedDays = _elapsedTime / _secondsPerDay;
        var elapsedTimeSpan = TimeSpan.FromDays(elapsedDays);

        CurrentDate = _startDate.Add(elapsedTimeSpan);

        TextBox.text = OLDTimeManager.Instance.CurrentDate.ToString("H:mm dd/MM/yyyy");
        // For Date string format check: https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
    }

    // Singleton stuff here...
    private void Awake()
    {
        Instance = this;
    }
}