using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
         StartCoroutine(FadeTo(0.0f, 1.0f));
		 StartCoroutine(Grow(1.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,1.0f);
    }
	
     IEnumerator FadeTo(float aValue, float aTime)
     {
         float alpha = transform.GetComponent<SpriteRenderer>().material.color.a;
         for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
         {
             Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
             transform.GetComponent<SpriteRenderer>().material.color = newColor;
             yield return null;
         }
     }
	 
	 IEnumerator Grow(float gValue, float gTime)
     {
         for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / gTime)
         {
             Vector2 scale = new Vector2(Mathf.Lerp(0, gValue, t),Mathf.Lerp(0, gValue, t));
             transform.localScale = scale;
             yield return null;
         }
     }
}
