using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccessManagementApp.Repository.Models;

[Table("AccessGroup")]
public partial class AccessGroup
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("aName")]
    public string Name { get; set; } = null!;

    [InverseProperty("AccessGroups")]
    public virtual ICollection<Access> Accesses { get; set; } = null!;

    [InverseProperty("AccessGroups")]
    public virtual ICollection<Speciality> Specialities { get; set; } = new List<Speciality>();
}
