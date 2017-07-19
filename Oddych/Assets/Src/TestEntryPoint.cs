using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


namespace Oddych{
	/// <summary>
	/// Application entry point used for testing
	/// </summary>
	public class TestEntryPoint : MonoBehaviour {
		
		/************************
		 * Implementation
		 * *********************/
		// Use this for initialization
		void Start () {
			//Test SpecialCoroutines
			//Test1 test1 = gameObject.AddComponent<Test1> ();
			//test1.Start ();
			//Test2 test2 = gameObject.AddComponent<Test2> ();
			//test2.Start ();
			//Test3 test3 = gameObject.AddComponent<Test3> ();
			//test3.Start ();

			const String _URL = "http://jsonplaceholder.typicode.com/comments";
			for (int i = 0; i < 10; i++) {
				Debug.Log (DateTime.Now.ToString("hh:mm:ss.fff") +  " BEFORE getting data");
				GetMethod getMethod = gameObject.AddComponent<GetMethod> ();
				String data = getMethod.GetData (_URL);
				//Debug.Log (data);
				Debug.Log(DateTime.Now.ToString("hh:mm:ss.fff") + " AFTER getting data");
			}
		}

		// Update is called once per frame
		void Update () {
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

		//void SendDeleteRequest(){
		//	GetMethod test = gameObject.AddComponent<GetMethod>();
		//	const String _URL = "http://jsonplaceholder.typicode.com/posts";
		//	test.Start(_URL);
		//	Debug.Log ("som tu");
		//}
	} //class
} //namespace
