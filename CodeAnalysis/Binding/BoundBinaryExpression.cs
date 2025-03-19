using Memo_Compiler.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal class BoundBinaryOperatorExpression : BoundExpression
    {
        public BoundBinaryOperatorExpression(TypeSymbol type,SyntaxNode syntax, BinaryKind binaryKind,BoundExpression left,BoundExpression right) : base(syntax)
        {
           
            this.left = left;
            this.right = right;
            this.Type = type;
            BinaryKind = binaryKind;
        }

        public override BoundKind Kind => BoundKind.BinaryExpression;

        public override TypeSymbol Type { get; }
        public BinaryKind BinaryKind { get; }
        public BoundExpression left { get; }
        public BoundExpression right { get; }

        private static Dictionary<(SyntaxKind kind, TypeKind left, TypeKind right), (BinaryKind kind,TypeKind type,SyntaxKind Skind)> _operators =
            new Dictionary<(SyntaxKind kind, TypeKind left, TypeKind right), (BinaryKind kind, TypeKind type,SyntaxKind Skind)>() 
            {
                {(SyntaxKind.BiggerThanToken,TypeKind.Int,TypeKind.Int),(BinaryKind.Greate,type:TypeKind.Bool,SyntaxKind.TrueKeyword) },
                {(SyntaxKind.BiggerOrEqualToken,TypeKind.Int,TypeKind.Int),(BinaryKind.BiggerEqual, type : TypeKind.Bool,SyntaxKind.TrueKeyword) },
                {(SyntaxKind.SmallerThanToken,TypeKind.Int,TypeKind.Int),(BinaryKind.Smaller,type:TypeKind.Bool,SyntaxKind.TrueKeyword) },
                {(SyntaxKind.SmallerOrEqualToken,TypeKind.Int,TypeKind.Int),(BinaryKind.LessEqual,type:TypeKind.Bool,SyntaxKind.TrueKeyword) },
                {(SyntaxKind.EqualEqualToken,TypeKind.String,TypeKind.String),(BinaryKind.EqualEqual,type:TypeKind.Bool,SyntaxKind.TrueKeyword) },
                {(SyntaxKind.EqualEqualToken,TypeKind.Int,TypeKind.Int),(BinaryKind.EqualEqual,type:TypeKind.Bool,SyntaxKind.TrueKeyword) },
                {(SyntaxKind.PlusToken,TypeKind.Int,TypeKind.Int),(BinaryKind.Adding,type:TypeKind.Int,SyntaxKind.NumberKeyword) },
                {(SyntaxKind.PlusToken,TypeKind.Int,TypeKind.Double),(BinaryKind.Adding,type:TypeKind.Double,SyntaxKind.NumberKeyword) },
                {(SyntaxKind.MinusToken,TypeKind.Int,TypeKind.Int),(BinaryKind.Subtraction,type:TypeKind.Int,SyntaxKind.NumberKeyword) },
                {(SyntaxKind.MinusToken,TypeKind.Int,TypeKind.Double),(BinaryKind.Subtraction,type:TypeKind.Double,SyntaxKind.NumberKeyword) },
                {(SyntaxKind.StarToken,TypeKind.Int,TypeKind.Int),(BinaryKind.Multiplication,type:TypeKind.Int,SyntaxKind.NumberKeyword) },
                {(SyntaxKind.StarToken,TypeKind.Int,TypeKind.Double),(BinaryKind.Multiplication,type:TypeKind.Double,SyntaxKind.NumberKeyword) },
                {(SyntaxKind.SlashToken,TypeKind.Int,TypeKind.Int),(BinaryKind.Division,type:TypeKind.Int,SyntaxKind.NumberKeyword) },
                {(SyntaxKind.SlashToken,TypeKind.Int,TypeKind.Double),(BinaryKind.Division,type:TypeKind.Double,SyntaxKind.NumberKeyword) },

            };


        public BoundExpression CreateBinaryBound(BoundExpression left,BoundExpression right,SyntaxKind kind,SyntaxNode syntax) 
        {
            if(left.Type.TypeKind==TypeKind.Int && right.Type.TypeKind == TypeKind.Int) 
            {
               var op = _operators[(kind, left.Type.TypeKind, right.Type.TypeKind)];
                return new BoundBinaryOperatorExpression(TypeSymbol.CreateType(op.Skind,left.Type.TypeKind),syntax,op.kind,left,right);
            }
            if (left.Type.TypeKind == TypeKind.Double || right.Type.TypeKind == TypeKind.Double) 
            {
                var op = _operators[(kind, left.Type.TypeKind, right.Type.TypeKind)];
                return new BoundBinaryOperatorExpression(TypeSymbol.CreateType(op.Skind, TypeKind.Double), syntax, op.kind, left, right);
            }
            else 
            {
                var op = _operators[(kind, left.Type.TypeKind, right.Type.TypeKind)];
                return new BoundBinaryOperatorExpression(TypeSymbol.CreateType(op.Skind, TypeKind.String), syntax, op.kind, left, right);

            }
        }
       
        }
    }

