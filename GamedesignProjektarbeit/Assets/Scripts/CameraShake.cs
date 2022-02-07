using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // shakes camera

    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;      // remembers original position of camera

        float timeElapsed = 0f;                             // elapsed time since beginning of shake

        while (timeElapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            timeElapsed = timeElapsed + Time.fixedUnscaledDeltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }

}
