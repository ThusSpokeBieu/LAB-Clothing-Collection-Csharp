using LABCC.Domain.Entities.Users;
using LABCC.Domain.Entities.Users.VO;
using LABCC.Domain.Enums;

namespace LABCC.Infrastructure.Database.Seed;

public static class UserSeed
{
    private static readonly DateTimeOffset Now = DateTimeOffset.Now;
    private static readonly Password passwordAdmin = Password.Hash("passwordadmin");
    private static readonly Password passwordCommon = Password.Hash("12345678");
    
    public static IEnumerable<UserDto> Data = new UserDto[]
    {
     new UserDto
      {
        Id = Guid.NewGuid(),
        Name = "Lucas Diego Santos",
        Document = "27865629109",
        DateOfBirth = new DateTime(2000, 03, 26),
        Gender = GenderEnum.MALE,
        Email = "lucas_diego@gimail.com",
        UserRole = UserRolesEnum.ADMIN,
        Phone = "63997293374",
        Status = StatusEnum.ACTIVE,
        Password = passwordAdmin.Value,
        CreatedAt = Now,
        UpdatedAt = Now,
      },
     new UserDto
      {
        Id = Guid.NewGuid(),
        Name = "Marcos Mateus Anthony Campos",
        Document = "12168236348",
        DateOfBirth = new DateTime(2001, 05, 06),
        Gender = GenderEnum.MALE,
        Email = "marcos.mateus.campos@doublesp.com.br",
        UserRole = UserRolesEnum.OTHER,
        Phone = "75994045248",
        Status = StatusEnum.INACTIVE,
        Password = passwordCommon.Value,
        CreatedAt = Now,
        UpdatedAt = Now,
      },
     new UserDto
      {
        Id = Guid.NewGuid(),
        Name = "Mirella Beatriz Lima",
        Document = "49361751530",
        DateOfBirth = new DateTime(1954, 05, 08),
        Gender = GenderEnum.FEMALE,
        Email = "mirella_beatriz_lima@engeseg.com.br",
        UserRole = UserRolesEnum.ADMIN,
        Phone = "62984209876",
        Status = StatusEnum.ACTIVE,
        Password = passwordCommon.Value,
        CreatedAt = Now,
        UpdatedAt = Now,
      },
     new UserDto
      {
        Id = Guid.NewGuid(),
        Name = "Antonio Carlos Eduardo Dias",
        Document = "86430604616",
        DateOfBirth = new DateTime(1996, 01, 03),
        Gender =  GenderEnum.OTHER,
        Email = "antonio_carlos_dias@lukin4.com.br",
        UserRole = UserRolesEnum.MANAGER,
        Phone = "65995790748",
        Status = StatusEnum.ACTIVE,
        Password = passwordCommon.Value,
        CreatedAt = Now,
        UpdatedAt = Now,
      },
     new UserDto
      {
        Id = Guid.NewGuid(),
        Name = "Kamilly Antônia Almeida",
        Document = "94598118415",
        DateOfBirth = new DateTime(1998, 05, 23),
        Gender = GenderEnum.FEMALE,
        Email = "kamilly.antonia.almeida@onset.com.br",
        UserRole = UserRolesEnum.CREATOR,
        Phone = "93986441270",
        Status = StatusEnum.ACTIVE,
        Password = passwordCommon.Value,
        CreatedAt = Now,
        UpdatedAt = Now,
      },
             new UserDto
        {
            Id = Guid.NewGuid(),
            Name = "Isabella Costa Lima",
            Document = "72508397235",
            DateOfBirth = new DateTime(1992, 11, 15),
            Gender = GenderEnum.FEMALE,
            Email = "isabella.costa.lima@example.com",
            UserRole = UserRolesEnum.MANAGER,
            Phone = "63987654321",
            Status = StatusEnum.ACTIVE,
            Password = passwordCommon.Value,
            CreatedAt = Now,
            UpdatedAt = Now,
        },
        new UserDto
        {
            Id = Guid.NewGuid(),
            Name = "Rafael Oliveira Silva",
            Document = "17950402873",
            DateOfBirth = new DateTime(1987, 07, 25),
            Gender = GenderEnum.MALE,
            Email = "rafael.oliveira.silva@example.com",
            UserRole = UserRolesEnum.OTHER,
            Phone = "62876543210",
            Status = StatusEnum.ACTIVE,
            Password = passwordCommon.Value,
            CreatedAt = Now,
            UpdatedAt = Now,
        },
        new UserDto
        {
            Id = Guid.NewGuid(),
            Name = "Carolina Santos Rodrigues",
            Document = "61247073149",
            DateOfBirth = new DateTime(1990, 04, 12),
            Gender = GenderEnum.FEMALE,
            Email = "carolina.santos.rodrigues@example.com",
            UserRole = UserRolesEnum.CREATOR,
            Phone = "63987624321",
            Status = StatusEnum.ACTIVE,
            Password = passwordCommon.Value,
            CreatedAt = Now,
            UpdatedAt = Now,
        },
        new UserDto
        {
            Id = Guid.NewGuid(),
            Name = "Daniel Mendes Oliveira",
            Document = "91850462817",
            DateOfBirth = new DateTime(1985, 12, 30),
            Gender = GenderEnum.MALE,
            Email = "daniel.mendes.oliveira@example.com",
            UserRole = UserRolesEnum.ADMIN,
            Phone = "62987654321",
            Status = StatusEnum.ACTIVE,
            Password = passwordCommon.Value,
            CreatedAt = Now,
            UpdatedAt = Now,
        },
        new UserDto
        {
            Id = Guid.NewGuid(),
            Name = "Exemplo Silva",
            Document = "91850462818",
            DateOfBirth = new DateTime(1995, 12, 30),
            Gender = GenderEnum.MALE,
            Email = "example@email.com",
            UserRole = UserRolesEnum.ADMIN,
            Phone = "62984654321",
            Status = StatusEnum.ACTIVE,
            Password = passwordCommon.Value,
            CreatedAt = Now,
            UpdatedAt = Now,
        }
    };
}