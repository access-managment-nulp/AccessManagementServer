using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccessManagementApp.Repository.Models;

[Table("Speciality")]
public partial class Speciality
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("sName")]
    public string Name { get; set; } = null!;

    [InverseProperty("Specialities")]
    public virtual ICollection<AccessGroup> AccessGroups { get; set; } = null!;

    [InverseProperty("Specialities")]
    public virtual ICollection<Access> Accesses { get; set; } = null!;
}
