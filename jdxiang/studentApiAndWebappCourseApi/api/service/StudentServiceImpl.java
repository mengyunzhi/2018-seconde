package com.mengyunzhi.carboncopies.service;

import com.fasterxml.jackson.databind.annotation.JsonAppend;
import com.mengyunzhi.carboncopies.entity.Student;
import com.mengyunzhi.carboncopies.repository.StudentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class StudentServiceImpl implements StudentService {
    @Autowired
    StudentRepository studentRepository;
    @Override
    public Iterable<Student> getAllStudent() {
        return studentRepository.findAll();
    }

    @Override
    public Student getStudent(Long id) {
        return studentRepository.findById(id).get();
    }

    @Override
    public Student addStudent(Student student) {
        return studentRepository.save(student);
    }

    @Override
    public void deleteStudent(Long id) {
        studentRepository.deleteById(id);
    }

    @Override
    public Student updateStudent(Long id, Student student) {
        Student updateStudent =studentRepository.findById(id).get();

        updateStudent.setKlass(student.getKlass());
        updateStudent.setName(student.getName());
        updateStudent.setSchoolNumber(student.getSchoolNumber());
        updateStudent.setSex(student.isSex());

        return studentRepository.save(updateStudent);
    }
}
