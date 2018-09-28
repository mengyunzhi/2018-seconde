package com.mengyunzhi.carboncopies.controller;

import com.mengyunzhi.carboncopies.entity.Course;
import com.mengyunzhi.carboncopies.entity.Klass;
import com.mengyunzhi.carboncopies.repository.CourseRepository;
import com.mengyunzhi.carboncopies.repository.KlassRepository;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;


import java.util.ArrayList;
import java.util.List;

import static org.junit.Assert.*;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

public class CourseControllerTest extends ControllerTest{
    @Autowired
    MockMvc mockMvc;
    @Autowired
    CourseRepository courseRepository;
    @Autowired
    KlassRepository klassRepository;
    String baseUrl = "/course/";
    @Test
    public void getAllTest() throws Exception {
        Course course = new Course();
        course.setName("course");
        courseRepository.save(course);
        String getAllUrl = this.baseUrl;
        this.mockMvc.perform(get(getAllUrl))
                .andExpect(status().isOk());
    }
    @Test
    public void getByIdTest() throws Exception {
        Course course  = new Course();
        List<Klass> klasses = new ArrayList<Klass>();
        Klass klass = new Klass();
        klass.setName("klass");
        klasses.add(klass);
        course.setKlasses(klasses);
        courseRepository.save(course);
        Long id = course.getId();

        String getUrl = this.baseUrl + id.toString();
        this.mockMvc.perform(get(getUrl))
                .andExpect(status().isOk())
                .andDo(print());
    }
    @Test
    public void addTest() throws Exception {
        String postUrl = this.baseUrl;
        this.mockMvc.perform(post(postUrl)
            .contentType(MediaType.APPLICATION_JSON_UTF8)
            .content("{\"name\": \"newCourse\",\"klasses\":[{\"name\": \"newKlass\"}]}"))
                .andExpect(status().isOk());
    }
    @Test
    public void updateTest() throws Exception {
        Course course = new Course();
        courseRepository.save(course);
        Long id = course.getId();
        String updateUrl = this.baseUrl + id.toString();

        this.mockMvc.perform(put(updateUrl)
            .contentType(MediaType.APPLICATION_JSON_UTF8)
            .content("{\"name\":\"course\"}"))
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.jsonPath("$.name").value("course"));
    }
    @Test
    public void deleteTest() throws Exception {
        Course course = new Course();
        courseRepository.save(course);
        Long id = course.getId();

        String deleteUrl  = this.baseUrl + id.toString();

        this.mockMvc.perform(delete(deleteUrl))
                .andExpect(status().isOk());
    }
}