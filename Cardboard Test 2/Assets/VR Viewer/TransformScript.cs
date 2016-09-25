using UnityEngine;
using System.Collections;
using Assets.Pictures;
using System.Linq;
using UnityEngine.EventSystems;
using System;

public class TransformScript : MonoBehaviour, IPointerClickHandler
{
    private float speed = 0.01f;
    //private float prevy, prevz;
    private bool move, previousSet;
    private int GameObjectIndex;

    private float[] prevYtable, prevZtable;

    void Start()
    {
    }
    void Update()
    {
        if (StaticVars.PaintingsUploaded.All(p => p)) {
            if (!move) {
                prevYtable = StaticVars.Paintings.Select(p => p.transform.position.y).ToArray();
                prevZtable = StaticVars.Paintings.Select(p => p.transform.position.z).ToArray();
            }
            if (!previousSet && StaticVars.Paintings != null && StaticVars.Paintings.Any()) {
                GameObjectIndex = int.Parse(this.name);
                if (GameObjectIndex >= 0) {
                    previousSet = true;
                }
            }
        }
        if (move && previousSet) {
            MoveImageToCenter();
        }
    }

    public void SetMoveActive()
    {
        move = true;
    }

    private void MoveImageToCenter()
    {
        for (int i = GameObjectIndex + 1; i < StaticVars.Paintings.Count; ++i) {
            GameObject nextGameObject = StaticVars.Paintings[i];
            var newy = nextGameObject.transform.position.y > prevYtable[i - 1] ? -1 * speed : 0;
            var newz = nextGameObject.transform.position.z > prevZtable[i - 1] ? -1 * speed : 0;
            var v = new Vector3(0, newy, newz);
            nextGameObject.transform.position += v;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SetMoveActive();
    }
}