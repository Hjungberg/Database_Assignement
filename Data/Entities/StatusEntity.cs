﻿

using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class StatusEntity
{
    public int Id { get; set; }
    public string Status { get; set; } = null!;

}
