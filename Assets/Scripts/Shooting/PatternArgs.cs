﻿using UnityEngine;

public class PatternArgs
{
    public PatternTypes Type { get; set; }
    public float FireRate { get; set; }
    public Vector2 Direction { get; set; }
    public int ShotCount { get; set; }
    public int StageCount { get; set; } = 1;
}

public enum PatternTypes
{
    Single,
    Multishot,
    Spread,
    MikicHair,
    MikicSleep
}
