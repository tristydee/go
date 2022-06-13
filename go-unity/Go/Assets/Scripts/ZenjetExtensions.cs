using Zenject;

namespace Common
{
    public static class ZenjetExtensions
    {
        public static T Inject<T>(this T classToInject, DiContainer container ) where T: class
        {
            container.Inject(classToInject);
            return classToInject;
        }
    }
}