using System.Reflection;
using AutoMapper;

namespace Altavix.Application.Mapping;

public class AssemblyMappingProfile : Profile
{
      public AssemblyMappingProfile(Assembly assembly)
      {
            var types = assembly.GetExportedTypes()
                  .Where(t => t.GetInterfaces()
                  .Any(i => i.IsGenericType && (
                        i.GetGenericTypeDefinition() == typeof(IMapWith<>) ||
                        i.GetGenericTypeDefinition() == typeof(IMapTo<>))))
                  .ToList();

            foreach (var type in types)
            {
                  var instance = Activator.CreateInstance(type);
                  var methodInfo = type.GetMethod("Mapping");

                  if (methodInfo != null)
                  {
                        methodInfo.Invoke(instance, new object[] { this });
                  }
                  else
                  {
                        var interfaceType =  type.GetInterfaces()
                              .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>));
                        methodInfo?.Invoke(instance, new object[] { this });
                        
                        if(interfaceType != null)
                        {
                              var method = interfaceType.GetMethod("Mapping");
                              method?.Invoke(instance, new object[] { this });
                        }
                  }
            }
      }
}