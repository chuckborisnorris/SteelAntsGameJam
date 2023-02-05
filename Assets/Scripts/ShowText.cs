 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 
 public class ShowText : MonoBehaviour {

	 public string charName;
     public string message;
//	 public string dialogue1;
	 public GameObject bNo;
	 public GameObject bYes;
	 public GameObject bBoy;
	 public GameObject bGirl;
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
		 if (charName != "Witch") {
			 int seq = story.GetSeq(charName);
			 if (seq < 2 ) story.Progress(charName,1);
			 if (seq >= 2 && seq < 4) story.Progress(charName,3);
			 if (seq >= 4 && seq < 6) story.Progress(charName,5);
			 if (seq >= 6 && seq < 8) story.Progress(charName,7);
		 }
		 textBox.SetActive(true);	 
	 }
	 
	 public void EndingText() {
		 textBox.GetComponentInChildren<Text>().text = message;
		 bBoy.SetActive(true);
		 bGirl.SetActive(true);
		 textBox.SetActive(true);
	 }
 
//     IEnumerator TypeText() {
//         foreach (char letter in message.ToCharArray()) {
//             textComp.text += letter;
//             yield return new WaitForSeconds (letterPause);
//         }
//     }
 }
