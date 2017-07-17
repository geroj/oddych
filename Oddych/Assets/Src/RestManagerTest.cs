using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


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
			//Debug.Log("After GET request\n", gameObject);
			//SendPostRequest ();
			//Debug.Log("After POST request\n", gameObject);
			//SendDeleteRequest ();
			//Debug.Log("After DELETE request\n", gameObject);

			Debug.Log ("before Get NEW");
			SendGetRequestNew();
			Debug.Log ("after Get NEW");
		}

		// Update is called once per frame
		void Update () {
		}

		void SendGetRequestNew(){
			GetMethod test = gameObject.AddComponent<GetMethod>();
			const String _URL = "http://jsonplaceholder.typicode.com/comments?postId=1";
			UnityWebRequest result = test.StartNew(_URL);

			//if (result.downloadHandler.text == null) {
			//	print ("GET NEW null");
			//}
			print (result.downloadHandler.text.Length);
			print ("GET NEW result" + result.downloadHandler.text);
			Debug.Log ("End of GetRequestNow");
		}

		void SendGetRequest(){
			GetMethod test = gameObject.AddComponent<GetMethod>();
			//const String _URL = "http://jsonplaceholder.typicode.com/posts";
			const String _URL = "http://jsonplaceholder.typicode.com/comments?postId=1";
			test.Start(_URL);
			Debug.Log ("som tu");
		}

		void SendPostRequest(){
			
			PostMethod test = gameObject.AddComponent<PostMethod>();
			const String _URL = "http://jsonplaceholder.typicode.com/posts";
			const String _WEBDATA = 
				//"{\n  \"userId\": 1,\n  \"id\": 1,\n  \"title\": \"some fancy title by Ondrej Mikulas\"}";
				"{\n  \"userId\": 1,\n \"title\": \"some fancy title by Ondrej Mikulas\"}";
			test.Start(_URL, _WEBDATA);
			test.Start(_URL, _WEBDATA);
			test.Start(_URL, _WEBDATA);
			test.Start(_URL, _WEBDATA);
			Debug.Log ("som tu");
		}

		void SendDeleteRequest(){
			GetMethod test = gameObject.AddComponent<GetMethod>();
			const String _URL = "http://jsonplaceholder.typicode.com/posts";
			test.Start(_URL);
			Debug.Log ("som tu");
		}
	} //class
} //namespace
