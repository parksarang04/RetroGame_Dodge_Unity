using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*������ �ٵ� ������Ʈ�� ������(Rigidbody) �Ҵ��� Rigidbody Ÿ���� ���� playerRigidbody.
    �׷���, Rigidbody Ÿ���� ���� playerRigidbody�� �����Ѵٰ� �ؼ� Rigidbody Ÿ�� ������Ʈ�� ����x*/

    public Rigidbody playerRigidbody;   //�̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f;            //�̵� �ӷ�

    void Start()
    {

    }


    void Update()
    {
        //���� ����Ű �Է��� ������ ��� z ���� �� �ֱ�
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }


        //�Ʒ��� ����Ű �Է��� ������ ��� -z ���� �� �ֱ�
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }

        //������ ����Ű �Է��� ������ ��� x ���� �� �ֱ�
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }

        //���� ����Ű �Է��� ������ ��� -x ���� �� �ֱ�
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
    }

    public void Die()
    {
        //�ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);    //SetVctive = ������Ʈ Ȱ��ȭ / ��Ȱ��ȭ

    }
}

