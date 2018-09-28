package com.mengyunzhi.carboncopies.service;

import com.mengyunzhi.carboncopies.entity.Course;
import com.mengyunzhi.carboncopies.repository.CourseRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Optional;

@Service
public class CourseServiceImpl implements CourseService {
    @Autowired
    CourseRepository courseRepository;
    @Override
    public Iterable<Course> getAll() {
        return courseRepository.findAll();
    }

    @Override
    public Course getById(Long id) {
        return courseRepository.findById(id).get();
    }

    @Override
    public Course update(Long id, Course course) {
        Course updateCourse = courseRepository.findById(id).get();
        updateCourse.setName(course.getName());
        updateCourse.setKlasses(course.getKlasses());
        return courseRepository.save(course);
    }

    @Override
    public void delete(Long id) {
        courseRepository.deleteById(id);
    }

    @Override
    public Course add(Course course) {
        return courseRepository.save(course);
    }
}
