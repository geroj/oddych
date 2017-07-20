using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Collections;

namespace Oddych
{
	/// <summary>
	/// Encapsulates REST methods
	/// </summary>
	public class RestRequest
	{
		/******************************
		 * Private Fields
		 * ***************************/

		private string _method;
		private string _url;
		private Hashtable _parameters;
		private String _data;
		private RestMethods _restMethods;

		/*******************************
		 * Public Fields
		 * ****************************/

		public UnityWebRequest unityWebRequest;
		public string responseText;
		public int responseCode;

		/*******************************
		 * Initialization
		 * ****************************/

		/// <summary>
		/// Empty constructor
		/// </summary>
		public RestRequest(){
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Oddych.RestRequest"/> class with parameters for authentication
		/// </summary>
		/// <param name="method">POST, DELETE or UPDATE</param>
		/// <param name="url">URL.</param>
		/// <param name="parameters">Parameters for authentication</param>
		/// <param name="gameObject">Game object</param>
		public RestRequest (String method, String url, GameObject gameObject, Hashtable parameters)
		{
			_method = method;
			_url = url;
			_parameters = parameters;
			_restMethods = gameObject.AddComponent<RestMethods> ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Oddych.RestRequest"/> class with data to be sent to server
		/// </summary>
		/// <param name="method">POST, DELETE or UPDATE</param>
		/// <param name="url">URL.</param>
		/// <param name="gameObject">Game object</param>
		/// <param name="data">Data to be send to server</param>
		/// <param name="parameters">parameters for autentication</param>
		public RestRequest (String method, String url, GameObject gameObject, String data, Hashtable parameters = null)
		{
			_method = method;
			_url = url;
			_data = data;
			_parameters = parameters;
			_restMethods = gameObject.AddComponent<RestMethods> ();
		}


		/********************************
		 * Interface
		 * *****************************/
		public void Send(Action<RestRequest> callback = null){
			if (callback == null) {
				this.Execute ();
			} else {
				callback = (request) => request.Execute ();
			}
		}

		/********************************
		 * Implementation
		 * *****************************/
		private void Execute(){
			UnityWebRequest response;
			switch (_method) {
			case "GET":
				response = _restMethods.Get (_url);
				responseText = response.downloadHandler.text;
				responseCode = (int) response.responseCode;
				break;
			case "POST":
				// Data is already serialized
				// JSON.JSONObject jsonObj = new JSON.JSONObject ();
				// JSON.JSONSerialize.Serialize ((object) _data, jsonObj);
				// String json = jsonObj.ToString ();
				response = _restMethods.Post (_url, _data);
				responseText = response.downloadHandler.text;
				responseCode = (int) response.responseCode;
				break;
			case "DELETE":
				response = _restMethods.Delete (_url);
				responseText = response.downloadHandler.text;
				responseCode = (int) response.responseCode;
				break;
			default: 
				responseCode = 404;
				throw new Exception ("Not supported method");
			}
		}
	} //class
} //namespace