using System;
using System.Collections.Generic;

public static class Log
{
    static int MAX_LINE = 30;
    static LinkedList<string> list = new LinkedList<string>();

    public static void WriteLine(string msg)
    {
        if (list.Count > 30)
        {
            list.RemoveFirst();
        }

        string str = string.Format("{0} {1}\n", System.DateTime.UtcNow, msg);
        list.AddLast(str);

        UnityEngine.Debug.Log(str);
    }

    public static void Clear()
    {
        list.Clear();
    }

    public static string ToString()
    {
        string ret = "";
        LinkedListNode<string> itr = list.First;

        while(itr != list.Last)
        {
            ret += itr.Value;
            itr = itr.Next;
        }

        return ret;
    }
}