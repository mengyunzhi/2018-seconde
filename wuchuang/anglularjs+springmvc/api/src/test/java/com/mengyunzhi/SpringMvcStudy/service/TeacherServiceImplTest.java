package com.mengyunzhi.SpringMvcStudy.service;

import com.mengyunzhi.SpringMvcStudy.entity.Teacher;
import com.mengyunzhi.SpringMvcStudy.repository.TeacherRepository;
import org.junit.Test;

import org.springframework.beans.factory.annotation.Autowired;

import static org.assertj.core.api.Assertions.*;

public class TeacherServiceImplTest extends serviceTest {
    @Autowired
    TeacherService teacherService;
    @Autowired
    TeacherRepository teacherRepository;
    @Test
    public void updateTest() throws Exception {

        // 新建一个教师张三，持久化
        Teacher zsteacher = new Teacher();
        zsteacher.setSex(true);
        zsteacher.setEmail("zsemail");
        zsteacher.setName("张三");
        zsteacher.setUsername("zhangsan");
        teacherRepository.save(zsteacher);
        Long id = zsteacher.getId();
        // 新建一个教师李四
        Teacher lsteacher = new Teacher();
        lsteacher.setSex(false);
        lsteacher.setEmail("lsemail");
        lsteacher.setName("李四");
        lsteacher.setUsername("lisi");
        // 使用李四更新张三
        teacherService.update(id, lsteacher);
        // 断言信息更新成功
        Teacher newteacher = teacherRepository.findOne(id);
        assertThat(newteacher.getName()).isEqualTo("李四");
        assertThat(newteacher.getUsername()).isEqualTo("lisi");
        assertThat(newteacher.getEmail()).isEqualTo("lsemail");
        assertThat(newteacher.isSex()).isFalse();
    }

    @Test
    public void deleteTest() {
        // 添加数据
        Teacher teacher = new Teacher();
        teacherRepository.save(teacher);
        Long id = teacher.getId();
        // 删除数据
        teacherService.delete(id);
        // 删除成功
        Teacher newTeacher = teacherRepository.findOne(id);
        assertThat(newTeacher).isNull();
    }
}