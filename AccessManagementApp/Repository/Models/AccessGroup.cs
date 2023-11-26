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

    [Column("accessId")]
    public int AccessId { get; set; }

    [ForeignKey("AccessId")]
    [InverseProperty("AccessGroups")]
    public virtual Access Access { get; set; } = null!;

    [InverseProperty("AccessGroup")]
    public virtual ICollection<Speciality> Specialities { get; set; } = new List<Speciality>();
}
