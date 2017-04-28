using System;
using System.Reflection;
using Castle.MicroKernel;
using Castle.MicroKernel.ComponentActivator;

namespace OrdersTest
{
    public static class WindsorExtension
    {
        public static void InjectProperties(this IKernel kernel, object target)
        {
            var type = target.GetType();
            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.CanWrite && kernel.HasComponent(property.PropertyType))
                {
                    var value = kernel.Resolve(property.PropertyType);
                    try
                    {
                        property.SetValue(target, value, null);
                    }
                    catch (Exception ex)
                    {
                        var message =
                            $"Error setting property {property.Name} on type {type.FullName}, See inner exception for more information.";
                        throw new ComponentResolutionException(message, ex);
                    }
                }
            }
        }
    }
}