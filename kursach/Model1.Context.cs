﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kursach
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class heroku_e7222c258ac0aa4Entities1 : DbContext
    {
        public heroku_e7222c258ac0aa4Entities1()
            : base("name=heroku_e7222c258ac0aa4Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<gender> gender { get; set; }
        public virtual DbSet<status> status { get; set; }
        public virtual DbSet<task> task { get; set; }
        public virtual DbSet<user> user { get; set; }
    }
}
