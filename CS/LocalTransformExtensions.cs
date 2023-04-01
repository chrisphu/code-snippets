using UnityEngine;

/// <summary>
/// Class <c>LocalTransformExtensions</c> contains easy calls for a transform's local vectors.
/// </summary>
/// <list>
/// <description>Properties such as <c>transform.right</c> return in world space. This creates problems if the transform's parent is rotated.</description>
/// </list>
public static class LocalTransformExtensions
{
    /// <summary>
    /// Static Vector3 <c>Localize</c> converts a given vector from world space to this transform's local space
    /// </summary>
    /// <description>Converting world space to local: <see href="https://answers.unity.com/questions/316918/local-forward.html"/></description>
    /// <param name="vector">Vector to convert from world space to local.</param>
    public static Vector3 Localize(this Transform transform, Vector3 vector)
    {
        return transform.worldToLocalMatrix.MultiplyVector(vector);
    }
    
    public static Vector3 LocalForward(this Transform transform)
    {
        return transform.Localize(transform.forward);
    }
    
    public static Vector3 LocalRight(this Transform transform)
    {
        return transform.Localize(transform.right);
    }
    
    public static Vector3 LocalUp(this Transform transform)
    {
        return transform.Localize(transform.up);
    }
    
    public static Vector3 LocalBack(this Transform transform)
    {
        return transform.Localize(-transform.forward);
    }
    
    public static Vector3 LocalLeft(this Transform transform)
    {
        return transform.Localize(-transform.right);
    }
    
    public static Vector3 LocalDown(this Transform transform)
    {
        return transform.Localize(-transform.up);
    }
}
