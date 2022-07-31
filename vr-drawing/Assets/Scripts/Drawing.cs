using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public GameObject mask;
    public GameObject endPoint;
    public GameObject ToHo1;
    bool pressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos += new Vector3(0, 0, 1);
        // transform.position = pos;

        // Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // pos.z = 1;

        if(pressed == true)
        {
            GameObject ob = Instantiate(mask, pos, Quaternion.identity);
            ob.transform.parent = GameObject.Find("DrawingLetter").transform;

        }

        if (Input.GetMouseButton(0))
        {
            pressed = true;
        }
        else if (Input.GetMouseButtonUp(0))
            pressed = false;

    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("endPoint"))
        {
            print("11111");
            ToHo1.SetActive(false);
        }
    }*/
    // 카메라 othorgraphic에만 적용
    // perspective 적용 방안 고민
}
