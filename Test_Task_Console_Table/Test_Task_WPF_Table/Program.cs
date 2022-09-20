using System;
using System.Linq;
using Test_Task_WPF_Table.Classes;

namespace MySQLApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add new Users
            using (ApplicationContext db = new ApplicationContext())
            {
                // Create Default order
                if (db.Users.Count() == 0)
                {
                    Console.WriteLine("Def orders:");
                    User user1 = new User { Name = "Tom", SurName = "Surname Tom", Decription = "111111111111", CreatedOn = DateTime.Now, SubcriedTo = DateTime.Now.AddDays(1) };
                    User user2 = new User { Name = "Bob", SurName = "Surname Bob", Decription = "22222222222", CreatedOn = DateTime.Now, SubcriedTo = DateTime.Now.AddDays(1) };

                     db.Users.AddRangeAsync(user1, user2);
                     db.SaveChangesAsync();

                    ShowUsers();
                }
                // Create new User
                Console.WriteLine("Create new User");
                User newUser = new User { Name = "Alice", SurName = "Surname Alice", Decription = "3333333333", CreatedOn = DateTime.Now, SubcriedTo = DateTime.Now.AddDays(1 };

                db.Users.AddAsync(newUser);
                db.SaveChangesAsync();

                ShowUsers();

                // Edit User
                Console.WriteLine("Edit new User");
                User newEditUser = db.Users.OrderByDescending( u => u.Id ).First();

                newEditUser.SurName = newEditUser.SurName + "1";
                db.Users.Update(newEditUser);
                db.SaveChangesAsync();
                ShowUsers();


               // Delete new user
                Console.WriteLine("Delete new User");
                db.Users.Remove(newEditUser);
                db.SaveChangesAsync();
                ShowUsers();

            }
        }

        static private void ShowUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.SurName} - {u.SubcriedTo}");
                }
            }
        }
    }
}
