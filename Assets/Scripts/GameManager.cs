using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public SignalCenter SignalCenter { get; private set; }

    public PlayerHealth playerHealth;
    public PlayerCollision playerCollision;
    public HealthUI healthUI;
    public PlayerShake playerShake;
    public PlatformColorChanger platformColorChanger;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        SignalCenter = new SignalCenter();

        playerHealth.Inject(SignalCenter);
        playerCollision.Inject(SignalCenter);
        healthUI.Inject(SignalCenter);
        playerShake.Inject(SignalCenter);
        platformColorChanger.Inject(SignalCenter);


    }
}
