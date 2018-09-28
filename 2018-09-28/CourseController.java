package com.mengyunzhi.SpringMvc.controller;


import com.mengyunzhi.SpringMvc.entity.Course;
import com.mengyunzhi.SpringMvc.repository.CourseRepository;
import com.mengyunzhi.SpringMvc.service.CourseService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;


@RestController
@RequestMapping("/Course")
public class CourseController  {

    @Autowired
    CourseRepository courseRepository;

    @Autowired
    CourseService courseService;

    @GetMapping("/")
    public Iterable<Course> getAll(){
       Iterable courses = courseService.getAll();
       return  courses;
    }

    @PostMapping("/")
    public Course save(@RequestBody Course course){
        return courseService.save(course);
    }

    @GetMapping("/{id}")
    public Course get(@PathVariable Long id){
        return courseService.get(id);
    }

}
