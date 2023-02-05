using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
	bool isRead = false;
	int k_seq, m_seq, o_seq, w_seq = 0;
	public GameObject witch;
	public GameObject grave;
	public GameObject nextGrave;
	public GameObject mum;
	
	public void BookRead () {
		isRead = true;
	}
	
    public string GetDialogue(string charName) {
		if (charName == "Dad") {
			return "Dad's grave... what happened Dad?";
		}
		if (charName == "Gran") {
			return "Here Lies Gertrude Stenson, taken far too early... that's Grandma's grave!";
		}
		if (charName == "Gramps") {
			return "Unmarked grave...";
		}
		if (charName == "Keeper") {
			if (k_seq <= 1) {
				return "I love my shovel. I've been digging graves my whole life, this shovel has been with me the whole way; goes through the ground like a hot knife through butter.";
			}
			if (k_seq >= 2 && k_seq < 4) {
				return "If you really want to dig up your Dad then take my shovel. But don't tell your Mum I let you use it!";
			}
			if (k_seq >= 4 && k_seq < 6) {
				return "Willie Stenson is that unmarked grave over there. I hate to tell you this kid  but he was locked away for murdering his wife, soon after your father was born.";
			}
			if (k_seq >= 6 && k_seq < 8) {
				return "Jack and Vera? Famous missing persons case. But they can't be your grandad's parents because they went missing a year before he was born. Unless he was adopted of course.";
			}
		}
		if (charName == "Mum") {
			if (m_seq <= 1) {
				return "Be careful out there and don't talk to the witch! She'll put bad ideas in your head.";
			}
			if (m_seq >= 2 && m_seq < 4) {
				return "You Father would never talk about his family, Maybe ask the grave keeper, they used to be drinking buddies.";
			}
			if (m_seq >= 4 && m_seq < 6) {
				return "What?! Where did you here that name? Don't ever mention it around me again.";
			}
			if (m_seq >= 6 && m_seq < 8) {
				return "Please leave me alone darling, I need to look after the baby. If you have questions, read a book.";
			}
		}
		if (charName == "OldMan") {
			if (o_seq <= 1) {
				return "This town is cursed. There's been many murders in the past...";
			}
			if (o_seq >= 2 && o_seq < 4) {
				return "It was very hard on all of us when your Father committed suicide. It seemed like he was scared of something for a long time beforehand...";
			}
			if (o_seq >= 4 && o_seq < 6) {
				return "Willie? The old serial killer? I remember him well, his family were well off but they were crazy; dabbled in Occultology. It must have rubbed off on him...";
			}
			if (o_seq >= 6 && o_seq < 8) {
				return "Jack and Vera? No, that's not right. Willie parents were the old Baron and Baroness. You can probably read about them somewhere...";
			}
		}
		if (charName == "Witch") {
			if (w_seq == 1) {
				k_seq = 2;
				m_seq = 2;
				o_seq = 2;
				return "If you want to know more about your father's family, I can tell you. I just need a DNA sample. Try checking his grave if you can't find anything at home";
			}
			if (w_seq == 2) {
				k_seq = 4;
				m_seq = 4;
				o_seq = 4;
				return "Your father's mother, you already know. Your father's father went by the name of 'Willie Stenson'. Ask around, maybe somebody has heard of him.";
			}
			if (w_seq == 3) {
				k_seq = 6;
				m_seq = 6;
				o_seq = 6;
				return "It appears your grandfather's parents were serfs by the names of 'Jack and Vera Duckworth'. I can tell you no more unfortunately.";
			}
			if (w_seq == 4) {
				mum.tag = "ending";
				return "I understand now. The first son... of the first son... of the first son. Grandad, Dad... I better go find Mum.";
			}
		}
		return "wut?";
	}

	public int GetSeq(string charName) {
		if (charName == "Keeper") {
			return k_seq;
		}
		if (charName == "Mum") {
			return m_seq;
		}
		if (charName == "OldMan") {
			return o_seq;
		}
		if (charName == "Witch") {
			return w_seq;
		}
		return 0;
	}
	
	public void Progress (string charName, int seq) {
		if (charName == "Keeper") {
			k_seq = seq;
		}
		if (charName == "Mum") {
			m_seq = seq;
		}
		if (charName == "OldMan") {
			o_seq = seq;
		}
		if (charName == "Witch") {
			w_seq = seq;
		}
		if (k_seq == 1 && m_seq == 1 && o_seq == 1 && w_seq == 0) {
			w_seq = 1;
			witch.SetActive(true);
		}
		if (k_seq == 3 && m_seq == 3 && o_seq == 3 && w_seq == 1) {
			grave.tag = "shovelcheck";
		}
		if (k_seq == 5 && m_seq == 5 && o_seq == 5 && w_seq == 2) {
			nextGrave.tag = "shovelcheck";
		}
		if (k_seq == 7 && m_seq == 7 && o_seq == 7 && w_seq == 3 && isRead) {
			w_seq = 4;
		}
	}
}
