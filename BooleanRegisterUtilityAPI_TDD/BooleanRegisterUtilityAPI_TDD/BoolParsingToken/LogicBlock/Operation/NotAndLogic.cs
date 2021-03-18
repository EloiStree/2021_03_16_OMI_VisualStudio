﻿using BooleanRegisterUtilityAPI_TDD.BoolParsingToken.LogicBlock;

namespace BooleanRegisterUtilityAPI_TDD
{
    internal class NotAndLogic : ParamsArrayLogicBlock
    {
        public NotAndLogic(params LogicBlock[] values) : base(values)
        {
        }

        public override bool ComputedBoolean(ref bool[] values)
        {
            return BoolOperationLogic.NAND(values);
        }
        public override string ToString()
        {
            return string.Format("! [& {0} ] ", LogicBlock.JoinString(m_values));
        }
    }
}