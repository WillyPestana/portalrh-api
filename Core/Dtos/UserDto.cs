namespace Core.Dtos
{
    public class UserDto
    {
        public string? Id { get; set; } = null!;

        public List<string>? BusinessPhones { get; set; } = null!;

        public string? DisplayName { get; set; } = null!;

        public string? GivenName { get; set; } = null!;

        public object? JobTitle { get; set; } = null!;

        public string? Mail { get; set; } = null!;

        public string? MobilePhone { get; set; } = null!;

        public object? OfficeLocation { get; set; } = null!;

        public string? PreferredLanguage { get; set; } = null!;

        public string? Surname { get; set; } = null!;

        public string? UserPrincipalName { get; set; } = null!;

        public string? Photo { get; set; } = null!;

        public PresenceDto? Presence { get; set; }

        public List<MemberOfDto>? MemberOf { get; set; } = new List<MemberOfDto>();
    }
}
