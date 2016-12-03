using UnityEngine;
using System.Collections;
using UnityEngine.Events;

/// <summary>
/// イベント登録，実行
/// </summary>
public class EventInvoker : MonoBehaviour {

	// イベント登録
	[SerializeField]
	private UnityEvent events = new UnityEvent ();

	// イベント実行
	public void InvokeEvent(){
		events.Invoke ();
	}
}
