using UnityEngine;

public static class WorldExtension
{
    // Convert a screen space coordinate and return a Vector2 for 2D.
    public static Vector2 GetScreenPositonIn2D(this Vector3 screenCoordinate)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(screenCoordinate);
        return new Vector2(wp.x, wp.y);
    }

    // Convert a screen space cordinate and return a Vector3 with a zero z value for 2D.
    public static Vector3 GetScreenPositionFor2D(this Vector3 screenCoordionate)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(screenCoordionate);
        return wp.ToVector3_2D();
    }

    // Convert any Vector3 in to a 2D Vector3 with a zero z value.
    public static Vector3 ToVector3_2D(this Vector3 coordinate)
    {
        return new Vector3(coordinate.x, coordinate.y, 0);
    }
}

//P.S 
//var clickPoint = WorldExtension.GetScreenPositionFor2D(Input.mousePosition);
// Два возможных вызова этих методов.
//var clickPoint = Input.mousePosition.GetScreenPositionFor2D();
