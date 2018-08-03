using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util  {

    public static Vector2 CalcBezier(Vector2 p0, Vector2 p1, Vector2 p2, float t)
    {
        return new Vector2((1 - t) * (1 - t) * p0.x + 2 * (1 - t) * t * p1.x + t * t * p2.x,
                            (1 - t) * (1 - t) * p0.y + 2 * (1 - t) * t * p1.y + t * t * p2.y);
    }

    public static Vector3 MidAngle(Transform t1, Vector3 dir, float length)
    {
        return ((t1.position + t1.forward) + dir * length);
    }

    public static Vector3 RandAlongFlatCurve(Vector3 origin, float objY, float offset)
    {
        if (offset == 0) throw new System.Exception("Can't be offset by 0");

        if (offset < 0)
            return new Vector3(origin.x + Random.Range(offset, 0), objY, origin.z + Random.Range(offset, 0));

        return new Vector3(origin.x + Random.Range(0, offset), objY, origin.z + Random.Range(0, offset));
    }
}
