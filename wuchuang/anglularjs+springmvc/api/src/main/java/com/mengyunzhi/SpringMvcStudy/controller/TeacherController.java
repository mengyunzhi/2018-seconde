package com.mengyunzhi.SpringMvcStudy.controller;

import com.mengyunzhi.SpringMvcStudy.service.TeacherService;
import com.mengyunzhi.SpringMvcStudy.entity.Teacher;
import com.mengyunzhi.SpringMvcStudy.repository.TeacherRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController // 声明一个控制器
@RequestMapping("/Teacher") // 声明一个路由地址
public class TeacherController {
    @Autowired
    TeacherRepository teacherRepository;
    @Autowired
    TeacherService teacherService; // 教师

    // 新增加一个地址为/Teacher的 Get方法对应的 action
    @GetMapping("")
    public Iterable<Teacher> getAll() {
        Iterable teachers = teacherRepository.findAll();
        return teachers;
    }

    // 新增一个地址为 /Teacher/ 的post方法
    @PostMapping("/")
    public Teacher save(@RequestBody Teacher teacher) {
        teacherRepository.save(teacher);
        return teacher;
    }

    @RequestMapping("/helloWorld") // 声明一个路由地址
    public HelloWorld helloworld() {
        HelloWorld helloWorld = new HelloWorld();
       helloWorld.setName("name");
       helloWorld.setValue("value");
       return helloWorld;
    }

    @PutMapping("/{id}")
    public void update(@PathVariable Long id, @RequestBody Teacher teacher) {
        teacherService.update(id, teacher);
        return;
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        teacherService.delete(id);
    }

    // 使用{id} 来说明将/Teacher/xx 中xx 命名为id
    @GetMapping("/{id}")
    public Teacher get(@PathVariable Long id) {
        Teacher teacher = teacherRepository.findOne(id);
        return teacher ;
    }

    static public class HelloWorld {
        private String name;
        private String value;

        public HelloWorld() {
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public String getValue() {
            return value;
        }

        public void setValue(String value) {
            this.value = value;
        }
    }

}
