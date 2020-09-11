using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour
{
    public static MainControl Instance;

    public Transform ShiwaiScene, ShineiScene,Shebeizhuangxie;
    public ShineiScene shineiScene;
    public Shebeizhuangxie shebeizhuangxie;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
