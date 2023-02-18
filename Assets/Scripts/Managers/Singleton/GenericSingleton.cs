using UnityEngine;

namespace Herghys
{
    public class GenericSingleton<T> : MonoBehaviour where T : Component
    {
		public bool dontDestroy;
		private static T instance;
		public static T Instance
		{
			get
			{
				if (instance == null)
				{
					instance = FindObjectOfType<T>();
					if (instance == null)
					{
						GameObject obj = new GameObject();
						obj.name = typeof(T).Name;
						instance = obj.AddComponent<T>();
					}
				}
				return instance;
			}
		}

		public virtual void Awake()
		{
			OnAwake();
			if (instance == null)
			{
				instance = this as T;
				if (dontDestroy)
					DontDestroyOnLoad(this.gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
		}

		public virtual void OnAwake() { }
	}
}