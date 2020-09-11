using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shebeizhuangxie : MonoBehaviour
{
    public GameObject[] ObjGroup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ObjGroupHide()
    {
        for (int i = 0; i < ObjGroup.Length; i++)
        {
            ObjGroup[i].SetActive(false);
        }
    }

    public void ObjGroupOpen()
    {
        for (int i = 0; i < ObjGroup.Length; i++)
        {
            ObjGroup[i].SetActive(true);
        }
    }

    public void SetObjOpen(int num)
    {
        ObjGroup[num].SetActive(true);
    }

}
