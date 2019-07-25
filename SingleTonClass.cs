using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SingelTon
{
    [Serializable]
    class SingleTonClass :ISerializable
    {
        private static SingleTonClass _instance;

        public string Name = "SingleTon";

        internal static SingleTonClass Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SingleTonClass();

                return _instance;
            }            
        }

        void ISerializable.GetObjectData(
         SerializationInfo info, StreamingContext context)
        {
            // Instead of serializing this object, 
            // serialize a SingletonSerializationHelp instead.
            info.SetType(typeof(SingletonSerializationHelper));
            // No other values need to be added.
        }
    }

    [Serializable]
    internal sealed class SingletonSerializationHelper : IObjectReference
    {
        // This object has no fields (although it could).

        // GetRealObject is called after this object is deserialized.
        public Object GetRealObject(StreamingContext context)
        {
            // When deserialiing this object, return a reference to 
            // the Singleton object instead.
            return SingleTonClass.Instance;
        }
    }
}
