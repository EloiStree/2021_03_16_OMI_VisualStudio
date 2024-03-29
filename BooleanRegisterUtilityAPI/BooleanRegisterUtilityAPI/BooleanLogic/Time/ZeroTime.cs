﻿using BooleanRegisterUtilityAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BooleanRegisterUtilityAPI.BooleanLogic.Time
{
    public class ZeroTime : ITimeValue
    {
        public static ZeroTime Default= new ZeroTime();
        public double GetAsHours()
        {
            return 0;
        }

        public void GetAsMilliSeconds(out uint valueInMs)
        {
            valueInMs = 0;
        }

        public double GetAsMilliSeconds()
        {
            return 0;
        }

        public double GetAsMinutes()
        {
            return 0;
        }

        public double GetAsSeconds()
        {
            return 0;
        }

        public void SetAsMilliSeconds(double valueInMs)
        {
            return;
        }
    }
}
