using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Transactions.Info.Core.Extensions
{
    public static class ObjectSerializationExtension
    {
        public static string SerializeThis(this object model)
        {
            return model is null ? string.Empty : JsonSerializer.Serialize(model);
        }
    }
}
