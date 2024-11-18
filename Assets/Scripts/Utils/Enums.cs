using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableObjectType{
    Book, Furniture, Plant,
    Teleport
}

public enum BookType{
    Literacy,//white
    Children,//blue
    Science,//red
    Photography//yellow
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