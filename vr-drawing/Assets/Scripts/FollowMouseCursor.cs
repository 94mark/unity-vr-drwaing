using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseCursor : MonoBehaviour
{
    public GameObject targetFactory;
    float currentTime = 0;
    float createTime = 2f;
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
        currentTime += Time.deltaTime;
        if(Input.GetButtonDown("Fire1"))
        {
            if(currentTime > createTime)
            {
                OnMouseDrag();
                currentTime = 0;
            }
        }

        /*if(createTime > currentTime)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                OnMouseDrag();
                currentTime = 0;
            }
        }*/
    }

    private void OnMouseDrag()
    {
         Vector3 target = Input.mousePosition;
         target += new Vector3(0, 0, 1);
         transform.position = Camera.main.ScreenToWorldPoint(target);
         GameObject drawing = Instantiate(targetFactory);
           
    }
    // 프레임마다 생성되게 하니 프로그램이 뻑이가는 문제 
    // 클릭을 다시하면 기존에 생성된 마스크가 없어지는 문제
}
