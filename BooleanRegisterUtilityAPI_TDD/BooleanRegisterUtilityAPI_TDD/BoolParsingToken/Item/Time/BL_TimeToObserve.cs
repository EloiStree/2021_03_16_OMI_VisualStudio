﻿using BooleanRegisterUtilityAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooleanRegisterUtilityAPI_TDD.BoolParsingToken.Item.Time
{
    public class BL_TimeToObserve : IBoolObservedTime
    {
        bool m_isRelative=true;
        IBoolTimeKey m_key=null;
        IBoolTimeRange m_range=null;

        public BL_TimeToObserve(bool isRelative, IBoolTimeKey timeobserved)
        {
            SetWith(timeobserved, isRelative);
        }
        public BL_TimeToObserve(bool isRelative, IBoolTimeRange timeobserved)
        {
            SetWith(timeobserved, isRelative);
        }

        public IBoolTimeKey GetTimeKey()
        {
            return m_key;
        }

        public IBoolTimeRange GetTimeRange()
        {
            return m_range;
        }

        public bool IsAbsolute()
        {
            return m_isRelative;
        }

        public bool IsRelativeToNow()
        {
            return !m_isRelative;
        }

        public bool IsTimeKey()
        {
            return m_key != null;
        }

        public bool IsTimeRange()
        {
            return m_range != null;
        }

        public void SetWith(IBoolTimeRange timeRange, bool isRelative)
        {
            m_isRelative = isRelative;
            m_range = timeRange;
            m_key = null;
        }

        public void SetWith(IBoolTimeKey timeKey, bool isRelative)
        {
            m_isRelative = isRelative;
            m_range = null;
            m_key = timeKey;
        }

        public override string ToString()
        {
            return string.Format("TO{0},{1}", IsRelativeToNow(), ""+m_key+" "+m_range);
        }
    }
}