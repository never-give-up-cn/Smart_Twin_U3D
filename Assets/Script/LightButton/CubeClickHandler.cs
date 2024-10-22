using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HslCommunication.MQTT;
using M2MqttUnity.Examples;

public class CubeClickHandler : MonoBehaviour
{
    public GameObject ledGameObject;
    public Camera mCam; //�����
    public ToggleTest toggleTestInstance; // �������ֶ�
    public M2MqttUnityTest m2MqttUnityTest;
    void Start() {
        m2MqttUnityTest.Connect();

    }
    void Update()
    {
        // ����������Ƿ񱻵��
        if (Input.GetMouseButtonDown(0))
        {
            // �����λ��ת��Ϊ����
            Ray ray = mCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ���߼���Ƿ������屻���
            if (Physics.Raycast(ray, out hit))
            {
                // ����Ƿ�����Cube
                if (hit.collider.gameObject == gameObject)
                {
                    // ִ�е���¼�
                    OnCubeClicked();
                }
            }
        }
    }

    void OnCubeClicked()
    {
        //�������д���Cube��Ҫִ�еĴ���
        Debug.Log(gameObject.name + " was clicked!");

        // ȷ���Ѿ������� toggleTestInstance
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
