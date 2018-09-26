package com.mengyunzhi.SpringMvc.service;

import com.mengyunzhi.SpringMvc.entity.Student;

public interface StudentService {

    Iterable<Student> getAll();

    Student save(Student student);

    Student get(Long id);

    void update(Long id, Student student);

    void delete(Long id);
}
