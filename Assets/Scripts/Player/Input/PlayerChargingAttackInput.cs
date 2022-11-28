using UnityEngine;

[RequireComponent(typeof(Player))]
public abstract class PlayerChargingAttackInput : MonoBehaviour
{
    protected Player Player { get; private set; }

    private void Start()
    {
        Player = GetComponent<Player>();
    }

    public abstract bool IsCharging { get; }
    
}