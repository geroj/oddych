using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Oddych
{
	/// <summary>
	/// It performs simple test for retrieving data from web server using GET method
	/// </summary>
	public class GetMethod : MonoBehaviour
	{
		/*******************
		 * Initialization
		 * ****************/
		public GetMethod ()
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
			StartCoroutine(GetText(url));
		}

		public UnityWebRequest StartNew(String url){
			UnityWebRequest res = null;
			StartCoroutine (GetText(url, result => res = result));
			return res;
		}

		/*******************
		 * Implementation
		 * ****************/

		IEnumerator GetText(String url, Action<UnityWebRequest> result){
			if(String.IsNullOrEmpty(url)) { yield break; }
			UnityWebRequest www = UnityWebRequest.Get (url);
			www.Send ();
			yield return null;
			result(www);

			print (www.downloadHandler.isDone);
			if(string.IsNullOrEmpty(www.error) == false)
			{
				Debug.Log (url + " " + www.error);
				result(null);
				yield break;
			}
			//yield break;
		}


		/// <summary>
		/// Gets the text from specified url
		/// </summary>
		/// <returns>Data from weberver, or error</returns>
		/// <param name="url">URL to server</param>
		IEnumerator GetText(String url){
			UnityWebRequest www = UnityWebRequest.Get (url);
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
				print ("metoda GET vratila " + jsonDataResults);
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

