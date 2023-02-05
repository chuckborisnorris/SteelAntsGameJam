using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {

	public GameObject shovel;
	public GameObject skull;
   	public GameObject posMarker;
    public float speed;
    private Vector2 targetPosition;
	private GameObject item;
	private GameObject check;
	private bool itemHeld;
	private bool inObj;
	private bool talking;
	private int witchCounter = 1;
	
    void Start()   {      
        targetPosition = new Vector2(0.0f, 0.0f);
		itemHeld = false;
		inObj = false;
		talking = false;
    }

    void Update()    {
        if (Input.GetMouseButton(0))   {
            targetPosition = Input.mousePosition;
            targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(targetPosition.x, targetPosition.y, 0.0f));
			speed = 2.0f;
        }
		
		if (targetPosition.x < transform.position.x) {
			transform.localRotation = Quaternion.Euler(0, 180, 0);
		} else if (targetPosition.x > transform.position.x){
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
		
		Vector2 cosUnityIsSoClever = this.transform.position;
        this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, speed * Time.deltaTime);
        
		float deltaX = transform.position.x-cosUnityIsSoClever.x;
		float deltaY = transform.position.y-cosUnityIsSoClever.y;
		float mag = deltaX*deltaX + deltaY*deltaY;
		gameObject.GetComponent<Animator>().speed = mag*500;
		
		if (Input.GetMouseButtonUp(0)) {
			Instantiate(posMarker, targetPosition , Quaternion.identity);
		} 
		
		if (Input.GetMouseButtonUp(0) && talking) {
			GameObject.Find("Textbox").SetActive(false);
			talking = false;
			Resume();
		} 
		
		if (Input.GetMouseButtonDown(1) && itemHeld)   {
            gameObject.GetComponent<ShowText>().Show();
        }
		
		if (itemHeld) {
			item.transform.position = gameObject.transform.position;
		}  	
	
	}
	
	void OnTriggerEnter2D  (Collider2D other) {
	    if(other.gameObject.tag == "item" && !inObj && !itemHeld) {
			other.gameObject.GetComponent<ShowText>().Show();
			Time.timeScale = 0;
			item = other.gameObject;
			inObj = true;
	    }
		if(other.gameObject.tag == "shovelcheck" && itemHeld && item == shovel ) {
			other.gameObject.GetComponent<ShowText>().Show();
			Time.timeScale = 0;
			check = other.gameObject;
	    }
		if(other.gameObject.tag == "shovelcheck" && !itemHeld) {
			other.gameObject.GetComponent<ShowText>().ShowDialogue();
			Time.timeScale = 0;
			talking = true;
		}	
		if(other.gameObject.tag == "skullcheck" && itemHeld && item == skull ) {
			other.gameObject.GetComponent<ShowText>().Show();
			Time.timeScale = 0;
			check = other.gameObject;
	    }
		if(other.gameObject.tag == "skullcheck" && !itemHeld) {
			other.gameObject.GetComponent<ShowText>().ShowDialogue();
			Time.timeScale = 0;
			talking = true;
	    }
		if(other.gameObject.tag == "no_item") {
			other.gameObject.GetComponent<ShowText>().ShowDialogue();
			Time.timeScale = 0;
			talking = true;
	    }
		if(other.gameObject.tag == "ending") {
			other.gameObject.GetComponent<ShowText>().EndingText();
			Time.timeScale = 0;
			talking = true;
	    }
	}
	void OnTriggerExit2D  (Collider2D other) {
	    if(other.gameObject.tag == "item") {
			inObj = false;
	    }
	}
	
	public void HoldItem () {
		itemHeld = true;
		Resume();
	}
	
	public void DropItem () {
		itemHeld = false;
		Resume();
	}
	
	public void UseShovel () {
		item = skull;
		Resume();
	}
	
	public void UseSkull () {
		itemHeld = false;
		item = null;
		StoryController story = GameObject.FindGameObjectWithTag("story").GetComponent<StoryController>();
		witchCounter++;
		Debug.Log(witchCounter);
		story.Progress("Witch",witchCounter);
		Resume();
	}
	
	public void Resume() {
		Time.timeScale = 1.0f;
	}
}