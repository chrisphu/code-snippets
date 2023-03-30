using UnityEngine;

/// <summary>
/// "Local" vectors such as transform.right are given in world space. <c>LocalTransformExtensions</c> allows for an easy way to call their local versions.
/// </summary>
public static class LocalTransformExtensions
{
    /// <summary>
    /// <c>Localize</c> converts a given vector from world space to this transform's local space
    /// </summary>
    /// <description>Converting world space to local: https://answers.unity.com/questions/316918/local-forward.html</description>
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
