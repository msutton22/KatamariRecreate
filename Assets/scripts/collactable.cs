using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collactable : MonoBehaviour {
	Collider m_Collider;

	private Boolean collides;
	// Use this for initialization
	void Start () {
		m_Collider = GetComponent<Collider>();
		collides = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "player")
		{
		}


	}
}
