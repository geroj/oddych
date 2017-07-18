using UnityEngine;
using System;
using System.Collections;

namespace Oddych
{
	/// <summary>
	/// It extends MonoBehaviour class with method to start generic coroutine with type T.
	/// 
	/// Example of usage: (taken from https://www.youtube.com/watch?v=ciDD6Wl-Evk)
	/// 
	/// IEnumerator Start(){
	/// 	var routine = StartCoroutine<int>(TestNewRoutine()); //Start our new routine
	/// 	yield return routine.coroutine; //Wait as we normally can
	/// 	Debug.Log(routine.returnVal) //print the result now that it is finished.
	/// }
	/// 
	/// IEnumerator TestNewRoutine(){
	/// 	yield return null;
	/// 	yield return new WaitForSeconds(2f);
	/// 	yield return 10;
	/// }
	/// 
	/// Another example of usage: (Exception) (taken from https://www.youtube.com/watch?v=ciDD6Wl-Evk)
	/// 
	/// IEnumerator Stat(){
	/// 	var routine = StartCoroutine<int>(TestNewRoutineGivesException());
	/// 	yield return routine.coroutine;
	/// 	try{
	/// 		Debug.Log(routine.Value);
	/// 	}
	/// 	catch(Exception e){
	/// 		Debug.Log(e.Message);
	/// 		// do something
	/// 		Debug.Break();
	/// 	}
	/// }
	/// 
	/// IEnumerator TestNewRoutineGivesException(){
	/// 	yield return null;
	/// 	yield return new WaitForSeconds(2f);
	/// 	throw new Exception ("Bad thing!");
	/// }
	/// 
	/// Another example of usage: (Cancellation) (taken from https://www.youtube.com/watch?v=ciDD6Wl-Evk)
	/// 
	/// IEnumerator Start(){
	/// 	var routine = StartCoroutine<int>(TestNewRoutineCancellation());
	/// 	yield return new WaitForSeconds(1.5f);
	/// 	routine.Cancel();
	/// 
	/// 	try{
	/// 		Debug.Log(routine.Value);
	/// 	}
	/// 	catch(CoroutineCancelledException e){
	/// 		//Deal with cancelled coroutine
	/// 	}
	/// 	catch(Exception e){
	/// 		Debug.Log(e.Message);
	/// 		Debug,Break();
	/// 	}
	/// }
	/// 
	/// IEnumerator TestNewRoutineCancellation(){
	/// 	yield return null;
	/// 	yield return new WaitForSeconds(3f);
	/// 	yield return 1;
	/// }
	/// </summary>
	public static class MonoBehaviorExt{
		public static Coroutine<T> StartCoroutine<T>(this MonoBehaviour obj, IEnumerator coroutine){
			Coroutine<T> coroutineObject = new Coroutine<T>();
			coroutineObject.coroutine = obj.StartCoroutine(coroutineObject.InternalRoutine(coroutine));
			return coroutineObject;
		}

		public static IEnumerator OverTime(
			this MonoBehaviour obj,
			float time, 
			Func<float, float> f,
			Action<float> action){

			float startTime = Time.time;
			while(Time.time - startTime < time){
				float u = f((Time.time - startTime)/time);
				action(u);
				yield return null;
			}
			action(f(1));
			yield break;
		}
	} //static class

	/// <summary>
	/// Wrapper class around coroutines in Unity for error retrieving results, error handling and early cancellation
	/// It is generic where T is expected return type.
	/// Idea: Sit between the IEnumerator and StartCoroutine and
	///       look at values as they come out
	/// </summary>
	public class Coroutine<T>{
		/// <summary>
		/// Gets the result of execution. It throws stored exception when exception occured.
		/// </summary>
		/// <value>The value.</value>
		public T Value {
			get{
				if(e != null){
					throw e;
				}
				return returnVal;
			}
		}

		/// <summary>
		/// Cancels execution of coroutine.
		/// </summary>
		public void Cancel(){
			isCancelled = true;	
		}

		private bool isCancelled = false;
		private T returnVal;
		// Catches exception if it occures. It stores it and break the coroutine
		private Exception e;
		public Coroutine coroutine;

		/// <summary>
		/// Encapsulates execution of coroutine form parameter.
		/// It looks at values as they are yielded from coroutine.
		/// </summary>
		/// <returns>IEnumerator of coroutine</returns>
		/// <exception cref="CoroutineCancelledException">Throws at cancellation</exception>
		//
		/// <param name="coroutine">Coroutine to be executed</param>
		public IEnumerator InternalRoutine(IEnumerator coroutine){
			while(true){
				// throw excpetion on cancellation
				if(isCancelled){
					e = new CoroutineCancelledException();
					yield break;
				}
				try{
					if(!coroutine.MoveNext()){
						yield break;
					}
				}
				catch(Exception e){
					this.e = e;
					yield break;
				}
				object yielded = coroutine.Current;



				// Support nested special Coroutines by returning the underlying
				// system coroutine so that Unity will recognise it and process it.
				// Otherwise we will continue executing on the next frame.
				if (yielded is Coroutine<T>) {
					yield return (yielded as Coroutine<T>).coroutine;
				} else {
					// If descendant of T end the routine and expose the vlaue
					if(yielded != null && yielded is T){
						returnVal = (T)yielded;
						yield break;
					}
					else{
						yield return coroutine.Current;
					}
				}
			}
		}
	} //class

	/// <summary>
	/// Coroutine cancelled exception.
	/// </summary>
	public class CoroutineCancelledException: System.Exception{
		public CoroutineCancelledException():base("Coroutine was cancelled"){
		}
	} //class
} //namespace