using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 5f;
    public LayerMask mask;
    private Vector3 destPos;

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);
        if(Physics.Raycast(ray, out hit,100f,mask)) 
        {
            destPos = hit.point;
        }

        Vector3 dir = destPos - transform.position;
        dir.y = 0;
        dir = dir.normalized;

        // 현재 회전과 목표 회전 각도의 차이를 확인
        float angle = Vector3.Angle(transform.forward, dir);

        // 일정 각도 이상 차이가 날 때만 회전
        if (angle > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }
    }
}

