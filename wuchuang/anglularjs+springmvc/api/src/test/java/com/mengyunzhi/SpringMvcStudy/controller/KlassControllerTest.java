package com.mengyunzhi.SpringMvcStudy.controller;

import com.mengyunzhi.SpringMvcStudy.entity.Klass;
import com.mengyunzhi.SpringMvcStudy.repository.KlassRepository;
import org.apache.log4j.Logger;
import org.junit.Test;

import org.springframework.beans.factory.annotation.Autowired;

import org.springframework.http.MediaType;

import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;

import static org.assertj.core.api.AssertionsForInterfaceTypes.assertThat;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;


public class KlassControllerTest extends controllerTest {
    private final static Logger logger = Logger.getLogger(KlassControllerTest.class.getName());
    static final String url = "/Klass/";

    @Autowired
    private MockMvc mockMvc;
    @Test
    public void saveTest() throws Exception {
        this.mockMvc
                .perform(post(url)
                        .header("content-type", MediaType.APPLICATION_JSON_UTF8)
                        .content("{}"))
                .andExpect(status().is(201));
    }

    @Test
    public void getAll() throws Exception {
        this.mockMvc
                .perform(get(url)
                        .header("content-type", MediaType.APPLICATION_JSON_UTF8)
                        )
                .andExpect(status().isOk());
    }

    @Autowired private KlassRepository klassRepository;
    @Test
    public void getByIdTest() throws Exception {
        // 持久化实体
        Klass klass = new Klass();
        String name = "sdfsdf";
        klass.setName(name);
        klassRepository.save(klass);

        String getUrl = url + klass.getId().toString();
        this.mockMvc
                .perform(get(getUrl)
                .header("content-type", MediaType.APPLICATION_JSON_UTF8))
                .andDo(print())
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.jsonPath("$.name").value(name));

    }

    @Test
    public void updateTest() throws Exception {
        // 建立一个实体
        Klass klass = new Klass();
        klassRepository.save(klass);
        String newName = "123";
        // 更新这个实体
        String putUrl = url + klass.getId().toString();
        this.mockMvc
                .perform(put(putUrl)
                        .header("content-type", MediaType.APPLICATION_JSON_UTF8)
                .content("{\"name\":\""+ newName +"\"}"))
                .andExpect(status().isOk());
        // 更新成功
        Klass newKlass = klassRepository.findOne(klass.getId());
        assertThat(newKlass.getName()).isEqualTo("123");

    }

    @Test
    public void deleteTest() throws Exception {
        Klass klass = new Klass();
        klassRepository.save(klass);

        String deleteUrl = url + klass.getId().toString();
        this.mockMvc
                .perform(delete(deleteUrl)
                        .header("content-type", MediaType.APPLICATION_JSON_UTF8))
                .andExpect(status().is(204));

        Klass newKlass = klassRepository.findOne(klass.getId());
        assertThat(newKlass).isNull();

    }
}