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

    [Column("accessGroupId")]
    public int AccessGroupId { get; set; }

    [ForeignKey("AccessGroupId")]
    [InverseProperty("Specialities")]
    public virtual AccessGroup AccessGroup { get; set; } = null!;
}
