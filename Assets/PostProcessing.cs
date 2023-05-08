using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessing : MonoBehaviour
{
    private Volume volume;
    
    private Vignette vignette;

    private void Awake()
    {
        volume = GetComponent<Volume>();
    }
    
    void Start()
    {
        volume.profile.TryGet(out vignette);

        vignette.active = true;
        vignette.intensity.value = 0.5f;
        vignette.color.value = Color.yellow;

        StartCoroutine(Deactive());
    }

    private IEnumerator Deactive()
    {
        yield return new WaitForSeconds(3);
        vignette.intensity.value = 1f;
        vignette.color.value = Color.red;
        
        yield return new WaitForSeconds(2);
        vignette.active = false;

    }
}
