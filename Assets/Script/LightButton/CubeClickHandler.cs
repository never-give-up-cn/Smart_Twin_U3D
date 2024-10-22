using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HslCommunication.MQTT;
using M2MqttUnity.Examples;

public class CubeClickHandler : MonoBehaviour
{
    public GameObject ledGameObject;
    public Camera mCam; //摄像机
    public ToggleTest toggleTestInstance; // 添加这个字段
    public M2MqttUnityTest m2MqttUnityTest;
    void Start() {
        m2MqttUnityTest.Connect();

    }
    void Update()
    {
        // 检测鼠标左键是否被点击
        if (Input.GetMouseButtonDown(0))
        {
            // 将鼠标位置转换为射线
            Ray ray = mCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 射线检测是否有物体被点击
            if (Physics.Raycast(ray, out hit))
            {
                // 检测是否点击到Cube
                if (hit.collider.gameObject == gameObject)
                {
                    // 执行点击事件
                    OnCubeClicked();
                }
            }
        }
    }

    void OnCubeClicked()
    {
        //在这里编写点击Cube后要执行的代码
        Debug.Log(gameObject.name + " was clicked!");

        // 确保已经设置了 toggleTestInstance
        if (toggleTestInstance != null)
        {
            if (ledGameObject != null)
            {
                Light l = ledGameObject.GetComponent<Light>();
                if (l == null)
                {
                    ledGameObject.AddComponent<Light>();
                }
                if (l != null)
                {
                    print("======================================");
                    m2MqttUnityTest.TestPublish(l.enabled);
                    //toggleTestInstance.ExternalToggleOnValueChanged(l.enabled);
                }
            }

        }
        else
        {
            Debug.LogError("toggleTestInstance is not set in the inspector.");
        }
    }
}
