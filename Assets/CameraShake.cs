using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float IntervalMax = 0f;
    public float IntervalMin = 0f;
    public float Interval = 0f;
    public float Force = 0f;
    public float Duration = 0f;

    private void Start()
    {
        Interval = Random.Range(IntervalMin, IntervalMax);
    }

    private void Update()
    {
        if(Interval >= 0)
        {
            Interval -= Time.deltaTime;
        }
        else
        {
            Interval = Random.Range(IntervalMin, IntervalMax);
            StartCoroutine(Shake());
        }
    }

    public IEnumerator Shake()
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < Duration) {
            float x = Random.Range(-1f, 1f) * Force * 0.8f;
            float y = Random.Range(-1f, 1f) * Force * 1.2f;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
