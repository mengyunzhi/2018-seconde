package com.mengyunzhi.carboncopies.service;

import com.mengyunzhi.carboncopies.entity.Course;

public interface CourseService {
    Iterable<Course> getAll();
    Course getById(Long id);
    Course update(Long id, Course course);
    void delete(Long id);
    Course add(Course course);
}
