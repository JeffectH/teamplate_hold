using System;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public event Action DownloadComplete;

    [SerializeField] private WebManager _webManager;
    [SerializeField] private DataParser _dataParser;
    [SerializeField] private UploadingImages _uploadingImages;
    [SerializeField] private UploadingSounds _uploadingSounds;
    [SerializeField] private UploadingTexts _uploadingTexts;

    private void OnEnable()
    {
        _webManager.DataReceived += UploadData;
    }

    private void OnDisable()
    {
        _webManager.DataReceived -= UploadData;
    }

    private void Awake()
    {
        _webManager.Initialize();
    }

    private void UploadData() 
    {
        _dataParser.Initialize(_webManager.Data);
        Debug.Log(_webManager.Data);
        _uploadingTexts.Initialize(_dataParser.TextData);
        _uploadingImages.Initialize(_dataParser.ImageData);
        _uploadingSounds.Initialize(_dataParser.SoundData);

        DownloadComplete?.Invoke();
    }
}
