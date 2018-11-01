using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBehavior : MonoBehaviour {

	public GameObject collector;
	public float speed;
	public float turn;
	public Boolean collect;
	public Rigidbody rbObject;
	private float volume;
	

	private Rigidbody rb;

	void Start ()
	{
		volume = collector.transform.localScale.x * collector.transform.localScale.y * collector.transform.localScale.z;
		rb = GetComponent<Rigidbody>();
		collect = false;
	}

	void Update()
	{
		if (collect == true)
		{
			collector.transform.localPosition = rb.transform.localPosition + new Vector3 (0f,0f,0.4f);
			collector.transform.rotation = rb.transform.localRotation;
			//rbObject.isKinematic = true;
		}
	
	}

	void FixedUpdate ()
	{
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
		rb.AddTorque(transform.up * turn * moveHorizontal);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "collectable")
		{
			rb.mass += col.rigidbody.mass;
		     Destroy(col.rigidbody);
             col.transform.parent = transform;
             col.gameObject.GetComponent<SphereCollider>().enabled = true;
			//		Debug.Log("collide!");
			//GameObject.FindWithTag("collectable").transform.position = newPos;
			//		collect = true;
		}
	}
	
	
	
}
