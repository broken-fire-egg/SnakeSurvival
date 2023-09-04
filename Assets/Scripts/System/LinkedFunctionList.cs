using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class LinkedFunctionList<T>
{

    public LinkedFunctionList<T> prev;
    public LinkedFunctionList<T> next;
    public delegate T FuncP(T args);
    FuncP function;


    public T Function(T args)
    {

        if (next != null)
            return next.Function(function(args));
        else
            return function(args);
        
    }



    public LinkedFunctionList<T> AppendFunction(FuncP newFuncP)
    {
        LinkedFunctionList<T> newFunc = new LinkedFunctionList<T>(newFuncP);


        if (next == null)
        {
            next = newFunc;
            newFunc.prev = this;
        }
        else
            next.AppendFunction(newFuncP);
        return this;
    }


    public LinkedFunctionList(FuncP newFunc)
    {
        function = newFunc;
        prev = null;
        next = null;
    }



}
