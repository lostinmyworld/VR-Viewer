using UnityEngine;
using System.Collections;
using Assets.Pictures;
using System.Collections.Generic;
using System.Linq;

public class ImageControllerScript : MonoBehaviour {

    public List<string> ImageUrls;
    Vector3 transformVector;
    float newy, newz;

    public GameObject paintingPreFab;

	// Use this for initialization
	void Start () {
        StaticVars.Paintings = new List<GameObject>();
        transformVector = new Vector3(paintingPreFab.transform.position.x, paintingPreFab.transform.position.y, paintingPreFab.transform.position.z);

        if (ImageUrls != null && ImageUrls.Any()) {
            StaticVars.PaintingsUploaded = Enumerable.Repeat(false, ImageUrls.Count).ToList();
            foreach(var url in ImageUrls) {
                StartCoroutine(GetImageFromUrl(url));
            }
        } else {
            StaticVars.PaintingsUploaded = new List<bool>() { false, false, false };
            StartCoroutine(GetImageFromUrl("https://upload.wikimedia.org/wikipedia/en/7/74/PicassoGuernica.jpg"));
            StartCoroutine(GetImageFromUrl("https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Van_Gogh_-_Starry_Night_-_Google_Art_Project.jpg/1280px-Van_Gogh_-_Starry_Night_-_Google_Art_Project.jpg"));
            StartCoroutine(GetImageFromUrl("http://www4.pictures.zimbio.com/mp/zgWFptmpEKSl.jpg"));
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Loads an image from the url and start the painting placement
    /// </summary>
    public IEnumerator GetImageFromUrl(string imagePath)
    {
        yield return 0;
        WWW imageLink = new WWW(imagePath);
        yield return imageLink;
        GameObject painting = Instantiate(paintingPreFab) as GameObject;
        if (StaticVars.Paintings!= null && StaticVars.Paintings.Any()) {
            newy = StaticVars.Paintings.Last().transform.position.y + 2.0f;
            newz = StaticVars.Paintings.Last().transform.position.z + 1.0f;
            transformVector.y = newy;
            transformVector.z = newz;
        }
        painting.name = StaticVars.Paintings.Count.ToString();
        painting.transform.parent = this.transform;
        painting.transform.position = transformVector;
        painting.GetComponent<Renderer>().material.mainTexture = imageLink.texture;
        StaticVars.Paintings.Add(painting);
        StaticVars.PaintingsUploaded[StaticVars.Paintings.IndexOf(painting)] = true;
    }
}