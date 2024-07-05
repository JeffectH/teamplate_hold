using UnityEngine;
using UnityEngine.UI;

public class NewApi : MonoBehaviour
{
    public RawImage webpAnimation, webpImage;
    public string webpName = "UI_Animation_02";
    void Start()
    {
        //Load pictures in static webp format
        WebpImporter.LoadWebp(PathExtensions.StreamingAssetsPath() + "/image01.webp", (texture) =>
        {
            webpImage.GetComponent<RawImage>().texture = texture;
        });

 
        //Load the animated pictures in webp format
        string path = PathExtensions.StreamingAssetsPath() + "/" + webpName + ".webp";
#if UNITY_WEBGL
        StartCoroutine(WebpImporter.PlayWebpAnimationWebGL(path, WebpAnimationCallback));
#else
        WebpImporter.LoadWebp(path, WebpAnimationCallback);
#endif
    }

    void WebpAnimationCallback(Texture2D texture)
    {
        if (texture == null)
            return;
        //Up and down reverse pictures
        if(webpAnimation!=null)
        {
            webpAnimation.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 180, 180);
            webpAnimation.GetComponent<RawImage>().texture = texture;
        }
    }
}