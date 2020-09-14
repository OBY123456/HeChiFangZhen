using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OBYPool;

public class TipsTextPool : BasePool
{
    public static TipsTextPool Instence;

    private void Awake()
    {
        Instence = this;
    }
}
