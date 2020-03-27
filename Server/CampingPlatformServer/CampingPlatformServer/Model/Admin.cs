using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampingPlatformServer.Model
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Username required")]
        [StringLength(60, ErrorMessage = "Username can't be longer than 60 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        public void Copy(Admin admin)
        {
            this.Username = admin.Username;
            this.Password = admin.Password;
        }
    }
}
