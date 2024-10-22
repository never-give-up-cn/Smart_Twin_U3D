using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform playerTransform; // 移动的物体
    public Vector3 deviation; // 偏移量
    public float sensitivity = 100.0f; // 鼠标灵敏度
    public float yaw; // 水平旋转角度
    public float pitch; // 垂直旋转角度

    public float pitchMin = -90.0f; // 俯仰的最小角度
    public float pitchMax = 90.0f; // 俯仰的最大角度

    void Start()
    {
        transform.rotation = playerTransform.rotation;
        deviation = transform.position - playerTransform.position; // 初始物体与相机的偏移量=相机的位置 - 移动物体的偏移量
                                                                   // 计算初始偏移量
    }

    void Update()
    {
       
        transform.rotation = playerTransform.rotation;
        transform.position = playerTransform.position + deviation; // 相机的位置 = 移动物体的位置 + 偏移量
                                                                   // 计算初始偏移量
                                                                   // 获取鼠标X轴和Y轴的移动量
                                                                   // 获取鼠标X轴和Y轴的移动量
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // 更新水平旋转角度
        yaw += mouseX;
        // 更新垂直旋转角度，并限制在指定的范围内
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);

        // 应用旋转到玩家的Transform
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    }

}

