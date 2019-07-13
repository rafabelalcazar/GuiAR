using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class APIdemo : MonoBehaviour
{

    public InputField IfUrl;
    public  RawImage RImage;
    string url;
    string urlPart1;
    string urlPart2;



    public void Afficher()
    {

        StartCoroutine(GetImage());
    }

    IEnumerator GetImage()
{
		
		WWW www = new WWW (ConstructionUrl());
		yield return www;
		Texture texture = www.texture;
        RImage.texture = texture;
		

	}


    string ConstructionUrl()
    {
urlPart1="https://image.maps.cit.api.here.com/mia/1.6/mapview?app_id=eDUmrq3nL1Av1jbL2bFD&app_code=eP5qHAi5uvV14C0RYBKjbQ&ci=";
urlPart2="&h=300&w=600&z=16&f=0&ml=spa&style=flame";
return urlPart1 + IfUrl.text +urlPart2;
    }
}
