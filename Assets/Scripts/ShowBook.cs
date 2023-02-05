using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBook : MonoBehaviour
{
	public GameObject book;
	
    void Update()
    {	
		if (book.activeSelf) {
			if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))   {
				book.SetActive(false);
				GameObject.Find("Player").GetComponent<CharacterController2D>().Resume();
				GameObject.Find("StoryController").GetComponent<StoryController>().BookRead();
			}
		}
    }

    public void Open() {
		book.SetActive(true);
	}
}
