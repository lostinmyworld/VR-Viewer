using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Assets.Pictures;
using System.Linq;

public class MoveScript : MonoBehaviour//, IPointerClickHandler
{

    public float speed = 0.001f;
    private bool zoom;

    void Update()
    {
        if (zoom) {
            ZoomOut();
        }
    }

    private void SetZoomActive()
    {
        zoom = true;
    }

    private void ZoomOut()
    {
        var newz = transform.position.z > -20 ? -1 * speed : 0;
        Vector3 movement = new Vector3(0, 0, newz);
        transform.position += movement;

        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        for (float f = 1f; f >= 0; f -= 0.1f) {
            Color c = GetComponent<Renderer>().material.color;
            c.a = f;
            GetComponent<Renderer>().material.color = c;
            yield return null;
        }
        GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Diffuse");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SetZoomActive();
    }
}
