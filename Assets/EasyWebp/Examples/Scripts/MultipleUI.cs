using UnityEngine;
using UnityEngine.UI;

public class MultipleUI : MonoBehaviour
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
        //Up and down reverse pictures
        try
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 180, 180);
            GetComponent<RawImage>().texture = texture;
            //webpAnimation.GetComponent<RectTransform>().sizeDelta = new Vector2(texture.width, texture.height);
        }
        catch { }
    }
}