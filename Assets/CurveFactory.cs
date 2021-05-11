using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurveFactory
{
    public static AnimationCurve Create(float startValue, float endValue)
    {
        var curve = new AnimationCurve();
        curve.AddKey(0f, startValue);
        curve.AddKey(2f, endValue);

        return curve;
    }

}
