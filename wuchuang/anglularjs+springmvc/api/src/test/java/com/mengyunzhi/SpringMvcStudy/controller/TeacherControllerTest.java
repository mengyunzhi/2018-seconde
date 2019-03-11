package com.mengyunzhi.SpringMvcStudy.controller;

import com.mengyunzhi.SpringMvcStudy.entity.Teacher;
import com.mengyunzhi.SpringMvcStudy.repository.TeacherRepository;
import org.junit.Test;

import org.springframework.beans.factory.annotation.Autowired;

import org.springframework.http.MediaType;

import org.springframework.test.web.servlet.MockMvc;

import static org.assertj.core.api.Assertions.assertThat;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

public class TeacherControllerTest extends controllerTest {
    @Autowired
    private MockMvc mockMvc;    // 模拟进行REST请求
    @Autowired
    TeacherRepository teacherRepository;

    @Test
    public void getAllTest() throws Exception {

        String url = "/Teacher";
        this.mockMvc
                .perform(get(url))
                .andDo(print())
                .andExpect(status().isOk());
    }
    @Test
    public void getTest() throws Exception {
        // 创建一条数据
        Teacher teacher = new Teacher();
        teacher.setUsername("username");
        teacher.setName("name");
        teacher.setEmail("email");
        teacher.setSex(true);
        teacherRepository.save(teacher);
        String url = "/Teacher/" +String.valueOf(teacher.getId());
        this.mockMvc
                .perform(get(url))
                .andDo(print())
                .andExpect(status().isOk());
    }

    @Test
    public void updateTest() throws Exception {
        // 添加测试数据
        // 实例化Teacher
        Teacher teacher = new Teacher();
        teacherRepository.save(teacher);

        String url = "/Teacher/" + teacher.getId();
        this.mockMvc
                .perform(put(url)
                        .contentType(MediaType.APPLICATION_JSON_UTF8)
                        .content("{}"))
                .andDo(print())
                .andExpect(status().isOk());
    }

    @Test
    public void deleteTest() throws Exception {
        // 添加数据
        Teacher teacher = new Teacher();
        teacherRepository.save(teacher);
        Long id = teacher.getId();
        // 删除数据
        String url = "/Teacher/" + teacher.getId();
        this.mockMvc
                .perform(delete(url)
                        .contentType(MediaType.APPLICATION_JSON_UTF8))
                .andDo(print())
                .andExpect(status().isOk());
        // 删除成功
        Teacher newTeacher = teacherRepository.findOne(id);
        assertThat(newTeacher).isNull();
    }

}