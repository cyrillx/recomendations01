using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Alarm))]
public class Home : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private float _fullVolume = 1f;
    private float _disabledVolume = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _alarm.FadeTo(_fullVolume);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _alarm.FadeTo(_disabledVolume);
    }
}
