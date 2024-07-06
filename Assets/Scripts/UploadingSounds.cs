using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UploadingSounds : MonoBehaviour, IUploadingData
{
    [SerializeField] private AudioSource _soundStart;
    [SerializeField] private AudioSource _soundRegular;
    [SerializeField] private AudioSource _soundWin;
    [SerializeField] private AudioSource _soundLike;
    [SerializeField] private AudioSource _soundTarget;

    public void Initialize(Dictionary<string, string> soundData)
    {
        Uploading(soundData);
    }

    public void Uploading(Dictionary<string, string> soundData)
    {
        StartCoroutine(UploadSounds(soundData));
    }

    private IEnumerator UploadSounds(Dictionary<string, string> soundData)
    {
        foreach (var sound in soundData)
        {
            string key = sound.Key;
            string url = sound.Value;

            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.OGGVORBIS))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogError(www.error);
                }
                else
                {
                    AudioClip clip = DownloadHandlerAudioClip.GetContent(www);
                    AssignAudioClipToSource(key, clip);
                }
            }
        }
    }

    private void AssignAudioClipToSource(string key, AudioClip clip)
    {
        switch (key)
        {
            case "soundStart":
                _soundStart.clip = clip;
                break;
            case "soundRegular":
                _soundRegular.clip = clip;
                _soundRegular.Play();
                _soundRegular.loop = true;
                break;
            case "soundWin":
                _soundWin.clip = clip;
                break;
            case "soundLike":
                _soundLike.clip = clip;
                break;
            case "soundTarget":
                _soundTarget.clip = clip;
                break;
            default:
                Debug.LogWarning($"No AudioSource found for key: {key}");
                break;
        }
    }
}
