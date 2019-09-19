using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Key_Value_Store
{
    public class MyDictionary
    {
        
        public KeyValue<object>[] DictionArray = new KeyValue<object>[]
        {
            new KeyValue<object>("NotDog",  1),
            new KeyValue<object>("Cats", 2),
            new KeyValue<object>("Penguin", 4)
        };

         public object this [string _Key]
        {
            get
            {
                
                foreach (var Z in DictionArray)
                {
                    if (Z.Key.Equals(_Key))
                    {
                        return Z.Value;
                    }
                }
                throw new KeyNotFoundException ($"Key not found with the value {_Key}");
            }
            set
            {
                bool exists = false;
                int i = 0, temp = 0;
                foreach (var Z in DictionArray)
                {
                    if (Z.Key.Equals(_Key))
                    {
                        exists = true;
                        temp = i;
                    }
                    i++;
                }
                if (exists == true)
                {
                    DictionArray[temp] = new KeyValue<object>(_Key, value);
                }
                else
                {
                    Array.Resize(ref DictionArray, (DictionArray.Length + 1));
                    DictionArray[DictionArray.Length-1] = new KeyValue<object>(_Key, value);
                }
            }
        }

    }
}
