using UnityEngine;

public class Singleton<T> :
  MonoBehaviour where T : Component
{
  private static T _instance;
  public static T Instance
  {
    get
    {
      if (_instance == null)
      {
        _instance = FindObjectOfType<T>();

        if (_instance == null)
        {
          // Create a T.
          GameObject obj = new GameObject();
          obj.name = typeof(T).Name;
          _instance = obj.AddComponent<T>();
        }
      }

      return _instance;
    }
  }
    

  // Awake is called when we become active. Since it's virtural,
  // it must be declared public.
  public virtual void Awake()
  {
    if (_instance == null)
    {
      _instance = this as T;
      DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
    }
  }
}