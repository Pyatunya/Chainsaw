using System;
using UnityEngine;

public sealed class DashForceCalculator
{
    public float CalculateFrom(float chargingTime, float dashForce, float maxTimeForDashForce)
    {
        if (chargingTime <= 0) 
            throw new ArgumentOutOfRangeException(nameof(chargingTime));
        
        if (dashForce <= 0) 
            throw new ArgumentOutOfRangeException(nameof(dashForce));
        
        if (maxTimeForDashForce <= 0) 
            throw new ArgumentOutOfRangeException(nameof(maxTimeForDashForce));
        
        float dashForceCoefficient = Mathf.Min(chargingTime, maxTimeForDashForce) / maxTimeForDashForce;
        float deltaForce = dashForce * dashForceCoefficient;
        float result = deltaForce;
        return result;
    }
}