using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.CIS.EFCore.ConsoleClient
{
    class CreateDatabase
    {
        public static void Test()
        {
            using (MyContext context = new MyContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}
