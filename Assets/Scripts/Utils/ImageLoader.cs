using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IImageLoader
{
    public Dictionary<BookType, string> BookTypeToSpritePathDict{get;}

    void InitDict();
    Sprite ReadSprite(BookType bookType);
}
