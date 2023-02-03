 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 
 public class ShowText : MonoBehaviour {
 
     public float letterPause = 0.2f;
 
     public string message;
//     public Text textComp;
	 public GameObject bNo;
	 public GameObject bYes;
	 public GameObject textBox;
 
     void Start () {
     }
	 
	 public void Show ()  {
		 textBox.GetComponentInChildren<Text>().text = message;
		 bNo.SetActive(true);
		 bYes.SetActive(true);
		 textBox.SetActive(true);	 
	 }
 
//     IEnumerator TypeText() {
//         foreach (char letter in message.ToCharArray()) {
//             textComp.text += letter;
//             yield return new WaitForSeconds (letterPause);
//         }
//     }
 }
