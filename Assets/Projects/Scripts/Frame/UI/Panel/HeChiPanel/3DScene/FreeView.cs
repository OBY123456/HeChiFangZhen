﻿using UnityEngine;
using System.Collections;

public class FreeView : MonoBehaviour
{
    //public Camera camera;
    //旋转最大角度
    //public int yMinLimit = -20;
    //public int yMaxLimit = 80;
    //旋转速度
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;
    //旋转角度
    private float x = 0.0f;
    private float y = 0.0f;

    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    //将屏幕坐标转化为世界坐标  ScreenToWorldPoint函数的z轴不能为0，不然返回摄像机的位置，而Input.mousePosition的z轴为0
        //    //z轴设成10的原因是摄像机坐标是（0，0，-10），而物体的坐标是（0，0，0），所以加上10，正好是转化后物体跟摄像机的距离
        //    Vector3 temp = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        //    transform.position = temp;
        //}
        if (Input.GetMouseButton(1))
        {
            //Input.GetAxis("MouseX")获取鼠标移动的X轴的距离
            x -= Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y += Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            //y = ClampAngle(y, yMinLimit, yMaxLimit);
            //欧拉角转化为四元数
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            transform.rotation = rotation;
        }
        //else if (Input.GetAxis("Mouse ScrollWheel") != 0)
        //{
        //    //鼠标滚动滑轮 值就会变化
        //    if (Input.GetAxis("Mouse ScrollWheel") < 0)
        //    {
        //        //范围值限定
        //        if (camera.fieldOfView <= 100)
        //            camera.fieldOfView += 2;
        //        if (camera.orthographicSize <= 20)
        //            camera.orthographicSize += 0.5F;
        //    }
        //    //Zoom in  
        //    if (Input.GetAxis("Mouse ScrollWheel") > 0)
        //    {
        //        //范围值限定
        //        if (camera.fieldOfView > 2)
        //            camera.fieldOfView -= 2;
        //        if (camera.orthographicSize >= 1)
        //            camera.orthographicSize -= 0.5F;
        //    }
        //}
    }

    //角度范围值限定
    //static float ClampAngle(float angle, float min, float max)
    //{
    //    if (angle < -360)
    //        angle += 360;
    //    if (angle > 360)
    //        angle -= 360;
    //    return Mathf.Clamp(angle, min, max);
    //}
}