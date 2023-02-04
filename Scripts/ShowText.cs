 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 
 public class ShowText : MonoBehaviour {

     public string message;
	 public string dialogue1;
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
	 
	 public void ShowDialogue ()  {
		 textBox.GetComponentInChildren<Text>().text = dialogue1;
		 textBox.SetActive(true);	 
	 }
 
//     IEnumerator TypeText() {
//         foreach (char letter in message.ToCharArray()) {
//             textComp.text += letter;
//             yield return new WaitForSeconds (letterPause);
//         }
//     }
 }
