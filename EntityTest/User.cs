using System;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public string Nickname { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Password { get; set; }
}