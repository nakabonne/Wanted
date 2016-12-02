using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// イベントを実行するボタン作る
/// </summary>
[CustomEditor(typeof(EventInvoker))]
public class EventInvokerEditor :  Editor{

	public override void OnInspectorGUI(){
		DrawDefaultInspector ();
		EventInvoker eventInvoker = (EventInvoker)target;
		// ボタン作成
		if (GUILayout.Button ("InvokeEvent")) {
			eventInvoker.InvokeEvent ();
		}
	}
}
