package com.mengyunzhi.carboncopies.service;

import com.mengyunzhi.carboncopies.entity.Student;

public interface StudentService {
    Iterable<Student> getAllStudent();
    Student getStudent(Long id);
    Student addStudent(Student student);
    void deleteStudent(Long id);
    Student updateStudent(Long id, Student student);
}
