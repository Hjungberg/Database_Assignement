﻿using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

}
