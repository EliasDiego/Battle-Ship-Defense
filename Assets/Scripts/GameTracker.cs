using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTracker
{
    public static int Wave = 0;
    public static int Health = 100;
    public static int SwarmMissileDestroyed = 0;
    public static int ReflectorMissileDestroyed = 0;
    public static int HeavyMissileDestroyed = 0;
    public static float TimeLeft = 10;


    public static void Reset()
    {
        Wave = 0;
        Health = 100;
        SwarmMissileDestroyed = 0;
        ReflectorMissileDestroyed = 0;
        HeavyMissileDestroyed = 0;
        TimeLeft = 10;
    }
}
