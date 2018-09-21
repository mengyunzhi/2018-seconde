package com.mengyunzhi.carboncopies.controller;

import com.mengyunzhi.carboncopies.entity.Klass;
import com.mengyunzhi.carboncopies.repository.KlassRepository;

import com.mengyunzhi.carboncopies.service.KlassService;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;;
import static org.assertj.core.api.Assertions.assertThat;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

public class KlassControllerTest extends ControllerTest {
    final String url = "/klass/";
    @Autowired
    KlassRepository klassRepository;
    @Autowired
    KlassService klassService;
    @Autowired
    MockMvc mockMvc;

    @Test
    public void getKlass() throws Exception {
        Klass klass = new Klass();

        klass.setName("zhangsan");
        klassRepository.save(klass);
        Long id = klass.getId();
        String url = this.url + "getKlass" + id;
        this.mockMvc
                .perform(get(url))
                .andExpect(MockMvcResultMatchers.jsonPath("$.name").value("zhangsan"))
                .andExpect(status().isOk());
    }

    @Test
    public void getAll() throws Exception {
        Klass klass1 = new Klass();
        Klass klass2 = new Klass();
        klassRepository.save(klass1);
        klassRepository.save(klass2);
        String url = this.url + "getAll";
        this.mockMvc
                .perform(get(url))
                .andDo(print())
                .andExpect(status().isOk());
    }

    @Test
    public void updata() throws Exception {
        Klass klass = new Klass();
        klass.setName("zhangsan");
        klassRepository.save(klass);
        String url = this.url + "/updata" + klass.getId().toString();
        this.mockMvc
                .perform(put(url).contentType(MediaType.APPLICATION_JSON_UTF8)
                        .content("{\"name\": \"newKlass\"}"))
                .andExpect(status().is(202))
                .andExpect(MockMvcResultMatchers.jsonPath("$.name").value("newKlass"));

    }
    @Test
    public void addTest() throws Exception {
        String name = "newKlass";
        String url = this.url + "add";
        this.mockMvc
                .perform(post(url).contentType(MediaType.APPLICATION_JSON_UTF8)
                .content("{\"name\": \"" + name + "\"}"))
                .andExpect(status().is(201))
                .andExpect(MockMvcResultMatchers.jsonPath("$.name").value(name));
    }
    @Test
    public void deleteTest() throws Exception {
        Klass klass = new Klass();
        klassRepository.save(klass);
        Long id = klass.getId();
        String url = this.url + "delete" + id.toString();
        this.mockMvc
                .perform(delete(url))
                .andExpect(status().is(200));

        assertThat(klassRepository.findById(id)).isEmpty();
    }

    @Test
    public void getByPage() throws Exception {
        String pageUrl = this.url + "getByPage";
        this.mockMvc
                .perform(get(pageUrl).
                        param("page","1").
                        param("size","2"))
                .andExpect(status().isOk())
                .andDo(print());
    }
}