using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler
{
    public static event Action TransferScene;
    public static void CallinteractType(){
        TransferScene?.Invoke();
    }

    public static event Action UpdateBag_Book;
    public static void CallUpdateBag_Book(){
        UpdateBag_Book?.Invoke();
    }
    
    public static event Action UpdateBag_Item;
    public static void CallUpdateBag_Item(){
        UpdateBag_Book?.Invoke();
    }
}
