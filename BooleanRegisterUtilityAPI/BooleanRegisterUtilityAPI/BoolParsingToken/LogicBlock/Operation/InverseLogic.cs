﻿using BooleanRegisterUtilityAPI.BoolParsingToken.LogicBlock;
using System;

namespace BooleanRegisterUtilityAPI
{
    public class InverseLogic : LogicBlock
    {
        public LogicBlock m_target;

        public InverseLogic(LogicBlock target)
        {
            m_target = target;
        }

        public override void Get(out bool value, out bool computed)
        {
            m_target.Get(out value, out computed);
            value = !value;
        }

        public override string ToString()
        {
            return " ¬ "+m_target;
        }
       

    }
}