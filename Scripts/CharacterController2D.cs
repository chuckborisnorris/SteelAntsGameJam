using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {
	
   	public GameObject posMarker;
    public float speed;
    private Vector2 targetPosition;
	private GameObject item;
	private GameObject check;
	private bool itemHeld;
	private bool inObj;
	private bool talking;
	
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
        }
		
		if (targetPosition.x < transform.position.x) {
			transform.localRotation = Quaternion.Euler(0, 180, 0);
		} else if (targetPosition.x > transform.position.x){
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
		
		Vector2 cosUnityIsSoClever = this.transform.position;
        this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, speed * Time.deltaTime);
        
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
		
		float deltaX = transform.position.x-cosUnityIsSoClever.x;
		float deltaY = transform.position.y-cosUnityIsSoClever.y;
		float mag = deltaX*deltaX + deltaY*deltaY;
		gameObject.GetComponent<Animator>().speed = mag*500; //Unity can ruin its processing speed but can't add a simple magnitude routine
    	
	
	}
	
	void OnTriggerEnter2D  (Collider2D other) {
	    if(other.gameObject.tag == "item" && !inObj) {
			other.gameObject.GetComponent<ShowText>().Show();
			Time.timeScale = 0;
			item = other.gameObject;
			inObj = true;
	    }
		if(other.gameObject.tag == "check" && itemHeld) {
			other.gameObject.GetComponent<ShowText>().Show();
			Time.timeScale = 0;
			check = other.gameObject;
	    }
		if(other.gameObject.tag == "check" && !itemHeld) {
			other.gameObject.GetComponent<ShowText>().ShowDialogue();
			Time.timeScale = 0;
			talking = true;
	    }
		if(other.gameObject.tag == "no_item") {
			other.gameObject.GetComponent<ShowText>().ShowDialogue();
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
		//item.transform.parent = transform;
		//item.transform.localPosition = new Vector2(0f,0f);
		itemHeld = true;
		Resume();
	}
	
	public void DropItem () {
		//item.transform.parent = null;
		itemHeld = false;
		Resume();
	}
	
	public void UseItem () {
		DropItem();
		// check.doThing()
	}
	
	public void Resume() {
		Time.timeScale = 1.0f;
	}
}