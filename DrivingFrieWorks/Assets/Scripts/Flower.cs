using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        //自分を消す
        if (gameObject.particleSystem.duration <= gameObject.particleSystem.time)
        {
            Destroy(gameObject);
        }
	}
}