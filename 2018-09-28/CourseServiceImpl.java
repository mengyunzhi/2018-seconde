package com.mengyunzhi.SpringMvc.service;

import com.mengyunzhi.SpringMvc.entity.Course;
import com.mengyunzhi.SpringMvc.repository.CourseRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class CourseServiceImpl implements CourseService {
    @Autowired
    CourseRepository courseRepository;
    @Override
    public Iterable getAll() {
        return courseRepository.findAll();
    }

    @Override
    public Course save(Course course) {
        return courseRepository.save(course);
    }

    @Override
    public Course get(Long id) {
        return  courseRepository.findOne(id);
    }
}
