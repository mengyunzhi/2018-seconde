package com.mengyunzhi.SpringMvc.repository;

import com.mengyunzhi.SpringMvc.entity.Course;
import org.springframework.data.repository.CrudRepository;

public interface CourseRepository extends CrudRepository<Course, Long> {
}
