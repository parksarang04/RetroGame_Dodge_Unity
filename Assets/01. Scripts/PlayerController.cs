using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*리지드 바디 컴포넌트를 가져와(Rigidbody) 할당할 Rigidbody 타입의 변수 playerRigidbody.
    그러나, Rigidbody 타입의 변수 playerRigidbody를 선언한다고 해서 Rigidbody 타입 오브젝트가 생성x*/

    private Rigidbody playerRigidbody;   //이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f;            //이동 속력

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();    //GetComponent 원하는 타입의 컴포넌트를 자신의 게임 오브젝트에서 찾아오는 메서드.
                                                        //GetComponent 메서드가 컴포넌트를 찾지 못했을 때는 null을 반환한다.
    }


    void Update()
    {
        /*
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
        }*/

        //개선된 조작 코드

        //수평축과 수직축의 입력값을 감지하여 저장
        //GetAxis = 어떤 축에 대한 입력값을 숫자로 반환
        float xInput = Input.GetAxis("Horizontal");     // A-D
        float zInput = Input.GetAxis("Vertical");       // W-S

        //실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);  // y값 (위아래 점프)를 움직임을 막고 2D 평면에서만 움직임 가능
        
        //리지드바디의 속도에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        //자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);    //SetVctive = 오브젝트 활성화 / 비활성화

        //씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();
        //가져온 Gamemanager 오브젝트의 EndGame() 메서드 실행
        gameManager.EndGame();

    }
}

