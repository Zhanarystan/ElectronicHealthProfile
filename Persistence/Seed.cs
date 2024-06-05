using ElectronicHealthProfile.Entities;
using Microsoft.AspNetCore.Identity;

namespace ElectronicHealthProfile.Persistence;

public class Seed
{
    public static async Task SeedUsers(DataContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager) 
    { 
        if (!context.Cities.Any() && !context.Institutions.Any() && !context.Users.Any()) 
        {
            var cities = new List<City> 
            {
                new City
                {
                    Name = "Алматы"
                },
                new City
                {
                    Name = "Астана"
                },
                new City
                {
                    Name = "Шымкент"
                }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
            cities = context.Cities.ToList();

            var institutions = new List<Institution>
            {
                new Institution
                {
                    Name = "Эмир-мед",
                    Address = "Манаса 59",
                    InstitutionType = InstitutionType.Medical,
                    InstitutionSubType = InstitutionSubType.PolyClinic,
                    CityId = cities.First(c => c.Name == "Алматы").Id
                },
                new Institution
                {
                    Name = "КЛИНИКА-123",
                    Address = "Нурсат 98",
                    InstitutionType = InstitutionType.Medical,
                    InstitutionSubType = InstitutionSubType.Clinic,
                    CityId = cities.First(c => c.Name == "Шымкент").Id
                },
                new Institution
                {
                    Name = "Международный Университет Информационных Технологий",
                    Address = "Манаса 34",
                    InstitutionType = InstitutionType.Educational,
                    InstitutionSubType = InstitutionSubType.University,
                    CityId = cities.First(c => c.Name == "Алматы").Id
                }
            };

            context.Institutions.AddRange(institutions);
            context.SaveChanges();
            institutions = context.Institutions.ToList();

            var positions = new List<Position> 
            {
                new Position
                {
                    Name = "Студент",
                    CodeName = "STUDENT"
                },
                new Position
                {
                    Name = "Школьник",
                    CodeName = "SCHOOL_STUDENT"
                },
                new Position
                {
                    Name = "Врач терапевт",
                    CodeName = "THERAPIST",
                },
                new Position
                {
                    Name = "Врач лор",
                    CodeName = "ENT"
                },
                new Position
                {
                    Name = "Медсестра",
                    CodeName = "NURSE"
                },
                new Position
                {
                    Name = "Админ заведений",
                    CodeName = "INSTITUTION_ADMIN"
                },
                new Position
                {
                    Name = "Админ системы",
                    CodeName = "SYSTEM_ADMIN"
                }
            };

            context.Positions.AddRange(positions);
            context.SaveChanges();
            positions = context.Positions.ToList();

            if (await roleManager.FindByNameAsync("system_admin") == null)
                await roleManager.CreateAsync(new IdentityRole("system_admin"));

            if (await roleManager.FindByNameAsync("institution_admin") == null)
                await roleManager.CreateAsync(new IdentityRole("institution_admin"));

            if (await roleManager.FindByNameAsync("student") == null)
                await roleManager.CreateAsync(new IdentityRole("student"));
            
            if (await roleManager.FindByNameAsync("medical_staff") == null)
                await roleManager.CreateAsync(new IdentityRole("medical_staff"));

            var users = new List<AppUser>
            {
                new AppUser
                {
                    Email = "sultanova_akerke@iitu.edu.kz",
                    UserName = "sultanova_akerke",
                    FirstName = "Ақерке",
                    LastName = "Сұлтанова",
                    MiddleName = "Маратқызы",
                    IIN = "010122340586",
                    BirthDate = new DateTime(2001, 1, 22),
                    Gender = Gender.Female,
                    CityId = cities.First(c => c.Name == "Алматы").Id,
                    Address = "Абая 999",
                    PositionId = positions.First(p => p.CodeName == "STUDENT").Id,
                    InstitutionId = institutions.First(i => i.Name == "Международный Университет Информационных Технологий").Id
                },
                new AppUser
                {
                    Email = "student_1@iitu.edu.kz",
                    UserName = "student_1",
                    FirstName = "Student",
                    LastName = "1",
                    MiddleName = "",
                    IIN = "111111",
                    BirthDate = new DateTime(2001, 1, 1),
                    Gender = Gender.Male,
                    CityId = cities.First(c => c.Name == "Алматы").Id,
                    Address = "Абая 1145145",
                    PositionId = positions.First(p => p.CodeName == "STUDENT").Id,
                    InstitutionId = institutions.First(i => i.Name == "Международный Университет Информационных Технологий").Id
                },
                new AppUser
                {
                    Email = "student_2@iitu.edu.kz",
                    UserName = "student_2",
                    FirstName = "Student",
                    LastName = "2",
                    MiddleName = "",
                    IIN = "22222222",
                    BirthDate = new DateTime(2001, 1, 1),
                    Gender = Gender.Male,
                    CityId = cities.First(c => c.Name == "Алматы").Id,
                    Address = "Абая 532432432",
                    PositionId = positions.First(p => p.CodeName == "STUDENT").Id,
                    InstitutionId = institutions.First(i => i.Name == "Международный Университет Информационных Технологий").Id
                },
                new AppUser
                {
                    Email = "medstaff1@medical.kz",
                    UserName = "medstaff1",
                    FirstName = "Med",
                    LastName = "Staff",
                    MiddleName = "1",
                    IIN = "111111",
                    BirthDate = new DateTime(2001, 1, 1),
                    Gender = Gender.Male,
                    CityId = cities.First(c => c.Name == "Алматы").Id,
                    Address = "Абая 4500",
                    PositionId = positions.First(p => p.CodeName == "THERAPIST").Id,
                    InstitutionId = institutions.First(i => i.Name == "Международный Университет Информационных Технологий").Id
                },
                new AppUser
                {
                    Email = "medstaff2@medical.kz",
                    UserName = "medstaff2",
                    FirstName = "Med",
                    LastName = "Staff",
                    MiddleName = "2",
                    IIN = "222222222",
                    BirthDate = new DateTime(2001, 1, 1),
                    Gender = Gender.Female,
                    CityId = cities.First(c => c.Name == "Алматы").Id,
                    Address = "Абая 454400",
                    PositionId = positions.First(p => p.CodeName == "NURSE").Id,
                    InstitutionId = institutions.First(i => i.Name == "Эмир-мед").Id
                },
                new AppUser
                {
                    Email = "medstaff3@medical.kz",
                    UserName = "medstaff3",
                    FirstName = "Med",
                    LastName = "Staff",
                    MiddleName = "3",
                    IIN = "33333333",
                    BirthDate = new DateTime(2001, 1, 1),
                    Gender = Gender.Female,
                    CityId = cities.First(c => c.Name == "Алматы").Id,
                    Address = "Абая 11111141",
                    PositionId = positions.First(p => p.CodeName == "ENT").Id,
                    InstitutionId = institutions.First(i => i.Name == "Эмир-мед").Id
                },
                new AppUser
                {
                    Email = "iitu_admin1@iitu.kz",
                    UserName = "iitu_admin1",
                    FirstName = "Iitu",
                    LastName = "Admin",
                    MiddleName = "1",
                    IIN = "1111111111",
                    BirthDate = new DateTime(2001, 1, 1),
                    Gender = Gender.Female,
                    CityId = cities.First(c => c.Name == "Алматы").Id,
                    Address = "Абая 11111141",
                    PositionId = positions.First(p => p.CodeName == "INSTITUTION_ADMIN").Id,
                    InstitutionId = institutions.First(i => i.Name == "Международный Университет Информационных Технологий").Id
                },
                new AppUser
                {
                    Email = "emirmed_admin1@emirmed.kz",
                    UserName = "emirmed_admin1",
                    FirstName = "Emirmed",
                    LastName = "Admin",
                    MiddleName = "1",
                    IIN = "1111111111",
                    BirthDate = new DateTime(2001, 1, 1),
                    Gender = Gender.Male,
                    CityId = cities.First(c => c.Name == "Алматы").Id,
                    Address = "Абая 11111141",
                    PositionId = positions.First(p => p.CodeName == "INSTITUTION_ADMIN").Id,
                    InstitutionId = institutions.First(i => i.Name == "Эмир-мед").Id
                }
            };

            var result0 = await userManager.CreateAsync(users[0], "Student_12345"); // Akerke
            if (result0.Succeeded)
            {
                await userManager.AddToRoleAsync(users[0], "student");
                context.SaveChanges();
            }

            var result1 = await userManager.CreateAsync(users[1], "Student_12345"); // Student1
            if (result1.Succeeded)
            {
                await userManager.AddToRoleAsync(users[1], "student");
                context.SaveChanges();
            }

            var result2 = await userManager.CreateAsync(users[2], "Student_12345"); // Student2
            if (result2.Succeeded)
            {
                await userManager.AddToRoleAsync(users[2], "student");
                context.SaveChanges();
            }

            var result3 = await userManager.CreateAsync(users[3], "Medstaff_12345"); // Medical Staff1
            if (result3.Succeeded)
            {
                await userManager.AddToRoleAsync(users[3], "medical_staff");
                context.SaveChanges();
            }

            var result4 = await userManager.CreateAsync(users[4], "Medstaff_12345"); // Medical Staff2
            if (result4.Succeeded)
            {
                await userManager.AddToRoleAsync(users[4], "medical_staff");
                context.SaveChanges();
            }

            var result5 = await userManager.CreateAsync(users[5], "Medstaff_12345"); // Medical Staff3
            if (result5.Succeeded)
            {
                await userManager.AddToRoleAsync(users[5], "medical_staff");
                context.SaveChanges();
            }

            var result6 = await userManager.CreateAsync(users[6], "Admin_12345"); // IituAdmin1
            if (result6.Succeeded)
            {
                await userManager.AddToRoleAsync(users[6], "institution_admin");
                context.SaveChanges();
            }

            var result7 = await userManager.CreateAsync(users[7], "Admin_12345"); // EmirMedAdmin1
            if (result7.Succeeded)
            {
                await userManager.AddToRoleAsync(users[7], "institution_admin");
                context.SaveChanges();
            }

            string adminEmail = "admin@gmail.com";
            string password = "Admin_12345";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                AppUser admin = new AppUser
                {
                    Email = adminEmail,
                    UserName = "admin",
                    FirstName = "Admin",
                    LastName = "Admin",
                    MiddleName = "Admin",
                    IIN = "0000000000000",
                    BirthDate = new DateTime(2001, 1, 22),
                    Gender = Gender.Male,
                    CityId = Guid.Empty,
                    Address = "",
                    PositionId = positions.First(p => p.CodeName == "SYSTEM_ADMIN").Id,
                    InstitutionId = Guid.Empty
                };

                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "system_admin");
                }
            }
        }
    }

    public static async Task SeedData(DataContext context)
    {
        if (!context.SickNotes.Any() && !context.Appointments.Any() /* && !context.LabResults.Any() */) 
        {
            var sickNotes = new List<SickNote> 
            {
                new SickNote
                {
                    NoteNumber = 456,
                    NoteTitle = Constants.ConstantValues.SickNoteTitle,
                    IssueDate = new DateTime(2024, 1, 20),
                    StudentId = context.Users.First(u => u.UserName == "sultanova_akerke").Id,
                    MedicalStaffId = context.Users.First(u => u.UserName == "medstaff3").Id,
                    AbsenceReason = "Обнаружение вируса гриппа",
                    AbsenceStartDate = new DateTime(2024, 1, 20),
                    AbsenceEndDate = new DateTime(2024, 1, 26),
                },
                new SickNote
                {
                    NoteNumber = 23,
                    NoteTitle = Constants.ConstantValues.SickNoteTitle,
                    IssueDate = DateTime.Now,
                    StudentId = context.Users.First(u => u.UserName == "sultanova_akerke").Id,
                    MedicalStaffId = context.Users.First(u => u.UserName == "medstaff3").Id,
                    AbsenceReason = "Высокая температура тела",
                    AbsenceStartDate = new DateTime(2024, 5, 18),
                    AbsenceEndDate = new DateTime(2024, 5, 23),
                }
            };

            context.SickNotes.AddRange(sickNotes);
            context.SaveChanges();
            sickNotes = context.SickNotes.ToList();

            var appointments = new List<Appointment>
            {
                new Appointment
                {
                    Title = "Прием врача",
                    Notes = Constants.ConstantValues.AppointmentGrippeNote,
                    MedicalStaffId = context.Users.First(u => u.UserName == "medstaff3").Id,
                    StudentId = context.Users.First(u => u.UserName == "sultanova_akerke").Id,
                    ConductedDate = new DateTime(2024, 1, 20)
                },
                new Appointment
                {
                    Title = "Прием врача 17.05",
                    Notes = Constants.ConstantValues.AppointmentHighTemperatureNote,
                    MedicalStaffId = context.Users.First(u => u.UserName == "medstaff3").Id,
                    StudentId = context.Users.First(u => u.UserName == "sultanova_akerke").Id,
                    ConductedDate = new DateTime(2024, 5, 17)
                }
            };

            context.Appointments.AddRange(appointments);
            context.SaveChanges();
            appointments = context.Appointments.ToList();

            var analysis = new List<Analysis>
            {
                new Analysis
                {
                    Name = "Гемоглобин (Мужчины)",
                    NormValue = "130-170",
                    Unit = "г/л"
                },
                new Analysis
                {
                    Name = "Гемоглобин (Женщины)",
                    NormValue = "120-150",
                    Unit = "г/л"
                },
                new Analysis
                {
                    Name = "Эритроциты (Мужчины)",
                    NormValue = "4.5-5.5",
                    Unit = "x 10^12/л"
                },
                new Analysis
                {
                    Name = "Эритроциты (Женщины)",
                    NormValue = "3.8-4.8",
                    Unit = "x 10^12/л"
                },
                new Analysis
                {
                    Name = "Глюкоза",
                    NormValue = "3.3-5.5",
                    Unit = "ммоль/л"
                },
                new Analysis
                {
                    Name = "Общий белок",
                    NormValue = "60-85",
                    Unit = "г/л"
                },
                new Analysis
                {
                    Name = "Холестерин",
                    NormValue = "3.6-7.8",
                    Unit = "ммоль/л"
                },
            };

            context.Analysis.AddRange(analysis);
            context.SaveChanges();
            analysis = context.Analysis.ToList();

            var labResultSets = new List<LabResultSet>
            {
                new LabResultSet
                {
                    Name = "Общий анализ крови (ОАК)",
                    CreatedAt = new DateTime(2024, 1, 20),
                    StudentId = context.Users.First(u => u.UserName == "sultanova_akerke").Id
                },
                new LabResultSet
                {
                    Name = "Биохимический анализ крови",
                    CreatedAt = new DateTime(2024, 5, 17),
                    StudentId = context.Users.First(u => u.UserName == "sultanova_akerke").Id
                }
            };

            context.LabResultSets.AddRange(labResultSets);
            context.SaveChanges();
            labResultSets = context.LabResultSets.ToList();

            var labResults = new List<LabResult>
            {
                new LabResult
                {
                    Value = "130",
                    CreatedAt = new DateTime(2024, 1, 20),
                    AnalysisId = analysis[1].Id,
                    LabResultSetId = labResultSets[0].Id
                },
                new LabResult
                {
                    Value = "4.2",
                    CreatedAt = new DateTime(2024, 1, 20),
                    AnalysisId = analysis[3].Id,
                    LabResultSetId = labResultSets[0].Id
                },
                new LabResult
                {
                    Value = "120",
                    CreatedAt = new DateTime(2024, 5, 17),
                    AnalysisId = analysis[1].Id,
                    LabResultSetId = labResultSets[1].Id
                },
                new LabResult
                {
                    Value = "3.8",
                    CreatedAt = new DateTime(2024, 5, 17),
                    AnalysisId = analysis[3].Id,
                    LabResultSetId = labResultSets[1].Id
                },
                new LabResult
                {
                    Value = "73",
                    CreatedAt = new DateTime(2024, 5, 17),
                    AnalysisId = analysis[5].Id,
                    LabResultSetId = labResultSets[1].Id
                },
                new LabResult
                {
                    Value = "5",
                    CreatedAt = new DateTime(2024, 5, 17),
                    AnalysisId = analysis[6].Id,
                    LabResultSetId = labResultSets[1].Id
                },
            };
            context.LabResults.AddRange(labResults);
            context.SaveChanges();
            labResults = context.LabResults.ToList();

            var medicalData = new List<MedicalData>
            {
                new MedicalData
                {
                    StudentId = context.Users.First(u => u.UserName == "sultanova_akerke").Id,
                    Weight = 55,
                    Height = 161,
                    BloodType = "3"
                }
            };
            context.MedicalData.AddRange(medicalData);
            context.SaveChanges();
            medicalData = context.MedicalData.ToList();
        }
    }
}
