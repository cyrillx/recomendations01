using UnityEngine;

[RequireComponent(typeof(Alarm))]
public class Home : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _alarm.SetEnable(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _alarm.SetEnable(false);
    }
}
