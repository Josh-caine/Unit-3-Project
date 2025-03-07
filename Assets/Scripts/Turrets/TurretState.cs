using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public abstract class TurretState
{
    protected TurretController turret;

    public TurretState(TurretController turret)
    {
        this.turret = turret;
    }

    public abstract void OnStateEnter();

    public abstract void OnStateUpdate();

    public abstract void OnStateExit();
}
