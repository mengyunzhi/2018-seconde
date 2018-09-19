package com.mengyunzhi.SpringMvcStudy;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

/**
 * @author 某杰 on 2018/09/11
 */
@RestController//声明一个控制器
@RequestMapping("/Teacher")//声明一个路由地址
public class TeacherController {
     @Autowired TeacherRespository teacherRespository; //自动装置一个实例化的TeacherTrspository

    //新增一个地址为：/Teacher的GET方法对应的action
    @GetMapping("")
    public Iterable<Teacher> getAll() {
        Iterable teachers =  teacherRespository.findAll();
        return teachers;
    }

    //新增一个地址为：/Teacher/ 的post方法
    @PostMapping("/")
    public Teacher save(@RequestBody Teacher teacher) {
        teacherRespository.save(teacher);
        return teacher;
    }

    //使用{id}说明，将/Teacher/xxx 中的xxx命名为id
    @GetMapping("/{id}")
    public Teacher get(@PathVariable Long id) {
        Teacher teacher = teacherRespository.findOne(id);
        return teacher;
    }

    //定义一个put路由来更新数据
    @PutMapping("/{id}")
    public void update(@PathVariable Long id, @RequestBody Teacher teacher) {
        return;
    }

}
