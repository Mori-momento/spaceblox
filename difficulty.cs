using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class difficulty 
{
    static float secToMaxDifficulty = 10f;

    public static float GetDifficultyPercent()
    {
       return Mathf.Clamp01(Time.timeSinceLevelLoad / secToMaxDifficulty);
    }
        
}
