package com.mengyunzhi.SpringMvc.controller;

import com.mengyunzhi.SpringMvc.entity.Student;
import com.mengyunzhi.SpringMvc.repository.StudentRepository;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.web.servlet.MockMvc;

import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

public class StudentControllerTest extends controllerTest {
    static final String url = "/Student/";

    @Autowired
    private StudentRepository studentRepository;

    @Autowired
    private MockMvc mockMvc;


    @Test
    public void getTest() throws Exception {

        Student student = new Student();
        student.setName("name");
        student.setEmail("email");
        student.setSex(true);
        studentRepository.save(student);

        //获取这个持久化的实体

        String geturl = url + String.valueOf(student.getId());
        this.mockMvc
                .perform(get(geturl))
                .andDo(print())
                .andExpect(status().isOk());
    }
}
