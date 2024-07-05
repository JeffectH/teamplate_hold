using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UploadingImages : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private Image _gesture;
    [SerializeField] private Image _like;

    private void Uploading(Dictionary<string, string> dataString)
    {
       WebpImporter.LoadWebp(dataString["linkBackground"], (texture) =>
        {
            _background.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            _background.preserveAspect = true;
        });

        WebpImporter.LoadWebp(dataString["linkGesture"], (texture) =>
        {
            _gesture.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            _gesture.preserveAspect = true;
        });

        WebpImporter.LoadWebp(dataString["linkLike"], (texture) =>
        {
            _gesture.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            _gesture.preserveAspect = true;
        });
    }
}
