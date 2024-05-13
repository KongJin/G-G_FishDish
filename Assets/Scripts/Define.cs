using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define 
{
    public enum FishType
    {
        GOLD,
        NEON,
        CORI,
        SWORD,
        MAX
    }
    public enum LayerType
    {
        Indegenous=6,
        Player
    }
    public static readonly int screenWide = 360;
    public static readonly int screenHeight = 640;

    public static readonly float minFloat = 0.1f;
    public static readonly int space = 50;

    

}
