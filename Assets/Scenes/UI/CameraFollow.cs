using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform playerTransform; // �ƶ�������
    public Vector3 deviation; // ƫ����

    void Start()
    {
        transform.rotation = playerTransform.rotation;
        deviation = transform.position - playerTransform.position; // ��ʼ�����������ƫ����=�����λ�� - �ƶ������ƫ����
    }

    void Update()
    {
        transform.rotation = playerTransform.rotation;
        transform.position = playerTransform.position + deviation; // �����λ�� = �ƶ������λ�� + ƫ����

    }
}

