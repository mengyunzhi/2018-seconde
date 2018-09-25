package com.mengyunzhi.SpringMvc.service;

import com.mengyunzhi.SpringMvc.entity.Teacher;
import com.mengyunzhi.SpringMvc.repository.TeacherRepository;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;

import static org.assertj.core.api.Assertions.assertThat;


public class TeacherServiceImplTest  extends ServiceTest{
    @Autowired
    TeacherService teacherService;
    @Autowired
    TeacherRepository teacherRepository;
    @Test
    public void updateTest() {

        //新建一个张三教师，并持久化
        Teacher zhangsan = new Teacher();
        zhangsan.setUsername("zhangsan");
        zhangsan.setName("张三");
        zhangsan.setEmail("zhangsan@yunzhiclub.com");
        zhangsan.setSex(true);
        teacherRepository.save(zhangsan);

        //新建一个李四教师
        Teacher lisi = new Teacher();
        lisi.setUsername("lisi");
        lisi.setName("李四");
        lisi.setEmail("lisi@yunzhiclub.com");
        lisi.setSex(false);
        //用李四的信息更新张三的信息
        teacherService.update(zhangsan.getId(),lisi);

        //断言更新成功
        Teacher newTeacher = teacherRepository.findOne(zhangsan.getId());
        assertThat(newTeacher.getUsername()).isEqualTo("lisi");
        assertThat(newTeacher.getName()).isEqualTo("李四");
        assertThat(newTeacher.getEmail()).isEqualTo("lisi@yunzhiclub.com");
        assertThat(newTeacher.isSex()).isFalse();
    }
    @Test
    public void deleteTest() {

        //添加一个数据
        Teacher teacher = new Teacher();
        teacherRepository.save(teacher);

        //调用删除方法，删除数据
        teacherService.delete(teacher.getId());

        //断言删除成功
        Teacher newTeacher = teacherRepository.findOne(teacher.getId());
        assertThat(newTeacher).isNull();
    }
}