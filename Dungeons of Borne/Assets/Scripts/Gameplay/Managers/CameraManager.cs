using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public static CameraManager _instance;
    private Vector3 fixedPos;

    private void Awake()
    {
        _instance = this;
    }
    /// <summary>
    /// 调整摄像机位置
    /// </summary>
    /// <param name="pos">摄像机移动的目标位置</param>
    public void AdjustCamera(Vector3 pos)
    {
        fixedPos = pos;
        StartCoroutine("CameraTranslate");
    }
    /// <summary>
    /// 摄像机移动至fixedPos 
    /// </summary>
    /// <returns></returns>
    public IEnumerator CameraTranslate()
    {
       // Debug.LogError("StartCoroutine");
        // Locate the camera's position to current room position.

        while (Vector3.Distance(transform.position, fixedPos) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, fixedPos, Time.deltaTime + 0.1f);

            yield return null;
        }
    }
}
