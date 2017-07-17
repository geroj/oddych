﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Oddych
{
	/// <summary>
	/// It performs simple test for retrieving data from web server using GET method
	/// </summary>
	public class DeleteMethod : MonoBehaviour
	{
		/*******************
		 * Initialization
		 * ****************/
		public DeleteMethod ()
		{
		}

		/********************
		 * Fields
		 * *****************/

		public UnityWebRequest Result;

		/********************
		 * Interface
		 * *****************/

		public void Start(){
		}

		/// <summary>
		/// Start getting data from specified url
		/// </summary>
		/// <param name="url">URL to server</param>
		public void Start(String url){
			StartCoroutine(Delete(url));
		}

		/*******************
		 * Implementation
		 * ****************/
		/// <summary>
		/// Deletes data from specified URL
		/// </summary>
		/// <returns>status if operation was executedsuccessfully.</returns>
		/// <param name="url">URL to server</param>
		IEnumerator Delete(String url){
			UnityWebRequest www = UnityWebRequest.Delete (url);
			Result = www;
			www.Send ();
			while (!www.isDone) {
				yield return null;
			}

			Hashtable ht = ProcessJsonData (www.downloadHandler.text);
			print ("sprava bola odoslana");
			//yield return www.Send ();

			if (www.isError) {
				print (www.error);
			} else {
				// Show results as text
				yield return www;


				// Or retrieve results as binary data
				byte[] results = www.downloadHandler.data;
			}
		}

		private Hashtable ProcessJsonData(String jsonDataResults){
			if (!jsonDataResults.Equals("")) {
				// TODO use instead
				//IList resultsIList = MiniJSON.Json.Deserialize (jsonDataResults) as IList;
				int length = jsonDataResults.Length;
				print ("return value length from JSON= " + length + " characters.");
				print ("metoda DELETE vratila " + jsonDataResults);
			}
			return new Hashtable ();
		}

		private Hashtable _DictToHashtable(Dictionary<string, object> dict) {
			var hashtable = new Hashtable();
			foreach (var pair in dict) {
				hashtable.Add(pair.Key, pair.Value);
			}
			return hashtable;
		}
	} //class
} //namespace
