using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPaint : MonoBehaviour
{
    Coroutine drawing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartLine();
        }
        if(Input.GetMouseButtonUp(0))
        {
            FinishLine();
        }
    }

    void StartLine()
    {
        if(drawing!=null)
        {
            StopCoroutine(drawing);
        }
        drawing = StartCoroutine(DrawLine());
    }

    void FinishLine()
    {
        StopCoroutine(drawing);
    }

    IEnumerator DrawLine()
    {
        GameObject newGameObject = Instantiate(Resources.Load("Line") as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
        LineRenderer line = newGameObject.GetComponent<LineRenderer>();
        line.positionCount = 0;
        
        while(true)
        {
            Vector3 position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            position.z = 0;
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, position);
            yield return null;
        }
    }
}
