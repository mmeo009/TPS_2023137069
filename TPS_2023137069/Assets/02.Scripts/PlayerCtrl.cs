using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField]
    private Transform tr;

    // Animation ������Ʈ�� ������ ����
    private Animation anim;

    public float moveSpeed = 8.0f;
    //�̼�

    public float turnSpeed = 500.0f;
    //ȸ��

    void Start()
    {
        // Transform ������Ʈ�� ������ ������ ����
        tr = GetComponent<Transform>();

        anim = GetComponent<Animation>();

        anim.Play("Idle");
    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f

        float v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f

        float r = Input.GetAxis("Mouse X");

/*        Debug.Log("h=" + h);

        Debug.Log("v=" + v);*/

        /*        transform.position += new Vector3(0, 0, 1);*/
        // Transform ������Ʈ�� position �Ӽ����� ����

        /*        transform.position += Vector3.forward * 1;*/
        /*        tr.Translate(Vector3.forward * 1);*/
        //����ȭ ���� ���

        // �����¿� �̵� ���� ���� ���

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        // Translate(�̵� ���� * �ӷ� * Time.deltaTime)

        tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed);

        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);

        PlayerAnim(h, v);
    }

    void PlayerAnim(float h, float v)

    {

        // Ű���� �Է°��� �������� ������ �ִϸ��̼� ����

        if (v >= 0.1f)

        {

            anim.CrossFade("RunF", 0.25f); // ���� �ִϸ��̼� ����

        }

        else if (v <= -0.1f)

        {

            anim.CrossFade("RunB", 0.25f); // ���� �ִϸ��̼� ����

        }

        else if (h >= 0.1f)

        {

            anim.CrossFade("RunR", 0.25f); // ������ �̵� �ִϸ��̼� ����

        }

        else if (h <= -0.1f)

        {

            anim.CrossFade("RunL", 0.25f); // ���� �̵� �ִϸ��̼� ����

        }

        else

        {

            anim.CrossFade("Idle", 0.25f); // ���� �� Idle �ִϸ��̼� ����

        }

    }
}
