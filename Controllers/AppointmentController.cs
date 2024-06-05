using ElectronicHealthProfile.Constants;
using ElectronicHealthProfile.Core;
using ElectronicHealthProfile.DTOs;
using ElectronicHealthProfile.Entities;
using ElectronicHealthProfile.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ElectronicHealthProfile.Controllers;


[ApiController]
[Route("api/appointment")]
public class AppointmentController : BaseApiController
{
    private readonly DataContext _context;
    public AppointmentController(DataContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<IActionResult> Create(AppointmentCreateDto dto) 
    {
        var appointment = new Appointment
        {
            Title = dto.Title,
            Notes = dto.Notes,
            MedicalStaffId = dto.MedicalStaffId,
            StudentId = dto.StudentId,
            ConductedDate = DateTime.Now
        };

        _context.Appointments.Add(appointment);
        
        var saveFactor = await _context.SaveChangesAsync();

        if (saveFactor <= 0) 
            return HandleResult(Result<Appointment>.Failure(new List<string>() {  $"Appointment не создано!" }));
        return HandleResult(Result<Appointment>.Success(appointment));
    }

    [HttpGet("student/{studentId}")]
    public async Task<IActionResult> List(string studentId) 
    {
        var appointments = await _context.Appointments
                                        .Where(a => a.StudentId == studentId)
                                        .OrderByDescending(a => a.ConductedDate)
                                        .ToListAsync();

        var appointmentsDto = new List<AppointmentDto>();

        var student = await _context.Users.FindAsync(studentId);

        if (student == null)
            return HandleResult(Result<List<AppointmentDto>>.Failure(new List<string>() {  $"Student не найдено!" }));

        foreach (var appointment in appointments)
        {
            var medicalStaff = await _context.Users.FindAsync(appointment.MedicalStaffId);
            var appointmentDto = new AppointmentDto
            {
                Id = appointment.Id,
                Title = appointment.Title,
                Notes = appointment.Notes,
                MedicalStaff = CreateUserDto(medicalStaff),
                Student = CreateUserDto(student),
                ConductedDate = appointment.ConductedDate
            };
            appointmentsDto.Add(appointmentDto);
        }
        
        return HandleResult(Result<List<AppointmentDto>>.Success(appointmentsDto));
    }

    // [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var appointment = await _context.Appointments.FindAsync(id);

        var student = await _context.Users.FindAsync(appointment.StudentId);

        var medicalStaff = await _context.Users.FindAsync(appointment.MedicalStaffId);

        var appointmentDto = new AppointmentDto
        {
            Id = appointment.Id,
            Title = appointment.Title,
            Notes = appointment.Notes,
            MedicalStaff = CreateUserDto(medicalStaff), 
            Student = CreateUserDto(student),
            ConductedDate = appointment.ConductedDate
        };

        return HandleResult(Result<AppointmentDto>.Success(appointmentDto));
    }
    private UserDto CreateUserDto(AppUser user) 
    {
        var position = _context.Positions.Find(user.PositionId);
        var institution =  _context.Institutions.Find(user.InstitutionId);
        return new UserDto
        {
            Id = user.Id,
            Token = "",
            Username = user.UserName,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            IIN = user.IIN,
            BirthDate = user.BirthDate,
            Gender = (Gender)user.Gender,
            GenderName = user.Gender == Gender.Male ? "Мужской" : "Женский",
            InstitutionId = user.InstitutionId,
            InstitutionName = institution.Name,
            PositionId = user.PositionId,
            PositionName = position.Name,
            Roles = new List<string>()
        };
    }
}