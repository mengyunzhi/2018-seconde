package com.mengyunzhi.SpringMvc.controller;

import com.mengyunzhi.SpringMvc.entity.Student;
import com.mengyunzhi.SpringMvc.repository.StudentRepository;
import com.mengyunzhi.SpringMvc.service.StudentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

/**
 * 学生
 */
@RestController
@RequestMapping("/Student")
public class StudentController {
    @Autowired
    StudentRepository studentRepository;

    @Autowired
    StudentService studentService;

    @GetMapping("/")
    public Iterable<Student> getAll() {
        return studentService.getAll();
    }

    //增加
    @PostMapping("/")
    public Student save(@RequestBody Student student){
         return studentService.save(student);
    }

}
