using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ZoomScript : MonoBehaviour, IPointerClickHandler {
    public float speed = 0.1f;
    private bool zoom = false;
    private Renderer render;

    void Start()
    {
        render = GetComponent<Renderer>();

        if (Application.platform != RuntimePlatform.Android)
            render.material.shader = Shader.Find("Transparent/Diffuse");
        Color c1 = GetComponent<Renderer>().material.color;
        c1.a = 1f;
        render.material.color = c1;
    }
    void Update()
    {
        if (zoom) {
            if (transform.position.z > -2) {
                ZoomOut();
                StartCoroutine(Fade());
            } else {
                gameObject.SetActive(false);
            }
        }
    }

    private void SetZoomActive()
    {
        zoom = true;
    }

    private void ZoomOut()
    {
        var newz = transform.position.z > -2 ? -1 * speed : 0;
        Vector3 movement = new Vector3(0, 0,newz);
        transform.position += movement;
    }

    IEnumerator Fade()
    {
        for (float f = 1f; f >= 0; f -= 0.05f) {
            Color c = GetComponent<Renderer>().material.color;
            c.a = f;
            render.material.color = c;
            yield return null;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SetZoomActive();
    }
}
