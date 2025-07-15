using UnityEngine;

public class PlatformColorChanger : MonoBehaviour
{
    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        GameEvents.OnPlayerHit += ChangeColor;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerHit -= ChangeColor;
    }

    private void ChangeColor()
    {
        rend.material.color = Random.ColorHSV();
    }
}
