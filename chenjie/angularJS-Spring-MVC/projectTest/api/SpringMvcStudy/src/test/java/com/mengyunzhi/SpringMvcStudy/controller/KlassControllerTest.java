package com.mengyunzhi.SpringMvcStudy.controller;

import com.mengyunzhi.SpringMvcStudy.entity.Klass;
import com.mengyunzhi.SpringMvcStudy.repository.KlassRepository;
import com.mengyunzhi.SpringMvcStudy.repository.TeacherRespository;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;
import java.util.logging.Logger;
import static org.assertj.core.api.Assertions.assertThat;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

public class KlassControllerTest extends ControllerTest {
    private final static Logger logger = Logger.getLogger(KlassControllerTest.class.getName());
    static final String url = "/Klass/";

    @Autowired
    private MockMvc mockMvc; //模拟进行REST请求

    @Autowired
    KlassRepository klassRepository;

    @Autowired
    TeacherRespository teacherRespository;

    @Test
    public void saveTest() throws Exception {
        String url = "/Klass/";
        this.mockMvc
                .perform(post(url)
                        .content("{}")
                        .header("content-type", MediaType.APPLICATION_JSON_UTF8))
                .andDo(print())
                .andExpect(status().is(201));
    }

    @Test
    public void getAllTest() throws Exception {
        this.mockMvc
                .perform(get(url)
                        .header("content-type", MediaType.APPLICATION_JSON_UTF8))
                .andDo(print())
                .andExpect(status().isOk());
    }

    @Test
    public void getByIdTest() throws Exception {
        //持久化一个实体到数据表
        Klass klass = new Klass();
        //为这个班级设置一个随机字符串
        String name = "asdasdasdasd";
        klass.setName(name);
        klassRepository.save(klass);

        //获取这个持久化的实体
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
        //持久化一个实体到数据表
        Klass klass = new Klass();
        klassRepository.save(klass);

        //发起http请求，来更新这个实体
        String newName = "123";
        String putUrl = url + klass.getId().toString();

        this.mockMvc
                .perform(MockMvcRequestBuilders.put(putUrl)
                        .header("content-type", MediaType.APPLICATION_JSON_UTF8)
                        .content("{\"name\":\"" + newName + "\"}"))
                .andExpect(status().isOk());

        // 断言更新成功(去数据库里找一个这个实体，并获取name，看是否成功)
        Klass newKlass = klassRepository.findOne(klass.getId());
        assertThat(newKlass.getName()).isEqualTo(newName);
    }


    @Test
    public void deleteTest() throws Exception {
        logger.info("new 一个对象");
        Klass klass = new Klass();
        klassRepository.save(klass);

        String deleteUrl = url + klass.getId().toString();
        logger.info("调用C层的删除方法");
        this.mockMvc
                .perform(MockMvcRequestBuilders.delete(deleteUrl)
                        .header("content-type", MediaType.APPLICATION_JSON_UTF8))
                .andExpect(status().isOk());

        logger.info("断言删除是否成功");
        Klass newKlass = klassRepository.findOne(klass.getId());
        assertThat(newKlass).isNull();
    }
}