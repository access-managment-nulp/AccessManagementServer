using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccessManagementApp.Repository.Models;

[Table("Access")]
public partial class Access
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("aName")]
    public string Name { get; set; } = null!;

    [InverseProperty("Access")]
    public virtual ICollection<AccessGroup> AccessGroups { get; set; } = new List<AccessGroup>();
}
