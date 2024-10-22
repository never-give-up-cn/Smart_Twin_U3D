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
using M2MqttUnity.Examples;

public class ToggleTest : MonoBehaviour,IPointerDownHandler
{
    public Light lightComponent; // 指向灯光组件的引用
                                 // Start is called before the first frame update
    private Light theLight;// 声明一个变量来存储灯光组件
    private String intensitystr;
    private bool intensity;
    public String SubscribeMessage = "temp_hum/kunming";
    public String MYSubscribeTopic = "temp_hum/kunming111";
    private string json;
    private Toggle m_Toggle;//��ȡ��Toggle���?
    private GameObject lightComp;//��ȡ��Toggle���?
    private MeshRenderer cube;
    private TextMeshPro textcube;
    private M2MqttUnityTest mqttClient;
    private GameObject gameObject;
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

         gameObject = GameObject.Find("tableLamp");
        // 获取 MQTT 客户端的引用，假设它已经在场景中初始化了
        mqttClient = FindObjectOfType<M2MqttUnityTest>();
        if (mqttClient != null)
        {
            // 订阅事件
            mqttClient.OnMessageReceived += HandleMessageReceived;
        }

    }

    private void HandleMessageReceived(string topic, string message)
    {
        Light l = gameObject.GetComponent<Light>();
        if (gameObject.GetComponent<Light>() == null) {
            l = gameObject.AddComponent<Light>();
            l.color = Color.blue;
        }
        // 在这里处理接收到的消息
        Debug.Log("在这里处理接收到的消息Message received on topic: " + topic + " with content: " + message);
        MyJsonClass myObject = JsonConvert.DeserializeObject<MyJsonClass>(message);
        if (myObject.hum == 1)
        {
            l.enabled = true;
        }
        else {
            l.enabled = false;
        }
    }
    void OnDestroy()
    {
        if (mqttClient != null)
        {
            // 取消订阅事件，防止内存泄漏
            mqttClient.OnMessageReceived -= HandleMessageReceived;
        }
    }

    // 添加一个公共方法来供外部调用
    public void ExternalToggleOnValueChanged(bool isOn)
    {
        ToggleOnValueChanged(isOn);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    //�����¼�
    private void ToggleOnValueChanged(bool isOn)
    {
      
        if (isOn)
        {

        }
        else
        {
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
