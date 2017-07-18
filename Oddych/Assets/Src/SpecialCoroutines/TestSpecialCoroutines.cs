using System;
using UnityEngine;
using System.Collections;

namespace Oddych
{
	/// Example of usage: (taken from https://www.youtube.com/watch?v=ciDD6Wl-Evk)
	public class Test1 : MonoBehaviour{
		public IEnumerator Start(){
			Coroutine<int> routine = this.StartCoroutine<int>(TestNewRoutine()); //Start our new routine
		 	yield return routine.coroutine; //Wait as we normally can
			Debug.Log(routine.Value); //print the result now that it is finished.
		}
		 
		IEnumerator TestNewRoutine(){
			yield return null;
			yield return new WaitForSeconds(2f);
			yield return 10;
		}
	} //class

	/// Another example of usage: (Exception) (taken from https://www.youtube.com/watch?v=ciDD6Wl-Evk)
	public class Test2 : MonoBehaviour{
		public IEnumerator Start(){
			var routine = this.StartCoroutine<int>(TestNewRoutineGivesException());
			yield return routine.coroutine;
			try{
				Debug.Log(routine.Value);
			}
			catch(Exception e){
				Debug.Log(e.Message);
		 		// do something
				Debug.Break();
			}
		}

		IEnumerator TestNewRoutineGivesException(){
			yield return null;
			yield return new WaitForSeconds(2f);
			throw new Exception ("Bad thing!");
		}
	} //class

	/// Another example of usage: (Cancellation) (taken from https://www.youtube.com/watch?v=ciDD6Wl-Evk)
	public class Test3 : MonoBehaviour{
		public IEnumerator Start(){
			var routine = this.StartCoroutine<int>(TestNewRoutineCancellation());
		 	yield return new WaitForSeconds(1.5f);
			routine.Cancel();
		 
		 	try{
				Debug.Log(routine.Value);
			}
			catch(CoroutineCancelledException e){
				//Deal with cancelled coroutine
				Debug.Log(e);
			}
			catch(Exception e){
				Debug.Log(e.Message);
				Debug.Break();
			}
		} //class

		IEnumerator TestNewRoutineCancellation(){
			yield return null;
			yield return new WaitForSeconds(3f);
			yield return 1;
		}
	} //class
} //namespace