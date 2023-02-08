using UnityEngine;

public class Monosingleton<T> : MonoBehaviour where T : Monosingleton<T>
{
    private static volatile T _instance = null;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;
            }

            return _instance;
        }
    }
}