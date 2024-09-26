using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{
    public Transform Target { get; private set; }
    public Vector3 InitialPosition { get; private set; }
    public Vector3 FinalPosition { get; private set; }
    public float StartTime { get; private set; }
    public float Duration { get; private set; }

    public Tween(Transform target, Vector3 InitialPosition, Vector3 FinalPosition, float startTime, float duration)
    {
        this.Target = target;
        this.InitialPosition = InitialPosition;
        this.FinalPosition = FinalPosition;
        this.StartTime = startTime;
        this.Duration = duration;
    }

}
