using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*리지드 바디 컴포넌트를 가져와(Rigidbody) 할당할 Rigidbody 타입의 변수 playerRigidbody.
    그러나, Rigidbody 타입의 변수 playerRigidbody를 선언한다고 해서 Rigidbody 타입 오브젝트가 생성x*/

    public Rigidbody playerRigidbody;   //이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f;            //이동 속력

    void Start()
    {

    }


    void Update()
    {
        //위쪽 방향키 입력이 감지된 경우 z 방향 힘 주기
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }


        //아래쪽 방향키 입력이 감지된 경우 -z 방향 힘 주기
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }

        //오른쪽 방향키 입력이 감지된 경우 x 방향 힘 주기
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }

        //왼쪽 방향키 입력이 감지된 경우 -x 방향 힘 주기
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
    }

    public void Die()
    {
        //자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);    //SetVctive = 오브젝트 활성화 / 비활성화

    }
}

