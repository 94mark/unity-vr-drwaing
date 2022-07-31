using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseCursor : MonoBehaviour
{
    public GameObject targetFactory;
    float currentTime = 0;
    float createTime = 2f;
    // ���ڿ� �±׸� �ɰ�
    // Ŭ�� �� ���콺 ������(��������Ʈ ����ũ)�� ��ǥ�� �±׿� ��ġ�ϸ�(Ray)
    // ��������Ʈ ����ũ�� Instantiate ���ش�

    // ȹ�� ������ ����?
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
    // �����Ӹ��� �����ǰ� �ϴ� ���α׷��� ���̰��� ���� 
    // Ŭ���� �ٽ��ϸ� ������ ������ ����ũ�� �������� ����
}
