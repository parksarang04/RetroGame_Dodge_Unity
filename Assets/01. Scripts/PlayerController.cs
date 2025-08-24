using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*������ �ٵ� ������Ʈ�� ������(Rigidbody) �Ҵ��� Rigidbody Ÿ���� ���� playerRigidbody.
    �׷���, Rigidbody Ÿ���� ���� playerRigidbody�� �����Ѵٰ� �ؼ� Rigidbody Ÿ�� ������Ʈ�� ����x*/

    private Rigidbody playerRigidbody;   //�̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f;            //�̵� �ӷ�

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();    //GetComponent ���ϴ� Ÿ���� ������Ʈ�� �ڽ��� ���� ������Ʈ���� ã�ƿ��� �޼���.
                                                        //GetComponent �޼��尡 ������Ʈ�� ã�� ������ ���� null�� ��ȯ�Ѵ�.
    }


    void Update()
    {
        /*
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
        }*/

        //������ ���� �ڵ�

        //������� �������� �Է°��� �����Ͽ� ����
        //GetAxis = � �࿡ ���� �Է°��� ���ڷ� ��ȯ
        float xInput = Input.GetAxis("Horizontal");     // A-D
        float zInput = Input.GetAxis("Vertical");       // W-S

        //���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 �ӵ��� (xSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);  // y�� (���Ʒ� ����)�� �������� ���� 2D ��鿡���� ������ ����
        
        //������ٵ��� �ӵ��� newVelocity �Ҵ�
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        //�ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);    //SetVctive = ������Ʈ Ȱ��ȭ / ��Ȱ��ȭ

        //���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        GameManager gameManager = FindObjectOfType<GameManager>();
        //������ Gamemanager ������Ʈ�� EndGame() �޼��� ����
        gameManager.EndGame();

    }
}

