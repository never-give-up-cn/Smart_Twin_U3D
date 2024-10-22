using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HslCommunication.MQTT;
using System.Text;
using System.Diagnostics;
using System;

public class mqtt_test : MonoBehaviour
{
    public GameObject gameObject1;
    public String SubscribeMessage = "temp_hum/kunming";
    public String MYSubscribeTopic = "esp8266/led1";
    private MqttClient mqttClient;
    // Start is called before the first frame update
    void Start()
    {
        mqttClient = new MqttClient(new MqttConnectionOptions()
        {
            ClientId = "Unity 3D Client",                     // �ͻ��˵�Ψһ��ID��Ϣ
            IpAddress = "192.168.1.1",              // �������ĵ�ַ
        });
        // ���ӷ�����
        HslCommunication.OperateResult connect = mqttClient.ConnectServer();
        if (connect.IsSuccess)
        {
            // ���ӳɹ�
            UnityEngine.Debug.Log("���ӳɹ�");
        }
        else
        {
            // ����ʧ�ܣ��������Ҫ����������
            UnityEngine.Debug.Log("����ʧ��");
        }
        // Ȼ����Ӷ���
        HslCommunication.OperateResult sub = mqttClient.SubscribeMessage(SubscribeMessage);
        if (sub.IsSuccess)
        {
            // ���ĳɹ�
            UnityEngine.Debug.Log(sub.ToMessageShowString());
            
        }
        else
        {
            // ����ʧ��
            UnityEngine.Debug.Log("����ʧ��");
        }
        // ����ʾ��
        mqttClient.OnMqttMessageReceived += (MqttClient client, string topic, byte[] payload) =>
        {
            //UnityEngine.Debug.Log("Time:----" + DateTime.Now.ToString());
            //Console.WriteLine("Topic:" + topic);
            UnityEngine.Debug.Log("Payload:" + Encoding.UTF8.GetString(payload));
           // UnityEngine.Debug.Log("Time:" + DateTime.Now.ToString());
            //UnityEngine.Debug.Log("Topic:" + topic);
            //UnityEngine.Debug.Log("Payload:" + Encoding.UTF8.GetString(payload));
        };
        

    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            HslCommunication.OperateResult connect = mqttClient.PublishMessage(new MqttApplicationMessage()
            {
                Topic = MYSubscribeTopic,                 //����
                QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,       //�����ʵʱ���ݣ��ʺ������
                Payload = Encoding.UTF8.GetBytes("Test data")
            });
                 //UnityEngine.Debug.Log("Topic:" + connect);
        if (connect.IsSuccess)
            {
                //�����ɹ�
                UnityEngine.Debug.Log("�����ɹ�");
            }
            else
            {
                UnityEngine.Debug.Log("����ʧ��");
            }
        }
        

    }
}
