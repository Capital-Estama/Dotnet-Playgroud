﻿using System;
using Microsoft.EntityFrameworkCore;
namespace Dishes.Models;

    
    
    // the MyContext class representing a session with our MySQL database, allowing us to query for or save data
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        // the "Monsters" table name will come from the DbSet property name
        public DbSet<Dish> Dishes { get; set; }
    }
    

