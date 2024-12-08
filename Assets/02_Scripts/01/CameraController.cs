using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;        // �÷��̾��� Transform
    public Vector3 offset = new Vector3(0, 10, -5);  // ī�޶�� �÷��̾� ������ �Ÿ�
    public float smoothSpeed = 5f;  // ī�޶� �̵� �ε巯�� ����

    void LateUpdate()  // Update ��� LateUpdate ���
    {
        // ��ǥ ��ġ ���
        Vector3 desiredPosition = target.position + offset;

        // �ε巯�� �̵��� ���� Lerp ���
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // ī�޶� ��ġ ������Ʈ
        transform.position = smoothedPosition;

        // ī�޶� �׻� �÷��̾ �ٶ󺸰� ��
        transform.LookAt(target);
    }
}
