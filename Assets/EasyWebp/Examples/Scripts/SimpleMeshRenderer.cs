using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMeshRenderer : MonoBehaviour
{
    public string webpName = "City-01 c4dsky.com";
    void Start()
    {
        //Load the animated pictures in webp format
        string path = PathExtensions.StreamingAssetsPath() + "/" + webpName + ".webp";
#if UNITY_WEBGL
        StartCoroutine(WebpImporter.PlayWebpAnimationWebGL(path, WebpAnimationCallback));
#else
        WebpImporter.PlayWebpAnimation(path, WebpAnimationCallback);
#endif
    }

    void WebpAnimationCallback(Texture2D texture)
    {
        if (texture == null)
            return;
        try
        {
            GetComponent<MeshRenderer>().materials[0].mainTexture = texture;
            GetComponent<MeshRenderer>().materials[0].SetTexture("_EmissionMap", texture);
        }
        catch { }

    }
}
