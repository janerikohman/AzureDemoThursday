using System;
using System.Collections.Generic;
using System.Text;

namespace ActivityReader
{
    class DataStore
    {
        public static void Store(BaseActivity activity)
        {
            Console.WriteLine($"Storing activity {activity.Iatiidentifier}");
        }
    }
}
