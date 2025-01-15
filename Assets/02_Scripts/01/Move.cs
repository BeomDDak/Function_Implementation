using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float moveSpeed = 6f;

    void Update()
    {
        // Ű ���� ����
        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDir += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDir += Vector3.back;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDir += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDir += Vector3.right;
        }

        // �̵�
        if (moveDir != Vector3.zero)
        {
            moveDir.Normalize();
            transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        }

        // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));

        // ���� ��ġ���� ���콺 ��ġ�� ���ϴ� ���� ���� ���
        Vector3 rotateDir = mousePosition - transform.position;

        // y�� ȸ���� �ʿ��ϹǷ� y���� 0���� ����
        rotateDir.y = 0;

        // ���� ����ȭ
        rotateDir = rotateDir.normalized;
        float mouseAngle = Vector3.Angle(transform.forward, rotateDir);

        // ������ ���� ���� ȸ�� (magnitude�� 0�̸� ȸ�� X)
        if (rotateDir.magnitude > 3f || mouseAngle > 6f)
        {
            // ������ Ŭ���� ȸ�� �ӵ��� ����
            float rotationSpeed = Mathf.Lerp(10f, 3f, mouseAngle / 180f);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotateDir), rotationSpeed * Time.deltaTime);
        }
    }
}