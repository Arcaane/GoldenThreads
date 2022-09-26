using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

public static class Helpers
{
    private static Camera _camera;
    public static Camera Camera // Get main camera
    {
        get
        {
            if (_camera == null) _camera = Camera.main;
            return _camera;
        }
    }

    private static PointerEventData _eventDataCurrentPosition;
    public static List<RaycastResult> _results;

    public static bool IsOverUi() // Mouse is over UI elements ?
    {
        _eventDataCurrentPosition = new PointerEventData(EventSystem.current) {position = Input.mousePosition};
        _results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(_eventDataCurrentPosition, _results);
        return _results.Count > 0;
    }

    public static bool DetectRectTransform(RectTransform rT) // Is my mouse is on THIS (nn mais oui) rect ?
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(rT, Input.mousePosition))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static Vector2 GetWorldPositionOfCanvasElement(RectTransform element) // Find world point of canvas elements
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(element, element.position, Camera, out var result);
        return result;
    }

    public static void DeleteChilden(this Transform t) // Destroy all child objects
    {
        foreach (Transform child in t)Object.Destroy(child.gameObject);
    }
    
    public static int Add(int x, int y)
    {
        return x + y;
    }

    public static void ResetTransform(this Transform t) // Reset un transform
    {
        t.position = Vector3.zero;
        t.rotation = Quaternion.identity;
        t.localScale = Vector3.one;
    }

    public static void ShuffleArray<T>(this Random rng, T[] array)
    {
        int n = array.Length;
        while (n > 1) 
        {
            int k = rng.Next(n--);
            (array[n], array[k]) = (array[k], array[n]);
        }
    }
    
}