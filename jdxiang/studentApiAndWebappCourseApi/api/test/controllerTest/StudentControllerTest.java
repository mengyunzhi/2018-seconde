package com.mengyunzhi.carboncopies.controller;

import com.mengyunzhi.carboncopies.entity.Student;
import com.mengyunzhi.carboncopies.repository.StudentRepository;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;

import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

public class StudentControllerTest extends ControllerTest{
    @Autowired
    MockMvc mockMvc;
    @Autowired
    StudentRepository studentRepository;
    String url = "/student/";
    @Test
    public void getAllStudent() throws Exception {
        String getAllUrl = this.url ;
        Student student = new Student();
        studentRepository.save(student);
        this.mockMvc.perform(get(getAllUrl))
                .andDo(print())
                .andExpect(status().isOk());
    }

    @Test
    public void getStudent() throws Exception {
        String studentName = "student Name";
        Student student = new Student();
        student.setName(studentName);
        studentRepository.save(student);
        Long id = student.getId();
        String getUrl = this.url + id.toString();

        this.mockMvc.perform(get(getUrl))
                .andDo(print())
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.jsonPath("$.name").value(studentName));
    }
    @Test
    public void updateStudent() throws Exception {
        Student student1 = new Student();
        Student student2 = new Student();
        student1.setName("student1");
        student2.setName("student2");
        studentRepository.save(student1);
        Long id = student1.getId();
        String updateUrl = this.url + id.toString();

        this.mockMvc.perform(put(updateUrl)
                .contentType(MediaType.APPLICATION_JSON_UTF8)
                .content("{\"name\": \"student2\"}"))
                .andDo(print())
                .andExpect(MockMvcResultMatchers.jsonPath("$.name").value("student2"))
                .andExpect(status().isOk());
    }
    @Test
    public void deleteTest() throws Exception {
        Student student = new Student();
        studentRepository.save(student);
        Long id = student.getId();
        String deleteUrl = this.url + id.toString();

        this.mockMvc.perform(delete(deleteUrl))
                .andExpect(status().is(202));
    }
    @Test
    public void addStudent() throws Exception {
        String addUrl = this.url;
        Student student = new Student();
        student.setName("student");

        this.mockMvc.perform(post(addUrl)
                .contentType(MediaType.APPLICATION_JSON_UTF8)
                .content("{\"name\": \"zhansan\"}"))
                .andExpect(status().is(201))
                .andExpect(MockMvcResultMatchers.jsonPath("$.name").value("zhansan"));
    }
}