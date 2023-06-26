using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _deltaVolume;

    private float _currentVolume;
    private float _targetVolume;
    private float _fullVolume = 1f;
    private float _disabledVolume = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FadeTo(_fullVolume);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FadeTo(_disabledVolume);
    }

    private void FadeTo(float targetVolume)
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
