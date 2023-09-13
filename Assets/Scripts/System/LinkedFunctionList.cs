using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//제거 

public class LinkedFunctionList<T>
{

    public LinkedFunctionList<T> prev;
    public LinkedFunctionList<T> next;
    public delegate T FuncP(T args);
    FuncP function;

    //TODO : 매개변수 T 대신 object[]같은걸로
    public T Function(T args)
    {
        if (function == null)
        {
            if (next != null)
                return next.Function(function(args));
            else
                return args;
        }
        else
        {
            if (next != null)
                return next.Function(function(args));
            else
                return function(args);
        }
        
    }
    public T ReverseFunction(T args)
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
    public LinkedFunctionList<T> AppendLinkedFunctionList(LinkedFunctionList<T> newlist)
    {
        if (next == null)
        {
            next = newlist;
            newlist.prev = this;
        }
        else
            next.AppendLinkedFunctionList(newlist);
        return this;
    }
    public LinkedFunctionList(FuncP newFunc)
    {
        function = newFunc;
        prev = null;
        next = null;
    }
}
