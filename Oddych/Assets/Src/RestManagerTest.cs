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
			SendGetRequest ();
		}

		// Update is called once per frame
		void Update () {
		}

		void SendGetRequest(){
			//GameObject obj = new GameObject();
			WebRequestGetTest test = gameObject.AddComponent<WebRequestGetTest>();
			const String _URL = "http://jsonplaceholder.typicode.com/posts";
			test.Start(_URL);
			Debug.Log ("som tu");
		}
	} //class
} //namespace
