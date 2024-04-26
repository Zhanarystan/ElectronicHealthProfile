using ElectronicHealthProfile.Entities;
using Microsoft.AspNetCore.Identity;

namespace ElectronicHealthProfile.Persistence;

public class Seed
{
    public static async Task SeedData(DataContext context, UserManager<AppUser> userManager) 
    { 
        if (!context.Cities.Any() && !context.Institutions.Any() && !context.Users.Where(u => u.UserType != UserType.Admin).Any()) 
        {
            var cities = new List<City> 
            {
                new City
                {
                    Name = "Almaty"
                },
                new City
                {
                    Name = "Astana"
                },
                new City
                {
                    Name = "Shymkent"
                }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
            cities = context.Cities.ToList();

            var institutions = new List<Institution>
            {
                new Institution
                {
                    Name = "Emir-Med",
                    Address = "Manas 59",
                    InstitutionType = InstitutionType.Medical,
                    InstitutionSubType = InstitutionSubType.PolyClinic,
                    CityId = cities.First(c => c.Name == "Almaty").Id
                },
                new Institution
                {
                    Name = "123-Clinic",
                    Address = "Nursat 98",
                    InstitutionType = InstitutionType.Medical,
                    InstitutionSubType = InstitutionSubType.Clinic,
                    CityId = cities.First(c => c.Name == "Shymkent").Id
                },
                new Institution
                {
                    Name = "International Information Technology University",
                    Address = "Manas 34",
                    InstitutionType = InstitutionType.Educational,
                    InstitutionSubType = InstitutionSubType.University,
                    CityId = cities.First(c => c.Name == "Almaty").Id
                }
            };

            context.Institutions.AddRange(institutions);
            context.SaveChanges();
            institutions = context.Institutions.ToList();

            var users = new List<AppUser>
            {
                new AppUser
                {
                    Email = "student1@iitu.edu.kz",
                    UserName = "SultanovaAkerke",
                    FullName = "Sultanova Akerke",
                    Gender = Gender.Female,
                    UserType = UserType.UniversityStudent,
                    BirthDate = new DateTime(2001, 1, 22),
                    InstitutionId = institutions.First(i => i.Name == "International Information Technology University").Id
                },
                new AppUser
                {
                    Email = "student2@iitu.edu.kz",
                    UserName = "Student2",
                    FullName = "Student2",
                    Gender = Gender.Male,
                    UserType = UserType.UniversityStudent,
                    BirthDate = new DateTime(2000, 10, 20),
                    InstitutionId = institutions.First(i => i.Name == "International Information Technology University").Id
                },
                new AppUser
                {
                    Email = "medstaff1@medical.kz",
                    UserName = "MedicalStaff1",
                    FullName = "Medical Staff1",
                    Gender = Gender.Female,
                    UserType = UserType.Doctor,
                    BirthDate = new DateTime(2001, 1, 22),
                    InstitutionId = institutions.First(i => i.Name == "Emir-Med").Id
                },
                new AppUser
                {
                    Email = "medstaff2@medical.kz",
                    UserName = "MedicalStaff2",
                    FullName = "Medical Staff2",
                    Gender = Gender.Female,
                    UserType = UserType.Nurse,
                    BirthDate = new DateTime(2001, 1, 22),
                    InstitutionId = institutions.First(i => i.Name == "Emir-Med").Id
                },
                new AppUser
                {
                    Email = "iitu_admin1@iitu.kz",
                    UserName = "IituAdmin1",
                    FullName = "Iitu Admin1",
                    Gender = Gender.Male,
                    UserType = UserType.InstitutionAdmin,
                    BirthDate = new DateTime(2001, 1, 22),
                    InstitutionId = institutions.First(i => i.Name == "International Information Technology University").Id
                },
                new AppUser
                {
                    Email = "emirmed_admin1@emirmed.kz",
                    UserName = "EmirmedAdmin1",
                    FullName = "Emirmed Admin1",
                    Gender = Gender.Male,
                    UserType = UserType.InstitutionAdmin,
                    BirthDate = new DateTime(2001, 1, 22),
                    InstitutionId = institutions.First(i => i.Name == "Emir-Med").Id
                },
            };
            var result0 = await userManager.CreateAsync(users[0], "Pass_12345"); // Akerke
            if (result0.Succeeded)
            {
                await userManager.AddToRoleAsync(users[0], "student");
                context.SaveChanges();
            }

            var result1 = await userManager.CreateAsync(users[1], "Pass_12345"); // Student1
            if (result1.Succeeded)
            {
                await userManager.AddToRoleAsync(users[1], "student");
                context.SaveChanges();
            }

            var result2 = await userManager.CreateAsync(users[2], "Pass_12345"); // Medical Staff1
            if (result2.Succeeded)
            {
                await userManager.AddToRoleAsync(users[2], "medical_staff");
                context.SaveChanges();
            }

            var result3 = await userManager.CreateAsync(users[3], "Pass_12345"); // Medical Staff2
            if (result3.Succeeded)
            {
                await userManager.AddToRoleAsync(users[3], "medical_staff");
                context.SaveChanges();
            }

            var result4 = await userManager.CreateAsync(users[4], "Pass_12345"); // IituAdmin1
            if (result4.Succeeded)
            {
                await userManager.AddToRoleAsync(users[4], "institution_admin");
                context.SaveChanges();
            }

            var result5 = await userManager.CreateAsync(users[5], "Pass_12345"); // EmirMedAdmin1
            if (result5.Succeeded)
            {
                await userManager.AddToRoleAsync(users[5], "institution_admin");
                context.SaveChanges();
            }
        }
    }
}
