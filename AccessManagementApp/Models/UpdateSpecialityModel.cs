using AccessManagementApp.Repository.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessManagementApp.Entities
{
    public class UpdateSpecialityModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<AccessGroupModel> AccessGroups { get; set; } = null!;
        public ICollection<AccessModel> Accesses { get; set; } = null!;
    }
}
