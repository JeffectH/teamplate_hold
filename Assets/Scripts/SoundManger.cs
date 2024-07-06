using UnityEngine;

public class SoundManger : MonoBehaviour
{
    [SerializeField] private AudioSource _soundTarget;
    [SerializeField] private AudioSource _soundStart;
    [SerializeField] private AudioSource _soundRegular;
    [SerializeField] private AudioSource _soundWin;
    [SerializeField] private AudioSource _soundLike;
    [Space]
    [SerializeField] private GameObject _soundUnMute;
    [SerializeField] private GameObject _soundMute;

    public AudioSource SoundRegular => _soundRegular;
    public AudioSource SoundStart => _soundStart;
    public AudioSource SoundTarget => _soundTarget;
    public AudioSource SoundWin => _soundWin;
    public AudioSource SoundLike => _soundLike;

    public void Mute()
    {
        _soundRegular.mute = !_soundRegular.mute;
        _soundStart.mute = !_soundStart.mute;
        _soundWin.mute = !_soundWin.mute;
        _soundLike.mute = !_soundLike.mute;
        _soundTarget.mute = !_soundTarget.mute;

        _soundUnMute.SetActive(!_soundUnMute.activeSelf);
        _soundMute.SetActive(!_soundMute.activeSelf);
    }
}
