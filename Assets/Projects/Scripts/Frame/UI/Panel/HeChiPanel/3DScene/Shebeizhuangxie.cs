using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame.MTEvent;
using System;
using ShebeiEnum;

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

    private void OnEnable()
    {
        EventManager.AddListener(GenericEventEnumType.Message, "SBZX", Callback);
    }

    private void Callback(EventParamete parameteData)
    {
        SheBeiType deviceType = parameteData.GetParameter<SheBeiType>()[0];
        switch (TrainingPanel.trainType)
        {
            case TrainingEnum.TrainType.拆机组装_拆卸:
                switch (deviceType)
                {
                    case SheBeiType.定子:
                        break;
                    case SheBeiType.转子:
                        break;
                    case SheBeiType.上机架:
                        break;
                    case SheBeiType.下机架:
                        break;
                    case SheBeiType.电机外壳:
                        break;
                    case SheBeiType.推力轴承:
                        break;
                    case SheBeiType.上导轴承:
                        break;
                    case SheBeiType.下导轴承:
                        break;
                    default:
                        break;
                }

                break;
            case TrainingEnum.TrainType.拆机组装_安装:

                switch (deviceType)
                {
                    case SheBeiType.定子:
                        break;
                    case SheBeiType.转子:
                        break;
                    case SheBeiType.上机架:
                        break;
                    case SheBeiType.下机架:
                        break;
                    case SheBeiType.电机外壳:
                        break;
                    case SheBeiType.推力轴承:
                        break;
                    case SheBeiType.上导轴承:
                        break;
                    case SheBeiType.下导轴承:
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }

    }

    private void Reset()
    {
        
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(GenericEventEnumType.Message, "SBZX", Callback);
    }
}
