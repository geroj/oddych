using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Oddych{
	/// <summary>
	/// Application entry point used for testing
	/// </summary>
	public class RestManagerTest : MonoBehaviour {
		
		/************************
		 * Implementation
		 * *********************/
		// Use this for initialization
		void Start () {
			Debug.Log("Starting stuff...\n", gameObject);
			//SendGetRequest ();
			//Debug.Log("After get request\n", gameObject);
			SendPostRequest ();
			Debug.Log("After post request\n", gameObject);
		}

		// Update is called once per frame
		void Update () {
		}

		void SendGetRequest(){
			//GameObject obj = new GameObject();
			GetMethod test = gameObject.AddComponent<GetMethod>();
			const String _URL = "http://jsonplaceholder.typicode.com/posts";
			test.Start(_URL);
			Debug.Log ("som tu");
		}

		void SendPostRequest(){
			
			PostMethod test = gameObject.AddComponent<PostMethod>();
			const String _URL = "http://jsonplaceholder.typicode.com/posts";
			test.Start(_URL);
			Debug.Log ("som tu");
		}
	} //class
} //namespace
