using AccessManagementApp.Entities;
using AccessManagementApp.Repository.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessManagementApp.Models
{
    public class SpecialityModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<AccessGroupModel> AccessGroups { get; set; } = null!;
        public ICollection<AccessModel> Accesses { get; set; } = null!;
    }
}
