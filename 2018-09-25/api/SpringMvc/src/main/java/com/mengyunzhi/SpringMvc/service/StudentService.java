package com.mengyunzhi.SpringMvc.service;

import com.mengyunzhi.SpringMvc.entity.Student;

public interface StudentService {

    Iterable<Student> getAll();

   Student save(Student student);
}
