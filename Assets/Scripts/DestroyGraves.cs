using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGraves : MonoBehaviour
{
    public GameObject grave;
	public GameObject nextGrave;
	private bool first;
	
	void Start () {
		first = true;
	}

    public void GraveRob() {
		if (first) {
			Destroy(grave);
			first = false;
		} else {
			Destroy(nextGrave);
		}
	}
}
