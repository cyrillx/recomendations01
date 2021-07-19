using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _deltaVolume;
    [SerializeField] private AudioSource _alarmSound;

    private float _currentVolume = 0;
    private float _targetVolume;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartFading(1f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartFading(0f);
    }

    private void StartFading(float targetVolume)
    {
        _targetVolume = targetVolume;
        if(_alarmSound.isPlaying == false)
            _alarmSound.Play();
        _alarmSound.loop = true;
        StartCoroutine(SmoothFade());
    }

    private IEnumerator SmoothFade()
    {
        while(_currentVolume != _targetVolume)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _targetVolume, _deltaVolume);
            _alarmSound.volume = _currentVolume;
            yield return null;
        }
        if(_currentVolume == 0)
            _alarmSound.loop = false;
    }
}
