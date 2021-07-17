using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _penetration;
    [SerializeField] private float _deltaVolume;
    [SerializeField] private AudioSource _alarmSound;

    private float _currentVolume = 0;
    private float _targetVolume;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _targetVolume = 1f;
        _alarmSound.Play();
        _alarmSound.loop = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _targetVolume = 0f;
    }

    private void Update()
    {
        _currentVolume = Mathf.MoveTowards(_currentVolume, _targetVolume, _deltaVolume);
        _alarmSound.volume = _currentVolume;
        if (_currentVolume == 0)
            _alarmSound.loop = false;
    }
}
