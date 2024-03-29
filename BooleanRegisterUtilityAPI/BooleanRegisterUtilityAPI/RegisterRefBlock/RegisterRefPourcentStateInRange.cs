﻿using BooleanRegisterUtilityAPI.BoolParsingToken.Item;
using BooleanRegisterUtilityAPI.Enum;
using BooleanRegisterUtilityAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BooleanRegisterUtilityAPI.RegisterRefBlock
{
    public class RegisterRefPourcentStateInRange : AbstractRegisterRefBlock
    {
        public BL_BooleanItemPourcentStateInRange m_value;
        public RegisterRefPourcentStateInRange(RefBooleanRegister defaultregister, BL_BooleanItemPourcentStateInRange value) : base(defaultregister)
        {
            m_value = value;
        }

        public override void Get(out bool value, out bool computed, DateTime when)
        {
            value = false;
            computed = false;
            string name = m_value.GetTargetName();
            if (!IsBoolAndRegisterExist(name))
            { return; }

            IBooleanHistory history;
            bool historyExist;
            base.m_defaultregister.GetRef().GetHistoryAccess(name, out history, out historyExist);
            if (!historyExist)
            { return; }

            IBoolObservedTime time = m_value.GetObservedTime();


            double pourcent = 0;
            if (time == null || ! time.IsDefined())
            {
                history.GetPoucentOfState(
                   m_value.m_observedState == BoolState.True ? true : false,
                   out pourcent);

            }
            else {

                DateTime near=when, far=when;
                if (time.GetTimeKey() != null)
                {
                    near = when;
                    time.GetTimeKey().GetTime(when, out far);

                }
                else if (time.GetTimeRange() != null)
                {

                    time.GetTimeRange().GetTime(when, out near, out far);
                }
                history.GetPoucentOfState(
                        m_value.m_observedState == BoolState.True ? true : false,
                        out pourcent, when, near, far);
             }
            if (m_value.m_observedSide == ValueDualSide.Less && pourcent <= m_value.m_pourcent.GetPourcentAs0To1())
            {
                value = true;
            }
            else if (m_value.m_observedSide == ValueDualSide.More && pourcent >= m_value.m_pourcent.GetPourcentAs0To1())
            {
                value = true;
            }
            else value = false;

            computed = true;
            return;



        }

        public override void Get(out bool value, out bool computed)
        {
            Get(out value, out computed, DateTime.Now);
        }

        public override bool IsTimeNotUsefulForComputing()
        {
            return true;
        }

        public override string ToString()
        {
            return m_value.ToString();
        }
    }
}
