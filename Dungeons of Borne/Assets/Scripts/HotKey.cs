using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HotKey : MonoBehaviour
{

    [MenuItem("Tools/HotKey/SetActive  &2")]
    static void SetObjActive()
    {
        GameObject selectionObj = Selection.activeGameObject;

        selectionObj.SetActive(!selectionObj.activeSelf);
    }
}
