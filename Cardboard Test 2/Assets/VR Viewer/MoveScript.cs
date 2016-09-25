using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Assets.Pictures;
using System.Linq;

public class MoveScript : MonoBehaviour//, IPointerClickHandler
{

    public float speed = 0.001f;
    private bool zoom;
    //private float prevy, prevz;
    //public GameObject nextGameObject;
    //private bool move;

    //private int GameObjectIndex;

    void Start()
    {
        //GameObjectIndex = StaticVars.Paintings.IndexOf(StaticVars.Paintings.FirstOrDefault(p => p.Equals(this)));
        //nextGameObject = GameObjectIndex < StaticVars.Paintings.Count - 1 ?
        //    GameObject.Find((GameObjectIndex + 1).ToString()) : null;
        //StaticVars.Paintings[GameObjectIndex + 1] : null;
        //if (nextGameObject != null) {
        //    prevy = transform.position.y;
        //    prevz = transform.position.z;
        //}
    }

    void Update()
    {
        if (zoom) {
            ZoomOut();
        }
        //if (move) {
            
            //MoveGameObjectToPreviousCenter();
            //TransformNext();
        //}
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

    //private void SetMoveActive()
    //{
    //    move = true;
    //}

    //private void TransformNext()
    //{
    //    if(StaticVars.Paintings != null && StaticVars.Paintings.Any()) {
    //        foreach(var painting in StaticVars.Paintings) {
    //            int i = StaticVars.Paintings.IndexOf(painting);
    //            if (i == StaticVars.Paintings.Count -1)
    //                continue;
    //            if (i <= GameObjectIndex)
    //                break;
    //            prevy = StaticVars.Paintings[i].transform.position.y;
    //            prevz = StaticVars.Paintings[i].transform.position.z;
    //            var newy = transform.position.y > prevy ? -1 * speed : 0;
    //            var newz = transform.position.z > prevz ? -1 * speed : 0;
    //            var v = new Vector3(0, newy, newz);
    //            if(newy == newz && newy == 0) {
    //                move = false;
    //                break;
    //            }
    //            StaticVars.Paintings[i + 1].transform.position += v;
    //        }
    //    }
    //}

    //private void MoveGameObjectToPreviousCenter()
    //{
    //    if (nextGameObject == null)
    //        return;
    //    var newy = nextGameObject.transform.position.y > prevy ? -1 * speed : 0;
    //    var newz = nextGameObject.transform.position.z > prevz ? -1 * speed : 0;
    //    var v = new Vector3(0, newy, newz);
    //    nextGameObject.transform.position += v;
    //}

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
        //SetMoveActive();
    }
}
