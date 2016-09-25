using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ScaleInOut : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public float speed = 0.5f;
    private bool startScale;
    private Vector3 initialScale;

	void Start () {
        initialScale = transform.localScale;
	}
	
    //  Check for boolean for every frame, if (true) => add scale, if (false) => remove scale
	void Update () {
        if (startScale)
            AddScale();
        else
            RemoveScale();
	}

    private void StartScale()
    {
        startScale = true;
    }
    private void StopScale()
    {
        startScale = false;
    }

    private void AddScale()
    {
        var newDim = transform.localScale.x < initialScale.x + 0.4f ? 0.01f : 0f;
        transform.localScale += new Vector3(newDim, newDim, newDim);
    }

    private void RemoveScale()
    {
        var newDim = transform.localScale.x > initialScale.x ? 0.01f : 0f;
        transform.localScale -= new Vector3(newDim, newDim, newDim);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartScale();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopScale();
    }
}
