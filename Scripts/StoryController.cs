using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
	int k_seq, m_seq, o_seq, w_seq = 0;
	public GameObject witch;
	
    public string GetDialogue(string charName) {
		if (charName == "Keeper") {
			if (k_seq <= 1) {
				return "I love my shovel. I've been digging graves my whole life, this shovel has been with me the whole way; goes through the ground llike a hot knife through butter.";
			}
			if (k_seq == 2) {
				return "If you really want to dig up your Dad then take my shovel. But don't tell your Mum I let you use it!";
			}
		}
		if (charName == "Mum") {
			if (m_seq <= 1) {
				return "Be careful out there and don't talk to the witch! She'll put bad ideas in your head.";
			}
			if (m_seq == 2) {
				return "You Father would never talk about his family, Maybe ask the grave keeper, they used to be drinking buddies";
			}
		}
		if (charName == "OldMan") {
			if (o_seq <= 2) {
				return "This town is cursed. There's been many murders in the past.";
			}
		}
		if (charName == "Witch") {
			if (w_seq == 1) {
				k_seq = 2;
				m_seq = 2;
				o_seq = 2;
				return "If you want to know more about your father's family, I can tell you. I just need a DNA sample. Try checking his grave if you can't find anything at home";
			}
		}
		return "wut?";
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
	}
}
