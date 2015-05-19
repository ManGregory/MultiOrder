using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiOrderWin.Models
{
    class MediaContextInitializer : DropCreateDatabaseIfModelChanges<MediaContext>
    {
        protected override void Seed(MediaContext context)
        {
            base.Seed(context);
            context.Users.AddRange(
                new[]
                {
                    new User {Name = "admin", Password = "admin", IsAdmin = true},
                    new User {Name = "user", Password = "user", IsAdmin = false}
                });
            context.SaveChanges();
        }
    }
}
