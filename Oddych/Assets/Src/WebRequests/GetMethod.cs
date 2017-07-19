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
		/********************
		 * Fields
		 * *****************/
		public UnityWebRequest Result;

		/********************
		 * Interface
		 * *****************/
		public String GetData(String url){
			StartCoroutine (GetSpecialCoroutine (url));
			while (!Result.isDone) {
			}
			return Result.downloadHandler.text;
		}

		IEnumerator GetSpecialCoroutine(String url){
			Coroutine<UnityWebRequest> routine = this.StartCoroutine<UnityWebRequest>(GetCoroutine(url)); //Start our new routine
			yield return routine.coroutine; //Wait as we normally can
			Result = routine.Value;
		}

		/*******************
		 * Implementation
		 * ****************/
		/// <summary>
		/// Gets the text from specified url
		/// </summary>
		/// <returns>Data from weberver, or error</returns>
		/// <param name="url">URL to server</param>
		IEnumerator GetCoroutine(String url){
			UnityWebRequest www = UnityWebRequest.Get (url);
			Result = www;
			www.Send ();
			while (!www.isDone) {
				yield return null;
			}

			if (www.isError) {
				print (www.error);
			} else {
				// Show results as text
				yield return www;
			}
		}
	} //class
} //namespace

