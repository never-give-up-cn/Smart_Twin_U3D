using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincubemove : MonoBehaviour
{

    float moveSpeed = 10;
    //��������ƶ����ٶȡ�

    //��ȡˮƽ���������ֵ��

    //��ȡ��ֱ���������ֵ��

    //�������ƶ��� XYZ ���꣬�ֱ���Ϊ horizontalInput��0 �Լ� verticalInput��
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
