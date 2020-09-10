using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    [HideInInspector]
    public bool IsMove;

    public float MoveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        IsMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsMove)
        {
            if(Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * Time.deltaTime * MoveSpeed);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Vector3.up, -1.0f);
            }

            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.up, 1.0f);
            }
        }
    }
}
