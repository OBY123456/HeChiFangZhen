using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame.MTEvent;

public class HightLighSheBei : HighlightableObject
{
    private void OnMouseEnter()
    {
        ConstantOn(Color.red);
    }

    private void OnMouseExit()
    {
        ConstantOff();
    }

    private void OnMouseDown()
    {
        EventParamete eventParamete = new EventParamete();
        eventParamete.AddParameter(TrainingEnum.TrainType.拆机组装_安装);
        EventManager.TriggerEvent(GenericEventEnumType.Message, TrainingEnum.TrainType.拆机组装_安装.ToString(), eventParamete);
    }
}
