using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseCursor : MonoBehaviour
{
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
        Vector3 target = Input.mousePosition;
        target += new Vector3(0, 0, 1);
        transform.position = Camera.main.ScreenToWorldPoint(target);
    }
}
