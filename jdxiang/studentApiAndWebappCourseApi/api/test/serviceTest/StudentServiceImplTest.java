package com.mengyunzhi.carboncopies.service;

import com.mengyunzhi.carboncopies.entity.Klass;
import com.mengyunzhi.carboncopies.entity.Student;
import com.mengyunzhi.carboncopies.repository.KlassRepository;
import com.mengyunzhi.carboncopies.repository.StudentRepository;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.List;
import java.util.Optional;

import static org.assertj.core.api.Assertions.assertThat;

public class StudentServiceImplTest extends ServiceTest{
    @Autowired
    KlassRepository klassRepository;
    @Autowired
    StudentRepository studentRepository;
    @Autowired StudentService studentService;
    @Test
    public void getAllStudent() {
        Klass klass = new Klass();
        klass.setName("test");
        klassRepository.save(klass);

        Student student1 = new Student();
        student1.setKlass(klass);
        student1.setName("student1");

        Student student2 = new Student();
        student2.setKlass(klass);
        student2.setName("student2");

        studentRepository.save(student1);
        studentRepository.save(student2);

        List<Student> students = (List<Student>)studentService.getAllStudent();
        assertThat(students.size()).isEqualTo(2);
        assertThat(students.get(0).getKlass()).isEqualTo(klass);
        assertThat(students.get(1).getKlass()).isEqualTo(klass);
        assertThat(students.get(0)).isEqualTo(student1);
        assertThat(students.get(1)).isEqualTo(student2);
    }

    @Test
    public void getStudent() {
        String studentName = "studentName";
        Student student = new Student();
        student.setName(studentName);
        studentRepository.save(student);
        Long id = student.getId();

        Student student1 = studentService.getStudent(id);
        assertThat(student1.getName()).isEqualTo(studentName);
    }

    @Test
    public void addStudent() {
        Klass klass = new Klass();
        String klassName = "klassname";
        klass.setName(klassName);
        klassRepository.save(klass);

        Student student = new Student();
        student.setKlass(klass);
        studentService.addStudent(student);

        Student student2 = studentRepository.findById(student.getId()).get();
        assertThat(student2.getKlass()).isEqualTo(klass);
    }

    @Test
    public void deleteStudent() {
        Student student = new Student();
        studentRepository.save(student);

        Long id = student.getId();
        studentService.deleteStudent(id);

        Optional<Student> deleteStudent = studentRepository.findById(id);
        assertThat(deleteStudent).isEmpty();
    }

    @Test
    public void updateStudent() {
        Klass klass1 = new Klass();
        Klass klass2 = new Klass();
        klassRepository.save(klass1);
        klassRepository.save(klass2);

        Student student1 = new Student();
        Student student2 = new Student();
        student1.setKlass(klass1);
        student2.setKlass(klass2);
        studentRepository.save(student1);
        Long id = student1.getId();

        studentService.updateStudent(id, student2);
        Student newStudent = studentRepository.findById(id).get();

        assertThat(newStudent.getKlass()).isEqualTo(klass2);
    }
}