﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal abstract class BoundStatement : BoundNode
    {
        public BoundStatement(SyntaxNode syntax): base(syntax) 
        {

        }


    }
}
