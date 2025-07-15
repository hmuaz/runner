using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public SignalCenter SignalCenter { get; private set; }
    public SignalCenter ShakeSignalCenter { get; private set; }
    

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
        ShakeSignalCenter = new SignalCenter();

        playerHealth.Inject(SignalCenter);
        healthUI.Inject(SignalCenter);
        platformColorChanger.Inject(SignalCenter);
        playerShake.Inject(SignalCenter);
        playerCollision.Inject(SignalCenter);
        
        //playerShake.Inject(ShakeSignalCenter);
        //playerCollision.Inject(ShakeSignalCenter);
        
        


    }
}
