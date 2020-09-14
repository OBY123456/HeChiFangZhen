using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OBYPool;

public class AdminPool : BasePool
{
    public static AdminPool Instance;

    private void Awake()
    {
        Instance = this;
    }
}
