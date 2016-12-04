/*
 * NKDebugLog.cs
 * 
 * Copyright (c) 2016 by nanoka All rights reserved.
 * Created by nanoka on 2016/11/08.
 * 
 * Qiita  �Fhttp://qiita.com/nanokanato
 * Twitter�Fhttps://twitter.com/nanokanato
 * 
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NKDebugLog : MonoBehaviour {

    public Vector2 guiScreenSize = new Vector2(720, 720);
    public bool DebugMode = true;

    private List<string> conditions = new List<string>();
    private List<LogType> logTypes = new List<LogType>();

    /*-----------------------*
     * Default Method
     *-----------------------*/
    //Debug.Log���擾���邽�߂�Handler�o�^
    void Awake () 
    {
        if (DebugMode) {
            Application.logMessageReceived += LogCallBackHandler; 
        }
    }

    //NKDebugLog��\�����邽�߂�Window��\��
    void OnGUI() {
        if (DebugMode) {
            GUIUtility.ScaleAroundPivot (new Vector2 (Screen.width / guiScreenSize.x, Screen.height / guiScreenSize.y), Vector2.zero);
            GUI.ModalWindow (7, new Rect (guiScreenSize.x * 0.1f, guiScreenSize.y * 0.1f, guiScreenSize.x * 0.8f, guiScreenSize.y * 0.8f), modalWindowFunction, "NKDebugLog");
            GUI.matrix = Matrix4x4.identity;
        }
    }

    //NKDebugLog��Window�����C�A�E�g
    private void modalWindowFunction(int id){
        if (DebugMode) {
            if (id == 7) {
                //LogType.Log�̎���Style
                GUIStyleState logState = new GUIStyleState ();
                logState.textColor = new Color (255, 255, 255, 255);
                GUIStyle logStyle = new GUIStyle ();
                logStyle.fontSize = 20;
                logStyle.normal = logState;

                //LogType.Error�̎���Style
                GUIStyleState errorState = new GUIStyleState ();
                errorState.textColor = new Color (255, 0, 0, 255);
                GUIStyle errorStyle = new GUIStyle ();
                errorStyle.fontSize = 20;
                errorStyle.normal = errorState;

                //Log��ۑ��������\������
                string[] conditionArray = conditions.ToArray ();
                LogType[] logTypeArray = logTypes.ToArray ();
                for (int i = conditionArray.Length - 1; i > 0; i--) {
                    string condition = conditionArray [i];
                    LogType logType = LogType.Log;
                    if (i < logTypeArray.Length) {
                        logType = logTypeArray [i];
                    }
                    if (logType == LogType.Error) {
                        GUI.Label (new Rect (30, (conditionArray.Length - i) * 30, 300, 30), condition, errorStyle);
                    } else {
                        GUI.Label (new Rect (30, (conditionArray.Length - i) * 30, 300, 30), condition, logStyle);
                    }
                }
            }
        }
    }

    /*-----------------------*
     * Application Method
     *-----------------------*/
    //Debug.Log�̏���ۑ�����
    void LogCallBackHandler(string condition, string stackTrace, LogType type)
    {
        if (DebugMode) {
            // �擾�������O�̏�����������
            conditions.Add (condition);
            logTypes.Add (type);
        }
    }
}