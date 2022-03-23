using System;
namespace ParseTree
{
    interface INode
    {
        /// <summary>
        /// 
        /// </summary>
        void Print();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        double Calculate();
    }
}
