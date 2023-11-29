using AccessManagementApp.Repository.Models;

namespace AccessManagementApp.Entities
{
    public class CreateAccessGroupModel
    {
        public string Name { get; set; } = null!;
        public ICollection<AccessModel> Accesses { get; set; } = null!;
    }
}
