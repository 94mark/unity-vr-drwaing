using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseCursor : MonoBehaviour
{
    // 문자에 태그를 걸고
    // 클릭 시 마우스 포인터(스프라이트 마스크)의 좌표가 태그에 일치하면(Ray)
    // 스프라이트 마스크를 Instantiate 해준다

    // 획순 순서에 따라?
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = Input.mousePosition;
        target += new Vector3(0, 0, 1);
        transform.position = Camera.main.ScreenToWorldPoint(target);
    }
}
