using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    public float xmove = 0; // x축 누적 이동량
    public float ymove = 0; // y축 누적 이동량
    public float distance = 3;
    public bool stopMove = false; // 카메라 움직임 멈춤
    public float zoomSpeed = 3.0f;

    Vector3 AxisVec; // 축의 벡터
    Vector3 reverseDistance;

    void Start() 
    {
        transform.rotation = Quaternion.Euler(ymove, xmove, 0); // 이동량에 따라 카메라의 바라보는 방향을 조정
    }

    void FixedUpdate() 
    {
        reverseDistance = new Vector3(0.0f, 0.0f, distance); // 카메라가 바라보는 앞방향은 z축입니다. 이동량에 따른 z축 방향의 벡터를 구함

        transform.position = player.transform.position - transform.rotation * reverseDistance;
    }

    void Update()
    {
        if (!stopMove)
        {
            CameraMove();
            CameraZoom();
        }
    }

    void CameraMove()
    {
        if (Input.GetMouseButton(0))
        {
            if (9 <= ymove && ymove <= 95)
                ymove += Input.GetAxis("Mouse Y"); // 마우스의 상하 이동량을 ymove에 누적
            else if (ymove < 9)
                ymove = 9.0f;
            else if (ymove > 95)
                ymove = 95.0f;

            xmove += Input.GetAxis("Mouse X"); // 마우스의 좌우 이동량을 xmove에 누적

            transform.rotation = Quaternion.Euler(ymove, xmove, 0); // 이동량에 따라 카메라의 바라보는 방향을 조정

            transform.position = player.transform.position - transform.rotation * reverseDistance;
        }
    }

    void CameraZoom()
    {
        distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        if (distance < 1.0f) 
            distance = 1.0f;
        else if (distance > 4.0f) 
            distance = 4.0f;
    }
}
