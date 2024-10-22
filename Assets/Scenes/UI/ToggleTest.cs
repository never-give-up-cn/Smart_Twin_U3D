using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HslCommunication.MQTT;
using System.Text;
using System;
using TMPro;
using Newtonsoft.Json;
using UnityEngine.EventSystems;

public class ToggleTest : MonoBehaviour,IPointerDownHandler
{
    public Light lightComponent; // 指向灯光组件的引用
                                 // Start is called before the first frame update
    private Light theLight;// 声明一个变量来存储灯光组件
    private String intensitystr;
    private bool intensity;
    public String SubscribeMessage = "temp_hum/kunming";
    public String MYSubscribeTopic = "esp8266/led";
    private MqttClient mqttClient;
    private string json;
    private Toggle m_Toggle;//��ȡ��Toggle���?
    private GameObject lightComp;//��ȡ��Toggle���?
    private MeshRenderer cube;
    private TextMeshPro textcube;
    // Start is called before the first frame update
    private void Awake()
    {
       
       

    }
    public void OnPointerClick(PointerEventData eventData)
    {
       

    }
    void Start()
    {
        //�ҵ����?
        cube = GameObject.Find("Cube").GetComponent<MeshRenderer>();
        //m_Toggle = GameObject.Find("Toggle").GetComponent<Toggle>();
        //Textcube = GameObject.Find("Textcube").GetComponent<TextMeshPro>();
        textcube = transform.GetComponentInChildren<TextMeshPro>();
        textcube.color = new Color(255,0,0);
        lightComp = GameObject.Find("tableLamp");//获取灯光
        //��̬���Ӽ���
        //m_Toggle.onValueChanged.AddListener(ToggleOnValueChanged);
        //m_Toggle.isOn = false;
        mqttClient = new MqttClient(new MqttConnectionOptions()
        {
            ClientId = "mqttx_1ef8dc67",                     // �ͻ��˵�Ψһ��ID��Ϣ
            IpAddress = "broker.emqx.io",              // �������ĵ�ַ
        });
        // ���ӷ�����
        HslCommunication.OperateResult connect = mqttClient.ConnectServer();
        if (connect.IsSuccess)
        {
            // ���ӳɹ�
            //UnityEngine.Debug.Log("���ӳɹ�");
        }
        else
        {
            // ����ʧ�ܣ���������?����������
            //UnityEngine.Debug.Log("����ʧ��");
        }
        HslCommunication.OperateResult sub = mqttClient.SubscribeMessage(SubscribeMessage);
        // ����ʾ��
        mqttClient.OnMqttMessageReceived += (MqttClient client, string topic, byte[] payload) =>
        {
            //UnityEngine.Debug.Log("Time:----" + DateTime.Now.ToString());
            //Console.WriteLine("Topic:" + topic);
            json = Encoding.UTF8.GetString(payload);
            MyJsonClass myJson = JsonConvert.DeserializeObject<MyJsonClass>(json);
            //UnityEngine.Debug.Log("json-----:" + json);
            //UnityEngine.Debug.Log("Time:" + DateTime.Now.ToString());
            //UnityEngine.Debug.Log("Topic:" + topic);
            //UnityEngine.Debug.Log("Payload:" + Encoding.UTF8.GetString(payload));
            
            //��̬���Ӽ���
            char[] c = json.ToCharArray();
            intensitystr = json;
            //print(myJson.hum);
            if (myJson.hum == 0)
            {
                intensity = false;
            }
            else {
                intensity = true;
            }
            print(intensity);
            print(intensity == true);
            print(intensity == false);
        };

    }

    // Update is called once per frame
    void Update()
    {
        Light l = lightComp.GetComponent<Light>();
        textcube.text = intensitystr;
        if (intensity == true)
        {
            if (l != null) {
                //print("开");
                //print(lightComp.intensity);
                cube.material.color = new Color(255, 0, 0);
                l.enabled = true;
                //print(lightComp.intensity);
            }

        }
        else {
            if (l != null)
            {
                //print("关");
                cube.material.color = new Color(0, 0, 0);
                l.enabled = false;
            }
            
            //print(lightComp.intensity);
        }
        //lightComp.intensity = 0;
    }
    //�����¼�
    private void ToggleOnValueChanged(bool isOn)
    {
        if (isOn)
        {
            HslCommunication.OperateResult connect = mqttClient.PublishMessage(new MqttApplicationMessage()
            {
                Topic = MYSubscribeTopic,                 //����
                QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,       //�����ʵʱ���ݣ��ʺ������
                Payload = Encoding.UTF8.GetBytes("1")
            });
            //UnityEngine.Debug.Log("Topic:" + connect);
            if (connect.IsSuccess)
            {
                //�����ɹ�
                //UnityEngine.Debug.Log("�����ɹ�");
            }
            else
            {
                //UnityEngine.Debug.Log("����ʧ��");
            }
            //Debug.Log("��");
        }
        else
        {
            HslCommunication.OperateResult connect = mqttClient.PublishMessage(new MqttApplicationMessage()
            {
                Topic = MYSubscribeTopic,                 //����
                QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,       //�����ʵʱ���ݣ��ʺ������
                Payload = Encoding.UTF8.GetBytes("0")
            });
            //UnityEngine.Debug.Log("Topic:" + connect);
            if (connect.IsSuccess)
            {
                //�����ɹ�
                //UnityEngine.Debug.Log("�����ɹ�");
            }
            else
            {
                //UnityEngine.Debug.Log("����ʧ��");
            }
            //Debug.Log("��");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        MyJsonClass myJson = JsonConvert.DeserializeObject<MyJsonClass>(intensitystr);

        if (myJson.hum == 0)
        {
            //lightComp.intensity = 0;
            intensity = false;
            ToggleOnValueChanged(true);
        }
        else
        {
            ToggleOnValueChanged(false);
        }
    }
}
