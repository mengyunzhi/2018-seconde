package com.mengyunzhi.SpringMvc.service;

import com.mengyunzhi.SpringMvc.entity.Student;
import com.mengyunzhi.SpringMvc.repository.StudentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class StudentServiceImpl implements StudentService {
    @Autowired
    StudentRepository studentRepository;

    @Override
    public Iterable<Student> getAll() {
        return studentRepository.findAll();
    }

    @Override
    public Student save(Student student) {
        return studentRepository.save(student);
    }

    @Override
    public Student get(Long id) {
        return studentRepository.findOne(id);
    }

    @Override
    public void update(Long id, Student newstudent) {

        Student oldstudent = studentRepository.findOne(id);

        if (oldstudent != null) {
            oldstudent.setEmail(newstudent.getEmail());
            oldstudent.setName(newstudent.getName());
            oldstudent.setSex(newstudent.isSex());
            oldstudent.setKlass(newstudent.getKlass());

            studentRepository.save(oldstudent);
        }
    }

    @Override
    public void delete(Long id) {
        studentRepository.delete(id);
    }

}
