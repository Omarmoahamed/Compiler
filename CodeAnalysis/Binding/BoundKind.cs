﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal enum BoundKind
    {
        //Expression
        LiteralExpression,
        CallExpression,
        BinaryExpression,
        AssigmentExpression,
        AssigmentCompoundExpression,
        UnaryExpression,
        VariableExpression,

        //Statement

        IfStatement,
        BlockStatement,
        ForStatement,
        WhileStatement,
        ReturnStatement,
        DoWhileStatement,
        VariableDecleration
    }
}
