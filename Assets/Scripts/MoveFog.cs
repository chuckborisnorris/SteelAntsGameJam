using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFog : MonoBehaviour
{
	public float speed;
	public float threshold;
	private float dist;
	private bool left;
	
    void Awake()
    {
        dist = 0;
		left = false;
    }

    void Update()
    {
		float rand = Random.Range(0.01f,0.1f);
        if (left) {
			Vector2 pos = transform.position;
			pos.x -= speed;
			dist -= speed;
			transform.position = pos;
			
		} else {
			Vector2 pos = transform.position;
			pos.x += speed;
			dist += speed;
			transform.position = pos;
		}
		
		if (Mathf.Abs(dist) > threshold) {
				left = !left;
			}
    }
}
