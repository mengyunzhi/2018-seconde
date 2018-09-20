package com.mengyunzhi.SpringMvc.controller;

import com.mengyunzhi.SpringMvc.entity.Teacher;
import com.mengyunzhi.SpringMvc.repository.TeacherRepository;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;

import static org.assertj.core.api.Assertions.assertThat;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;



public class TeacherControllerTest extends controllerTest{

    @Autowired
    private MockMvc mockMvc;  //模拟进行REST请求
    @Autowired
    TeacherRepository teacherRepository;

    @Test
    public void getTest() throws Exception {
        //创建一条数据
        Teacher teacher = new Teacher();
        teacher.setUsername("username");
        teacher.setName("name");
        teacher.setEmail("email");
        teacher.setSex(true);
        teacherRepository.save(teacher);

        String url = "/Teacher/" + String.valueOf(teacher.getId());
        this.mockMvc
                .perform(get(url)) //用get方法来请求url
                .andDo(print()) //请求后，打印请求的返回数据
                .andExpect(status().isOk());   //断言返回的状态为真
    }

    @Test
    public void updateTest() throws Exception {
        //添加测试数据
        //实例化teacher，并持久化
        Teacher teacher = new Teacher();
        // 更新这个持久化的Teacher
        teacherRepository.save(teacher);
        String url = "/Teacher/" + teacher.getId();
        this.mockMvc
                .perform(put(url)       //用put方法来请求url
                        .contentType(MediaType.APPLICATION_JSON_UTF8)
                        .content("{}"))
                .andDo(print()) //请求后，打印请求的返回数据
                .andExpect(status().isOk());   //断言返回的状态为真

    }

    @Test
    public void deleteTest() throws Exception {

        //添加一个数据
        Teacher teacher = new Teacher();
        teacherRepository.save(teacher);
        Long id = teacher.getId();

        //调用删除方法，删除数据
        String url = "/Teacher/" + teacher.getId();
        this.mockMvc
                .perform(delete(url)       //用delete方法来请求url
                        .contentType(MediaType.APPLICATION_JSON_UTF8))
                .andDo(print()) //请求后，打印请求的返回数据
                .andExpect(status().isOk());   //断言返回的状态为真

        //断言删除成功
        Teacher newTeacher = teacherRepository.findOne(teacher.getId());
        assertThat(newTeacher).isNull();
    }
}