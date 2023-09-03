using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedFunctionList<T>
{
    public LinkedFunctionList<T> prev;
    public LinkedFunctionList<T> next;
    public delegate T FuncP(object[] args);
    FuncP function;

    public T Func(object[] args)
    {

        if (next != null)
        {
            function(args);
            return next.Func(args);
        }
        else
        {
            return function(args);
        }
    }



    public void AddFunction(LinkedFunctionList<T> newFunc)
    {
        this.next = newFunc;
        newFunc.prev = this;
    }


    public LinkedFunctionList(FuncP newFunc)
    {
        function = newFunc;
        prev = null;
        next = null;
    }

}
