using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{

    float angle =100f;
    Vector3 center=new Vector3(0,0,0);
    Vector3 startPos;
	// Use this for initialization
    void Start()
    {
        startPos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
	{
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (transform.position.z < -10f)
            {
                // Sampleを中心に自分を現在の上方向に、毎秒angle分だけ回転する。
                Vector3 axis = transform.TransformDirection(Vector3.up);
                transform.RotateAround(center, axis, -angle * Time.deltaTime * Input.GetAxis("Horizontal"));
                transform.LookAt(center);
            }
        }
        else
        {
            float dis = transform.position.x - startPos.x;
            Vector3 axis = transform.TransformDirection(Vector3.up);
            if (dis>0){
                transform.RotateAround(center, axis, angle/10 * Time.deltaTime*dis);
            }
            else
            {
                transform.RotateAround(center, axis, angle/10 * Time.deltaTime*dis);
            }
            transform.LookAt(center);
        }
        
	}
}