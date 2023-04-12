using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField]
    private Transform tr;

    // Animation 컴포넌트를 저장할 변수
    private Animation anim;

    public float moveSpeed = 8.0f;
    //이속

    public float turnSpeed = 500.0f;
    //회속

    void Start()
    {
        // Transform 컴포넌트를 추출해 변수에 대입
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
        // Transform 컴포넌트의 position 속성값을 변경

        /*        transform.position += Vector3.forward * 1;*/
        /*        tr.Translate(Vector3.forward * 1);*/
        //정규화 백터 사용

        // 전후좌우 이동 방향 벡터 계산

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        // Translate(이동 방향 * 속력 * Time.deltaTime)

        tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed);

        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);

        PlayerAnim(h, v);
    }

    void PlayerAnim(float h, float v)

    {

        // 키보드 입력값을 기준으로 동작할 애니메이션 수행

        if (v >= 0.1f)

        {

            anim.CrossFade("RunF", 0.25f); // 전진 애니메이션 실행

        }

        else if (v <= -0.1f)

        {

            anim.CrossFade("RunB", 0.25f); // 후진 애니메이션 실행

        }

        else if (h >= 0.1f)

        {

            anim.CrossFade("RunR", 0.25f); // 오른쪽 이동 애니메이션 실행

        }

        else if (h <= -0.1f)

        {

            anim.CrossFade("RunL", 0.25f); // 왼쪽 이동 애니메이션 실행

        }

        else

        {

            anim.CrossFade("Idle", 0.25f); // 정지 시 Idle 애니메이션 실행

        }

    }
}
