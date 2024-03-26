using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectIntervalInCalendar : MonoBehaviour
{
    [SerializeField] private Calendar calendar;
    [SerializeField] private EditFinances editFinances;
    private int choosedDaysCount = 0;

    private void Awake()
    {
        calendar.Init(OnDayChoose, 2);
    }
    private void OnDayChoose(Day day)
    {
        var choosedDays = calendar.choosedDays;
        choosedDays[choosedDaysCount++] = day.DateTime;
        calendar.SetDayStates();

        if (choosedDaysCount == 2)
        {
            choosedDaysCount = 0;
            if (choosedDays[0] > choosedDays[1])
                (choosedDays[0], choosedDays[1]) = (choosedDays[1], choosedDays[0]);

            editFinances.SpawnExpensePlates(choosedDays[0], choosedDays[1]);
        }
    }
}
