using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _deltaVolume;

    private Coroutine _fadeCoroutine;
    private float _currentVolume;
    private float _targetVolume;
    private float _fullVolume = 1f;
    private float _disabledVolume = 0f;

    public void SetEnable(bool newState)
    {
        if (newState == true)
            FadeTo(_fullVolume);
        else
            FadeTo(_disabledVolume);
    }

    private void FadeTo(float targetVolume)
    {
        if(_fadeCoroutine != null)
            StopCoroutine(_fadeCoroutine);

        _targetVolume = targetVolume;

        if (_alarmSound.isPlaying == false)
            _alarmSound.Play();

        _alarmSound.loop = true;
        _fadeCoroutine = StartCoroutine(FadeVolumeSmooth());
    }

    private void Start()
    {
        _fadeCoroutine = null;
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
