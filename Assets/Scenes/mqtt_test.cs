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
            ClientId = "Unity 3D Client",                     // 客户端的唯一的ID信息
            IpAddress = "192.168.1.1",              // 服务器的地址
        });
        // 连接服务器
        HslCommunication.OperateResult connect = mqttClient.ConnectServer();
        if (connect.IsSuccess)
        {
            // 连接成功
            UnityEngine.Debug.Log("连接成功");
        }
        else
        {
            // 连接失败，过会就需要重新连接了
            UnityEngine.Debug.Log("连接失败");
        }
        // 然后添加订阅
        HslCommunication.OperateResult sub = mqttClient.SubscribeMessage(SubscribeMessage);
        if (sub.IsSuccess)
        {
            // 订阅成功
            UnityEngine.Debug.Log(sub.ToMessageShowString());
            
        }
        else
        {
            // 订阅失败
            UnityEngine.Debug.Log("订阅失败");
        }
        // 订阅示例
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
                Topic = MYSubscribeTopic,                 //主题
                QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,       //如果是实时数据，适合用这个
                Payload = Encoding.UTF8.GetBytes("Test data")
            });
                 //UnityEngine.Debug.Log("Topic:" + connect);
        if (connect.IsSuccess)
            {
                //发布成功
                UnityEngine.Debug.Log("发布成功");
            }
            else
            {
                UnityEngine.Debug.Log("发布失败");
            }
        }
        

    }
}
