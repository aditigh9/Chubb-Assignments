using Microsoft.AspNetCore.Identity;


namespace OrderManagementApi.Models

{

    public class ApplicationUser : IdentityUser

    {
        public DateOnly? DOB {  get; set; }
    }

}
