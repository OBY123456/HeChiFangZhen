using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BackButton : MonoBehaviour
{
    public PanelName Panelname;

    private void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(() => {

            if( Panelname == PanelName.TrainingPanel && DirectoryPanel.functionType == DirectoryEnum.FunctionType.Check)
            {
                PanelState.SwitchPanel(PanelName.CheckPanel);
            }
            else
            {
                PanelState.SwitchPanel(Panelname);
            }
            
        });
    }
}
