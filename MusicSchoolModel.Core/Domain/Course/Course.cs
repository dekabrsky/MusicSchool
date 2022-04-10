using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicSchoolModel.Core.Domain.Abstractions;
using MusicSchoolModel.Core.Domain.Common.ValueObjects;

namespace MusicSchoolModel.Core.Domain.Course;

public class Course : Entity, IEntityTypeConfiguration<Course>
{
    public Course() { }

    public Course(Name name, bool? isOpen)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        IsOpen = isOpen ?? throw new ArgumentNullException(nameof(isOpen));

        Teachers = new List<Teacher.Teacher>();
        Projects = new List<Student.Student>();
    }

    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");
        builder.OwnsOne(
            x => x.Name,
            x => { x.Property(p => p.Value).HasColumnName("Name"); }
        );
    }

    public Name Name { get; set; }
    public bool IsOpen { get; set; }
    public ICollection<Teacher.Teacher> Teachers { get; }
    public ICollection<Student.Student> Projects { get; }

    public void UpdateName(Name name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
    
    public void UpdateIsOpen(bool isOpen)
    {
        IsOpen = isOpen;
    }
}