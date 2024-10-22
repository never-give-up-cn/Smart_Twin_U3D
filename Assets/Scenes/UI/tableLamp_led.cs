using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tableLamp_led : MonoBehaviour
{
    public GameObject game;
    public Light lightComponent; // ָ��ƹ����������
                                 // Start is called before the first frame update
    private Light theLight;// ����һ���������洢�ƹ����
    void Start()
    {
        if (lightComponent != null)
        {
            lightComponent.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject lightGameObject = GameObject.Find("The Light");
        // ʾ�������¼��̵�'F'�����л��ƹ�
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("���¼��̵�'F'�����л��ƹ�");
            //lightComponent.enabled = !lightComponent.enabled;
            lightComponent.intensity = 1;
            // Make a game object
            if (lightGameObject == null) {
                GameObject lightGameObject1 = new GameObject("The Light");

                // Add the light component
                Light lightComp = lightGameObject1.AddComponent<Light>();

                // Set color and position
                lightComp.color = Color.blue;

                // Set the position (or any transform property)
                lightGameObject1.transform.position = new Vector3(678, 55, 61);
            }


        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (lightGameObject != null)
            {
                theLight = lightGameObject.GetComponent<Light>();
                theLight.enabled = !theLight.enabled;
            }
            

        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            print("���¼��̵�'G'�����л��ƹ�");
            if (game != null)
            {
                Light lightComp =  game.AddComponent<Light>();
                // Set color and position
                lightComp.color = Color.blue;
            }


        }
    }
    // ��������������رյƹ�
    public void TurnOffLight()
    {
        if (lightComponent != null)
        {
            lightComponent.enabled = false;
        }
    }
    // ������������������ƹ�
    public void TurnOnLight()
    {
        if (lightComponent != null)
        {
            lightComponent.enabled = true;
        }
    }
}
