using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MTFrame.MTEvent;
using ScoreEnum;

public class AdminStdTable : MonoBehaviour
{
    public Text Number, Name, Academy, Class;
    public Button Modify, Reset, Delete;
    public AdminPanel adminPanel;

    // Start is called before the first frame update
    void Start()
    {
        Reset.onClick.AddListener(() => {
            adminPanel.ResetData(this.gameObject);
        });

        Delete.onClick.AddListener(() => {
            adminPanel.DeleteData(this.gameObject);
        });

        Modify.onClick.AddListener(() => {
            adminPanel.DisPlayData(this.gameObject);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
