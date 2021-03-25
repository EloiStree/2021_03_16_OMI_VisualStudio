﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BooleanRegisterUtilityAPI.BooleanLogic
{
    public class BooleanableGroupRef
    {
        public IBooleanableRef[] m_booleanables;
        public BooleanableGroupRef(params IBooleanableRef[] booleans) {
            m_booleanables = booleans;
        }
    }
}
