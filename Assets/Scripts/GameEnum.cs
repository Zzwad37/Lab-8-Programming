using System;

[Flags]
public enum EProjectileType
{
    None = 0,
    Bullet = 1 << 0, // 1
    Rocket = 1 << 1, // 2
    Laser = 1 << 2   // 4
}
