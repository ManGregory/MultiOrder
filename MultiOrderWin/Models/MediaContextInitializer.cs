using System.Data.Entity;

namespace MultiOrderWin.Models
{
    /// <summary>
    /// Инициализаця базы данных начальными значениями
    /// </summary>
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
            context.Classrooms.AddRange(
                new[]
                {
                    new Classroom {Id = 1, Name = "301"},
                    new Classroom {Id = 2, Name = "302"}
                });
            context.Equipments.AddRange(
                new[]
                {
                    new Equipment {ClassroomId = 1, Name = "Ноутбук", Amount = 5},
                    new Equipment {ClassroomId = null, Name = "Проектор", Amount = 5}
                });
            context.SaveChanges();
        }
    }
}
