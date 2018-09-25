package com.mengyunzhi.SpringMvc.controller;

import com.mengyunzhi.SpringMvc.service.TeacherService;
import com.mengyunzhi.SpringMvc.entity.Teacher;
import com.mengyunzhi.SpringMvc.repository.TeacherRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController                         //声明一个控制器
@RequestMapping("/Teacher")         //声明一个路由地址
public class TeacherController {
    @Autowired
    TeacherRepository teacherRepository;//自动装配一个实例化的TeacherRepository
    @Autowired
    TeacherService teacherService; //教师

    //新增一个地址为：/Teacher 的GET方法对应的action
    //获取教师所有信息
    @GetMapping("")
    public Iterable<Teacher> getAll() {
        Iterable teachers = teacherRepository.findAll();
        return teachers;
    }

    //增加
    //新增一个地址为：/Teacher/ 的post方法
    @PostMapping("/")
    public Teacher save(@RequestBody Teacher teacher) {
        teacherRepository.save(teacher);
        return teacher;
    }

    //查看
    @GetMapping("/{id}")
    public Teacher get(@PathVariable Long id) {
        Teacher teacher = teacherRepository.findOne(id);
        return teacher;
    }

    //编辑
    @PutMapping("/{id}")
    public void update(@PathVariable Long id, @RequestBody Teacher teacher) {
        teacherService.update(id,teacher);
    }

    //删除
    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id){
        teacherService.delete(id);
    }
}

