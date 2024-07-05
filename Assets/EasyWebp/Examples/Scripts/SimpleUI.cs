using UnityEngine;
using UnityEngine.UI;

public class SimpleUI : MonoBehaviour
{
    public RawImage webpAnimation, webpImage;
    public string webpName = "UI_Animation_02";
    void Start()
    {
        //Load pictures in static webp format
        WebpImporter.LoadWebpTexture2D(PathExtensions.StreamingAssetsPath() + "/image01.webp", (texture) =>
        {
            webpImage.GetComponent<RawImage>().texture = texture;
        });


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
        if(webpAnimation!=null)
        {
            webpAnimation.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 180, 180);
            webpAnimation.GetComponent<RawImage>().texture = texture;
            //webpAnimation.GetComponent<RectTransform>().sizeDelta = new Vector2(texture.width, texture.height);
        }
    }
}