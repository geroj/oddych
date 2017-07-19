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
	public class RestMethods : MonoBehaviour
	{
		/********************
		 * Fields
		 * *****************/
		public UnityWebRequest Result;

		/********************
		 * Interface
		 * *****************/
		/// <summary>
		/// Get the data from specified url.
		/// </summary>
		/// <param name="url">URL.</param>
		public String Get(String url){
			StartCoroutine (GetSpecialCoroutine (url));
			while (!Result.isDone) {
			}
			return Result.downloadHandler.text;
		}

		/// <summary>
		/// Post the data to specified url
		/// </summary>
		/// <param name="url">URL.</param>
		/// <param name="data">Data.</param>
		public String Post(String url, String data){
			StartCoroutine (PostSpecialCoroutine (url, data));
			while (!Result.isDone) {
			}
			return Result.downloadHandler.text;
		}

		/// <summary>
		/// Deletes the data from specified url.
		/// </summary>
		/// <param name="url">URL.</param>
		public long Delete(String url){
			StartCoroutine (DeleteSpecialCoroutine (url));
			while (!Result.isDone) {
			}
			return Result.responseCode;
		}

		/*******************
		 * Implementation
		 * ****************/
		/// <summary>
		/// Gets the result using special coroutine.
		/// </summary>
		/// <returns>UnityWebRequest with server response</returns>
		/// <param name="url">URL.</param>
		IEnumerator GetSpecialCoroutine(String url){
			Coroutine<UnityWebRequest> routine = this.StartCoroutine<UnityWebRequest>(GetCoroutine(url));
			yield return routine.coroutine; //Wait as we normally can
			Result = routine.Value;
		}

		/// <summary>
		/// Post data to specified url using special coroutine.
		/// </summary>
		/// <returns>UnityWebRequest with server response</returns>
		/// <param name="url">remote url</param>
		/// <param name="data">data to be send on server</param>
		IEnumerator PostSpecialCoroutine(String url, String data){
			Coroutine<UnityWebRequest> routine = this.StartCoroutine<UnityWebRequest>(PostCoroutine(url, data));
			yield return routine.coroutine; //Wait as we normally can
			Result = routine.Value;
		}

		/// <summary>
		/// Deletes resource specified by url using special coroutine.
		/// </summary>
		/// <returns>UnityWebRequest with server response</returns>
		/// <param name="url">URL.</param>
		IEnumerator DeleteSpecialCoroutine(String url){
			Coroutine<UnityWebRequest> routine = this.StartCoroutine<UnityWebRequest>(DeleteCoroutine(url));
			yield return routine.coroutine; //Wait as we normally can
			Result = routine.Value;
		}

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

		/// <summary>
		/// Post data to specified url
		/// </summary>
		/// <returns>return unitywebrequest</returns>
		/// <param name="url">remote url</param>
		/// <param name="data">data to be send on server</param>
		IEnumerator PostCoroutine(String url, String data){
			UnityWebRequest www = UnityWebRequest.Post (url, data);
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

		/// <summary>
		/// Deletes resource specified by url using special coroutine.
		/// </summary>
		/// <returns>UnityWebRequest with response from server</returns>
		/// <param name="url">URL to server</param>
		IEnumerator DeleteCoroutine(String url){
			UnityWebRequest www = UnityWebRequest.Delete (url);
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