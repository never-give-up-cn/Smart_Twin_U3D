using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincubemove : MonoBehaviour
{

    float moveSpeed = 10;
    //定义对象移动的速度。

    //获取水平输入轴的数值。

    //获取垂直输入轴的数值。

    //将对象移动到 XYZ 坐标，分别定义为 horizontalInput、0 以及 verticalInput。
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {   

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(new Vector3(1,0,0));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(new Vector3(-1, 0, 0));
        }
        

    }
}
