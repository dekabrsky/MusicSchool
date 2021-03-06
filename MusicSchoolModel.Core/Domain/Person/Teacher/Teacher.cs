using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicSchoolModel.Core.Domain.Abstractions;
using MusicSchoolModel.Core.Domain.Common.ValueObjects;

namespace MusicSchoolModel.Core.Domain.Teacher;

public class Teacher : Entity, IEntityTypeConfiguration<Teacher>
{
    public Teacher() { }

    public Teacher(PersonName name, long courseId)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        CourseId = courseId;
    }

    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("Teachers");

        builder.OwnsOne(
            x => x.Name,
            x => { x.Property(z => z.FullName).HasColumnName("Name"); });
        builder.OwnsOne(
            x => x.Course,
            x => { x.Property(z => z.Name).HasColumnName("Course"); });
    }

    public PersonName Name { get; private set; }

    public long CourseId { get; set; }
    public Course.Course Course { get; set; }

    public void UpdateName(PersonName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void UpdateCourse(Course.Course course)
    {
        Course = course ?? throw new ArgumentNullException(nameof(course));
    }
}
