using UnityEngine;
using System.Collections;

public class DropedItemBase : GameResource
{
    [SerializeField]
    int itemCount = 0;

    #region property

    public int ItemCount
    {
        get
        {
            return itemCount;
        }

        set
        {
            itemCount = value;
        }
    }

    #endregion


}
