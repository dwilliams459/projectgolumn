﻿using Golumn.Core.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golumn.Core.Service
{
    public class AlertService
    {
        public List<Alert> ReadAlertsFromFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            List<Alert> alerts = JsonConvert.DeserializeObject<List<Alert>>(json);
            return alerts;
        }

        public bool AlertMatch(Alert alert)
        {
            var now = DateTime.Now;
            var dayOfWeek = now.DayOfWeek.ToString().Substring(0, 3);

            if (InRange(alert.AlertDateTime, now, 1))
            { 
                return true;
            }

            if (alert.Repeat)
            {
                // Return true if the day of the week is in the list of days of the week and is the same time of day as the alert
                // Days Of Week formated like: "Sun,Mon,Tue,Wed,Thu,Fri,Sat"
                if (alert.DaysOfWeek.Contains(dayOfWeek, StringComparison.CurrentCultureIgnoreCase) && InRange(alert.AlertDateTime.TimeOfDay, now.TimeOfDay))
                {
                    return true;
                }
            } 

            return false;
        }

        public static bool InRange(DateTime date1, DateTime date2, int rangeMinutes = 1) => Math.Abs((date1 - date2).TotalMinutes) <= rangeMinutes;
        public static bool InRange(TimeSpan time1, TimeSpan time2, int rangeMinutes = 1) => Math.Abs((time1 - time2).TotalMinutes) <= rangeMinutes;

    }
}
