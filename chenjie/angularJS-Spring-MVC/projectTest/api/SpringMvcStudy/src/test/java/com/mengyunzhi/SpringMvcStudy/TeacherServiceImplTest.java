package com.mengyunzhi.SpringMvcStudy;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import static org.assertj.core.api.Assertions.assertThat;


/**
 *  @author 某杰
 */
@RunWith(SpringRunner.class)
@SpringBootTest
public class TeacherServiceImplTest {
    @Autowired TeacherService teacherService;
    @Autowired TeacherRespository teacherRespository; //教师表
    @Test
    public void kupdateTest() throws Exception {
        // 新建一个教师张三，并持久化
        Teacher zhangsanTeacher = new Teacher();
        zhangsanTeacher.setName("张三");
        zhangsanTeacher.setUsername("zhangsan");
        zhangsanTeacher.setSex(true);
        zhangsanTeacher.setEmail("zhangsan@yunzhiclub.com");
        teacherRespository.save(zhangsanTeacher);
        Long id = zhangsanTeacher.getId();

        // 新建一个教师李四
        Teacher lisiTeacher = new Teacher();
        lisiTeacher.setName("李四");
        lisiTeacher.setUsername("lisi");
        lisiTeacher.setSex(false);
        lisiTeacher.setEmail("lisi@yunzhiclub.com");

        // 使用李四更新张三
        teacherService.update(id, lisiTeacher);

        //断言更新信息成功
        Teacher newTeacher = teacherRespository.findOne(id);
        assertThat(newTeacher.getName()).isEqualTo("李四");
        assertThat(newTeacher.getUsername()).isEqualTo("lisi");
        assertThat(newTeacher.getEmail()).isEqualTo("lisi@yunzhiclub.com");

    }
}