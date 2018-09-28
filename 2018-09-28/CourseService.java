package com.mengyunzhi.SpringMvc.service;

import com.mengyunzhi.SpringMvc.entity.Course;

public interface CourseService {
    Iterable getAll();

    Course save(Course course);

    Course get(Long id);
}
