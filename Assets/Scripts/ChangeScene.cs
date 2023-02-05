using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	bool fade = false;
    // Start is called before the first frame update
   	public void FuckingFadeAlready() {
		gameObject.SetActive(true);
		fade = true;
        StartCoroutine(FUCKINGFADE(1.0f, 3.0f));
    }
	
     IEnumerator FUCKINGFADE(float aValue, float aTime) {
	 	if (fade) {
			 float alpha = transform.GetComponent<Image>().color.a;
			 
			 for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
				 Color newColour = new Color(0, 0, 0, Mathf.Lerp(alpha, aValue, t));
				 transform.GetComponent<Image>().color = newColour;
				 if (newColour.a > 0.99f) {
					fade = false;
					SceneManager.LoadScene(1);
				 }
				 yield return null;
			 }
		 }
     }
}
