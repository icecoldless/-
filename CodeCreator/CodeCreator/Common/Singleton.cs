namespace CodeCreator.Common
{
    public abstract class Singleton<T> where T:new()
    {
        static T _Instance;

        public static T Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new T();
                }
                return _Instance;
            }
        }
    }
}
