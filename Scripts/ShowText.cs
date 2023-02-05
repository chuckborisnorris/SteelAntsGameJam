 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 
 public class ShowText : MonoBehaviour {

	 public string charName;
     public string message;
//	 public string dialogue1;
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
		 StoryController story = GameObject.FindGameObjectWithTag("story").GetComponent<StoryController>();
		 string dialogue = story.GetDialogue(charName);
		 textBox.GetComponentInChildren<Text>().text = dialogue;
		 story.Progress(charName,1);
		 textBox.SetActive(true);	 
	 }
 
//     IEnumerator TypeText() {
//         foreach (char letter in message.ToCharArray()) {
//             textComp.text += letter;
//             yield return new WaitForSeconds (letterPause);
//         }
//     }
 }
