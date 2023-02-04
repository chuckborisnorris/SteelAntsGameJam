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
	
    void Start()   {      
        targetPosition = new Vector2(0.0f, 0.0f);
		itemHeld = false;
    }

    void Update()    {
        if (Input.GetMouseButton(0))   {
            targetPosition = Input.mousePosition;
            targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(targetPosition.x, targetPosition.y, 0.0f));
        }
		
        this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, speed * Time.deltaTime);
        
		if (Input.GetMouseButtonUp(0)) {
			Instantiate(posMarker, targetPosition , Quaternion.identity);
		}  
		
		if (Input.GetMouseButtonDown(1) && itemHeld)   {
            gameObject.GetComponent<ShowText>().Show();
        }
    }
	
	void OnTriggerEnter2D  (Collider2D other) {
	    if(other.gameObject.tag == "item") {
			other.gameObject.GetComponent<ShowText>().Show();
			Time.timeScale = 0;
			item = other.gameObject;
	    }
		if(other.gameObject.tag == "check" && itemHeld) {
			other.gameObject.GetComponent<ShowText>().Show();
			Time.timeScale = 0;
			check = other.gameObject;
	    }
	}
	
	public void HoldItem () {
		item.transform.parent = transform;
		item.transform.localPosition = new Vector2(0f,0f);
		itemHeld = true;
		Resume();
	}
	
	public void DropItem () {
		item.transform.parent = null;
		itemHeld = false;
		Resume();
	}
	
	public void UseItem () {
		Destroy(item,0.0f);
		itemHeld = false;
		Resume();
		// check.doThing()
	}
	
	public void Resume() {
		Time.timeScale = 1.0f;
	}
}