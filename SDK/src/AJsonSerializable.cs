using Newtonsoft.Json.Linq;

namespace Harbard
{
    namespace Api
    {
        public abstract class AJsonSerializable
        {
            public abstract JObject? serialize(); 

            public abstract bool deserialize(JObject data);
        }
    }    
}