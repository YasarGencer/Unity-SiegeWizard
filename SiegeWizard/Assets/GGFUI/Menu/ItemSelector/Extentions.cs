using System.Collections;
using UnityEngine;

public class StaticCoroutine : MonoBehaviour { }

public class Extentions : MonoBehaviour
{
    static IEnumerator _SetObjectPosition(Transform Object, Vector3 NewPosition, float Duration, bool DestroyObj)
    {
        float elapsedTime = 0;
        Vector3 startingPos = Object.localPosition;
        while (elapsedTime < Duration)
        {
            Object.localPosition = Vector3.Lerp(startingPos, NewPosition, (elapsedTime / Duration));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Object.localPosition = NewPosition;
        if (Object.GetComponent<StaticCoroutine>()) Destroy(Object.GetComponent<StaticCoroutine>());
        if (DestroyObj) Destroy(Object.gameObject);
    }
    public static void SetObjectPosition(Transform Object, Vector3 NewPosition, float Duration, bool DestroyObj = false)
    {
        StaticCoroutine coroutine = Object.gameObject.AddComponent<StaticCoroutine>();
        coroutine.StartCoroutine(_SetObjectPosition(Object.transform, NewPosition, Duration, DestroyObj));
    }

    static IEnumerator _SetObjectScale(Transform Object, Vector3 NewScale, float Duration, bool DestroyObj)
    {
        float elapsedTime = 0;
        Vector3 startingPos = Object.localScale;
        while (elapsedTime < Duration)
        {
            Object.localScale = Vector3.Lerp(startingPos, NewScale, (elapsedTime / Duration));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Object.transform.localScale = NewScale;

        if (Object.GetComponent<StaticCoroutine>()) Destroy(Object.GetComponent<StaticCoroutine>());
        if (DestroyObj) Destroy(Object.gameObject);
    }
    public static void SetObjectScale(GameObject Object, Vector3 NewScale, float Duration, bool DestroyObj = false)
    {
        StaticCoroutine coroutine = Object.gameObject.AddComponent<StaticCoroutine>();
        coroutine.StartCoroutine(_SetObjectScale(Object.transform, NewScale, Duration, DestroyObj));
    }
}
