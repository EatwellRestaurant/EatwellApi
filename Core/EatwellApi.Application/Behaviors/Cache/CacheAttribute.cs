namespace EatwellApi.Application.Behaviors.Cache
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class CacheAttribute : Attribute
    {
        public int Duration { get; }

        public CacheAttribute(int duration)
        {
            Duration = duration;
        }
    }
}
