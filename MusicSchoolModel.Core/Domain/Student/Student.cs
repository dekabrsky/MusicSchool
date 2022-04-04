using MusicSchoolModel.Core.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicSchoolModel.Core.Student.Student.ValueObjects;

namespace Programming.Core.Domain.Student;

public class Student : Entity, IEntityTypeConfiguration<Student>
{
    public Student() { }
    
    public StudentName Name { get; private set; }

    public long? TeacherId { get; set; }
    // public Teacher.Teacher Teacher { get; set; }

    public Student(StudentName studentName, long? teacherId = null)
    {
        Name = studentName ?? throw new ArgumentNullException(nameof(studentName));

        TeacherId = teacherId;
    }

    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        builder.OwnsOne(x => x.Name, x =>
        {
            x.OwnsOne(
                z => z.FirstName,
                z =>
                {
                    z.Property(n => n.Value).HasColumnName("FirstName");
                });
            x.OwnsOne(
                z => z.LastName,
                z =>
                {
                    z.Property(n => n.Value).HasColumnName("LastName");
                });
        });
    }

    public void UpdateName(StudentName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}