using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ManYouEnum;
using MTFrame.MTEvent;

public class HightLighManyou : HighlightableObject
{
    public DevicesType devicesType;

    private void OnMouseEnter()
    {
        if(TrainingPanel.trainType == TrainingEnum.TrainType.电站认知)
        {
            ConstantOn(Color.blue);
        }
       
    }

    private void OnMouseExit()
    {
        if (TrainingPanel.trainType == TrainingEnum.TrainType.电站认知)
        {
            ConstantOff();
        }
    }

    private void OnMouseDown()
    {
        if (TrainingPanel.trainType == TrainingEnum.TrainType.电站认知 && DirectoryPanel.functionType!= DirectoryEnum.FunctionType.Check)
        {
            EventParamete eventParamete = new EventParamete();
            eventParamete.AddParameter(devicesType);
            EventManager.TriggerEvent(GenericEventEnumType.Message, TrainingEnum.TrainType.电站认知.ToString(), eventParamete);
        }

        if(DirectoryPanel.functionType == DirectoryEnum.FunctionType.Check)
        {
            EventParamete eventParamete = new EventParamete();
            eventParamete.AddParameter(devicesType);
            EventManager.TriggerEvent(GenericEventEnumType.Message, DirectoryPanel.functionType.ToString(), eventParamete);
        }
    }
}
