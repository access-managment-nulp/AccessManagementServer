using System.ComponentModel.DataAnnotations.Schema;

namespace AccessManagementApp.Entities
{
    public class AccessModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
