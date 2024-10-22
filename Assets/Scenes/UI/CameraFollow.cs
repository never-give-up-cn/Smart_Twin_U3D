using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform playerTransform; // �ƶ�������
    public Vector3 deviation; // ƫ����
    public float sensitivity = 100.0f; // ���������
    public float yaw; // ˮƽ��ת�Ƕ�
    public float pitch; // ��ֱ��ת�Ƕ�

    public float pitchMin = -90.0f; // ��������С�Ƕ�
    public float pitchMax = 90.0f; // ���������Ƕ�

    void Start()
    {
        transform.rotation = playerTransform.rotation;
        deviation = transform.position - playerTransform.position; // ��ʼ�����������ƫ����=�����λ�� - �ƶ������ƫ����
                                                                   // �����ʼƫ����
    }

    void Update()
    {
       
        transform.rotation = playerTransform.rotation;
        transform.position = playerTransform.position + deviation; // �����λ�� = �ƶ������λ�� + ƫ����
                                                                   // �����ʼƫ����
                                                                   // ��ȡ���X���Y����ƶ���
                                                                   // ��ȡ���X���Y����ƶ���
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // ����ˮƽ��ת�Ƕ�
        yaw += mouseX;
        // ���´�ֱ��ת�Ƕȣ���������ָ���ķ�Χ��
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);

        // Ӧ����ת����ҵ�Transform
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    }

}

