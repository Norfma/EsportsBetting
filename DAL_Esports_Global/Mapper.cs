using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Esports_Global
{
    public static class Mapper
    {
        public static TEntity MapToGeneric<TEntity>(this object bas) where TEntity : new()
        {
            Type targetType = typeof(TEntity);

            PropertyInfo[] properties = targetType.GetProperties();

            var instance = System.Activator.CreateInstance(targetType);
            foreach (var property in properties)
            {
                property.SetValue(instance, bas.GetType().GetProperty(property.Name).GetValue(bas), null);
            }

            return (TEntity)instance;
        }
    }
}
