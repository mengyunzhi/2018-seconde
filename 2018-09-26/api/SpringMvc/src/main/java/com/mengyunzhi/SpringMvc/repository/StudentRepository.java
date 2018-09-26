package com.mengyunzhi.SpringMvc.repository;

import com.mengyunzhi.SpringMvc.entity.Student;
import org.springframework.data.repository.CrudRepository;

public interface StudentRepository extends CrudRepository<Student, Long> {
}
