using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util  {
    public static Vector3 MidAngle(Transform t1, Vector3 _right, float yValue, float length)
    {
        float xValue = t1.position.x + t1.forward.x;
        float zValue = t1.position.z + t1.forward.z;

        return (new Vector3(xValue, yValue, zValue) + _right * length);
    }

    public static Vector3 RandAlongFlatCurve(Vector3 origin, float objY, float offset)
    {
        if (offset == 0) throw new System.Exception("Can't be offset by 0");

        if (offset < 0)
            return new Vector3(origin.x + Random.Range(offset, 0), objY, origin.z + Random.Range(offset, 0));

        return new Vector3(origin.x + Random.Range(0, offset), objY, origin.z + Random.Range(0, offset));
    }
}
