using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PAccountant2.Common.Clone
{
    public static class CloneHelper
    {
        public static T CloneObject<T>(T objectToClone) where T : new()
        {
            if (objectToClone == null)
            {
                throw new NullReferenceException("no object were sent to copy");
            }

            var serializedObject = JsonConvert.SerializeObject(objectToClone);

            var objectClone = JsonConvert.DeserializeObject<T>(serializedObject);

            return objectClone;
        }

        public static IEnumerable<T> CloneArray<T>(IEnumerable<T> arrayToClone) where T : new()
        {
            if (arrayToClone == null)
            {
                throw new NullReferenceException("no array were sent to clone");
            }

            var arrayClone = arrayToClone.AsParallel().AsOrdered().Select(CloneObject);

            return arrayClone;
        }
    }
}
