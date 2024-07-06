using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UploadingImages : MonoBehaviour, IUploadingData
{
    [SerializeField] private Image _background;
    [SerializeField] private Image _gesture;
    [SerializeField] private Image _gestureTarget;
    [SerializeField] private Image _like1;
    [SerializeField] private Image _like2;
    [SerializeField] private Image _like3;

    public void Initialize(Dictionary<string, string> dataString)
    {
        Uploading(dataString);
    }

    public void Uploading(Dictionary<string, string> dataString)
    {
        LoadAndAssignImage(dataString, "linkLike", _like1);
        LoadAndAssignImage(dataString, "linkLike", _like2);
        LoadAndAssignImage(dataString, "linkLike", _like3);
        LoadAndAssignImage(dataString, "linkBackground", _background);
        LoadAndAssignImage(dataString, "linkGesture", _gesture);
        LoadAndAssignImage(dataString, "linkGesture", _gestureTarget);
    }

    private void LoadAndAssignImage(Dictionary<string, string> dataString, string linkKey, Image image)
    {
        if (dataString.TryGetValue(linkKey, out string link))
        {
            WebpImporter.LoadWebp(link, (texture) =>
            {
                image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                image.preserveAspect = true;
            });
        }
        else
        {
            Debug.LogError($"Link '{linkKey}' not found in data.");
        }
    }
}
