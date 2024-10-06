using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableObjectType{
    Book, Furniture, Plant,
    Teleport
}

public enum BookType{
    Literacy,//Red
    Children,//Yellow
    Science,//Blue
    Love,//White
    Photography//Gray
}

public enum SlotType{
    Bag,
    OnSell
}

public enum RequestType{
    ByType,
    ByName,
    ByDescription
}