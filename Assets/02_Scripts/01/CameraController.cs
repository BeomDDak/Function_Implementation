using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;        // 플레이어의 Transform
    public Vector3 offset = new Vector3(0, 10, -5);  // 카메라와 플레이어 사이의 거리
    public float smoothSpeed = 5f;  // 카메라 이동 부드러움 정도

    void LateUpdate()  // Update 대신 LateUpdate 사용
    {
        // 목표 위치 계산
        Vector3 desiredPosition = target.position + offset;

        // 부드러운 이동을 위해 Lerp 사용
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // 카메라 위치 업데이트
        transform.position = smoothedPosition;

        // 카메라가 항상 플레이어를 바라보게 함
        transform.LookAt(target);
    }
}
