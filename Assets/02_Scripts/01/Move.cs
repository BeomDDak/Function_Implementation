using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float moveSpeed = 6f;

    void Update()
    {
        // 키 방향 설정
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

        // 이동
        if (moveDir != Vector3.zero)
        {
            moveDir.Normalize();
            transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        }

        // 마우스 위치를 월드 좌표로 변환
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));

        // 현재 위치에서 마우스 위치를 향하는 방향 벡터 계산
        Vector3 rotateDir = mousePosition - transform.position;

        // y축 회전만 필요하므로 y값은 0으로 설정
        rotateDir.y = 0;

        // 방향 정규화
        rotateDir = rotateDir.normalized;
        float mouseAngle = Vector3.Angle(transform.forward, rotateDir);

        // 방향이 있을 때만 회전 (magnitude가 0이면 회전 X)
        if (rotateDir.magnitude > 3f || mouseAngle > 6f)
        {
            // 각도가 클수록 회전 속도를 줄임
            float rotationSpeed = Mathf.Lerp(10f, 3f, mouseAngle / 180f);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotateDir), rotationSpeed * Time.deltaTime);
        }
    }
}