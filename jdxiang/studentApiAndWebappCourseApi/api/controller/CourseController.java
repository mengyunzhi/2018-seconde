package com.mengyunzhi.carboncopies.controller;

import com.mengyunzhi.carboncopies.entity.Course;
import com.mengyunzhi.carboncopies.service.CourseService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/course")
public class CourseController {
    @Autowired
    CourseService courseService;

    @GetMapping("/")
    public Iterable<Course> getAll() {
        return courseService.getAll();
    }
    @GetMapping("/{id}")
    public Course getById(@PathVariable Long id) {
        return courseService.getById(id);
    }
    @PostMapping("/")
    public Course add(@RequestBody Course course) {
        return courseService.add(course);
    }
    @PutMapping("/{id}")
    public Course update(@PathVariable Long id, @RequestBody Course course) {
        return courseService.update(id, course);
    }
    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        courseService.delete(id);
    }
}
