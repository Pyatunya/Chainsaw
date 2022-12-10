using UnityEngine;

[RequireComponent(typeof(IPlayer))]
public abstract class PlayerChargingAttackInput : MonoBehaviour, IPlayerChargingAttackInput
{
    protected IPlayer Player { get; private set; }

    private void Start()
    {
        Player = GetComponent<IPlayer>();
    }

    public abstract bool IsCharging { get; }
    
}