using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShineiSceneEnum;
using ManYouEnum;

namespace ShineiSceneEnum
{
    public enum SceneType
    {
        Scene1,
        Scene2,
    }
}

public class ShineiScene : MonoBehaviour
{
    public GameObject Scene1;
    public GameObject Scene2;

    public GameObject ObjGroup;

    public GameObject[] objects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneHide()
    {
        Scene1.SetActive(false);
        Scene2.SetActive(false);
    }

    public void SceneOpen(SceneType sceneType,int num)
    {
        ResetObjGroup();
        switch (sceneType)
        {
            case SceneType.Scene1:
                Scene1.SetActive(true);
                Scene2.SetActive(false);
                return;
            case SceneType.Scene2:
                Scene1.SetActive(false);
                Scene2.SetActive(true);
                break;
            default:
                break;
        }

        objects[0].SetActive(true);
        //for (int i = 0; i < objects.Length; i++)
        //{
        //    if(i== num)
        //    {
        //        objects[i].SetActive(true);
        //    }
        //    else
        //    {
        //        objects[i].SetActive(false);
        //    }
        //}
    }

    private void ResetObjGroup()
    {
        ObjGroup.transform.localPosition = new Vector3(0, 0, 4.8f);
        ObjGroup.transform.localEulerAngles = Vector3.zero;
    }
}
