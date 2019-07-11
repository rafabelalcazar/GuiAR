using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeoMap : MonoBehaviour
{
    private string urlMap = "";

    public RawImage imageMap;
    public Text latitudText;
    public Text longitudText;
    public int zoom = 20;

    // Start is called before the first frame update
    void Start()
    {

        //imageMap = gameObject.GetComponent<RawImage>();
        StartCoroutine("GetMap");
    }

    public void ZoomInButton()
    {
        zoom++;
        StartCoroutine("GetMap");
    }

    public void ZoomOutButton()
    {
        if (zoom >= 0) zoom--;
        StartCoroutine("GetMap");
    }

    private IEnumerator GetMap()
    {
        Input.location.Start();

        //double latitud = 2.441857;
        //double longitud = -76.606201;

        float latitud = Input.location.lastData.latitude;
        yield return latitud;
        float longitud = Input.location.lastData.longitude;
        yield return longitud;

        urlMap = "http://maps.googleapis.com/maps/api/staticmap?center=" + latitud + "," + longitud + "&markers=color:red%7Clabel:S%" + latitud + "," + longitud + "&zoom=" + zoom + "&size=512x512" + "&maptype=hybrid&markers=color:red|label:L|" + latitud + "," + longitud + "&key=AIzaSyCxSSsHJKQt9cx9-BTsinTaeUKQOSjznwk" + "&type=hybrid&sensor=true?a.jpg";
        //urlMap = "http://maps.googleapis.com/maps/api/staticmap?center=2.441857,-76.606201&markers=color:red%7Clabel:S%2.441857,-76.606201&zoom=20&size=512x512&maptype=hybrid&markers=color:red|label:L|2.441857,-76.606201&key=AIzaSyCxSSsHJKQt9cx9-BTsinTaeUKQOSjznwk&type=hybrid&sensor=true?a.jpg";

        WWW www = new WWW(urlMap);
        yield return www;

        imageMap.texture = www.texture;
        latitudText.text = "" + latitud;
        longitudText.text = "" + longitud;
        imageMap.SetNativeSize();

    }

}
