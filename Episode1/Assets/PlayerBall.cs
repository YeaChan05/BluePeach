using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower = 10;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update(){
        if(Input.GetButtonDown("Jump")){
            rigid.AddForce(new Vector3(0,jumpPower,0),ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h,0,v),ForceMode.Impulse);
    }
    /*public void Shoot()
    {   //Y축으로 200만큼 Z 축으로 2000만큼의 힘으로 발사시키는 함수
        Vector3 speed = new Vector3(0, 200, 2000);
        GetComponent<Rigidbody>().AddForce(speed);
    }*/
    
}
