namespace JobNetCore6.DTOs.Respone
{
    public class ResponeUserGetAll
    {
        public Guid? Id { get; set; }
        public string? UserName { get; set; }


        public string? Password { get; set; }

        public string? AccountType { get; set; }


        public string? UserRole { get; set; }


        public bool? IsDeleted { get; set; }
    }
}
