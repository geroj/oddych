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

			/*
			const String _URL = "http://jsonplaceholder.typicode.com/comments";
			//const String _WEBDATA = 
				//"{\n  \"userId\": 1,\n  \"id\": 1,\n  \"title\": \"some fancy title by Ondrej Mikulas\"}";
				//"{\n  \"userId\": 1,\n \"title\": \"some fancy title by Ondrej Mikulas\"}";
			const int _REPETITIONS = 1;
			for (int i = 0; i < _REPETITIONS; i++) {
				DateTime startTime = DateTime.Now;
				RestMethods restMethods = gameObject.AddComponent<RestMethods> ();

				String data = restMethods.Get (_URL);
				//String data = restMethods.Post (_URL, _WEBDATA);
				//long data = restMethods.Delete (_URL);

				Debug.Log (data);
				DateTime endTime = DateTime.Now;
				Debug.Log("delta (end - start): " + endTime.Subtract(startTime));
			}
			*/

			/*
			for (int i = 0; i < 100; i++) {
				const String _URL2 = "https://www.bitstamp.net/api/v2/ticker/xrpusd";
				//const String _WEBDATA = 
				//"\"userId\": 1," +
				//"\"id\": 105,\"" +
				//"\"title\": \"super fancy title\"," +
				//"\"body\": \"fancy body!\"";
				DateTime startTime = DateTime.Now;
				RestRequest req = new RestRequest ("GET", _URL2, gameObject, new Hashtable());

				req.Send ();
				Debug.Log (req.responseCode);
				Debug.Log (req.responseText);
				DateTime endTime = DateTime.Now;
				Debug.Log("delta (end - start): " + endTime.Subtract(startTime));
			}
			*/

			/*
			for (int i = 0; i < 5; i++) {
				const String _URL3 = "localhost:3000/comments";
				DateTime startTime = DateTime.Now;
				RestRequest req = new RestRequest ("GET", _URL3, gameObject, new Hashtable ());

				req.Send ();
				Debug.Log (req.responseCode);
				Debug.Log (req.responseText);
				DateTime endTime = DateTime.Now;
				Debug.Log ("delta (end - start): " + endTime.Subtract (startTime));
			}
			*/


			for (int i = 0; i < 5; i++) {
				const String _URL3 = "localhost:3000/comments";
				DateTime startTime = DateTime.Now;
				const String _DATA = "{ \"id\": 1, \"body\": \"some comment\", \"postId\": 1 }";

				RestRequest req = new RestRequest ("POST", _URL3, gameObject, _DATA, new Hashtable ());

				req.Send ();
				Debug.Log (req.responseCode);
				Debug.Log (req.responseText);
				DateTime endTime = DateTime.Now;
				Debug.Log ("delta (end - start): " + endTime.Subtract (startTime));
			}


			// End of execution
			Application.Quit();	
		}

		// Update is called once per frame
		void Update () {
			Application.Quit();	
		}
	} //class
} //namespace
