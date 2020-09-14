using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OBYPool;

public class ScorePool : BasePool
{
    public static ScorePool Instance;

    private void Awake()
    {
        Instance = this;
    }

}
