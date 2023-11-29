using AccessManagementApp.Repository.Models;

namespace AccessManagementApp.Entities
{
    public class UpdateAccessGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<AccessModel> Accesses { get; set; } = null!;
    }
}
