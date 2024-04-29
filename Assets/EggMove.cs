using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMove : MonoBehaviour
{
    private float movementSpeed;
    Vector3 direct;
    float max_x;
    float max_y;
    float min_x;
    float min_y;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed=10f;
        direct=new Vector3(transform.position.x/Mathf.Abs(transform.position.x),transform.position.y/Mathf.Abs(transform.position.y),0.0f);
        max_x=direct.x*50;
        max_y=direct.y*50;
        min_x=direct.x;
        min_y=direct.y;

    }

    // Update is called once per frame

    void Update()
    {
        float s=Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Quits the application!");
            Application.Quit();
            return;
        }

        if(s>0)
        {
            if(Mathf.Abs(transform.position.x+direct.x*s) > 50f)
            {
                transform.position = new Vector3(max_x,max_y,0f);
            }
            else
            {
                transform.position+=(direct *s);
            }

        }
        if(s<0)
        {
            if(((direct.y < 0) && (transform.position.y+direct.y* s > -1f)) || ((direct.y > 0) && (transform.position.y+direct.y* s < 1f)))
            {
                transform.position=new Vector3(min_x,min_y,0f);
            }
            else
            {
                transform.position+=(direct * s);
            }
        }
        transform.localScale=new Vector3(5f/49f*(transform.position.x/min_x)+44f/49f,5f/49f*(transform.position.y/min_y)+44f/49f,0f);
        
    }
}
