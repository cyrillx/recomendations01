using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _deltaVolume;

    private float _currentVolume;
    private float _targetVolume;

    public void FadeTo(float targetVolume)
    {
        _targetVolume = targetVolume;

        if (_alarmSound.isPlaying == false)
            _alarmSound.Play();

        _alarmSound.loop = true;
        StartCoroutine(FadeVolumeSmooth());
    }

    private IEnumerator FadeVolumeSmooth()
    {
        while(_currentVolume != _targetVolume)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _targetVolume, _deltaVolume);
            _alarmSound.volume = _currentVolume;
            yield return null;
        }

        if (_currentVolume == 0)
            _alarmSound.loop = false;
    }
}
