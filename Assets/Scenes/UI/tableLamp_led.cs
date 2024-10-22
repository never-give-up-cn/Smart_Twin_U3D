using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tableLamp_led : MonoBehaviour
{
    public GameObject game;
    public Light lightComponent; // 指向灯光组件的引用
                                 // Start is called before the first frame update
    private Light theLight;// 声明一个变量来存储灯光组件
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
        // 示例：按下键盘的'F'键来切换灯光
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("按下键盘的'F'键来切换灯光");
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
            print("按下键盘的'G'键来切换灯光");
            if (game != null)
            {
                Light lightComp =  game.AddComponent<Light>();
                // Set color and position
                lightComp.color = Color.blue;
            }


        }
    }
    // 调用这个方法来关闭灯光
    public void TurnOffLight()
    {
        if (lightComponent != null)
        {
            lightComponent.enabled = false;
        }
    }
    // 调用这个方法来开启灯光
    public void TurnOnLight()
    {
        if (lightComponent != null)
        {
            lightComponent.enabled = true;
        }
    }
}
