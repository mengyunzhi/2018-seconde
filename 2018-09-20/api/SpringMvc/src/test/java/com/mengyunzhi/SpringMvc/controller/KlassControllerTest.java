package com.mengyunzhi.SpringMvc.controller;

import com.mengyunzhi.SpringMvc.entity.Klass;
import com.mengyunzhi.SpringMvc.repository.KlassRepository;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;

import static org.assertj.core.api.AssertionsForInterfaceTypes.assertThat;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;


public class KlassControllerTest extends controllerTest {
    static final String url = "/Klass/";

    @Autowired
    private MockMvc mockMvc;  //模拟进行REST请求

    //增加方法测试
    @Test
    public void saveTest() throws Exception {

        this.mockMvc
                .perform(post(url)
                        .contentType(MediaType.APPLICATION_JSON_UTF8)
                        .content("{}"))
                .andDo(print())
                .andExpect(status().is(201));
    }

    @Test
    public void getAll() throws Exception {

        this.mockMvc
                .perform(get(url)
                        .contentType(MediaType.APPLICATION_JSON_UTF8)
                        .content("{}"))
                .andDo(print())
                .andExpect(status().isOk());
    }

    @Autowired
    private KlassRepository klassRepository;

    @Test
    public void getByIdTest() throws Exception {

        //持久化一个实体到数据表
        Klass klass = new Klass();

        //为这个班级设置一个随机的字符串
        String name = "panjiaqi";
        klass.setName(name);
        klassRepository.save(klass);

        //获取这个持久化的实体
        String geturl = url + klass.getId().toString();

        this.mockMvc
                .perform(get(geturl)
                        .contentType(MediaType.APPLICATION_JSON_UTF8))
                .andDo(print())
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.jsonPath("$.name").value(name));
    }

    //编辑方法测试
    @Test
    public void updateTest() throws Exception {
        //持久化一个实体到数据表
        Klass klass = new Klass();
        klassRepository.save(klass);

        //发起http请求，来更新这个实体
        String newname = "123";
        String puturl = url + klass.getId().toString();

        this.mockMvc
                .perform(MockMvcRequestBuilders.put(puturl)
                        .contentType(MediaType.APPLICATION_JSON_UTF8)
                        .content("{\"name\":\"" + newname + "\" }"))
                .andDo(print())
                .andExpect(status().isOk());

        //断言更新成功（到数据库里找到这个实体，并获取name，看是否成功）
        Klass newklass = klassRepository.findOne(klass.getId());
        assertThat(newklass.getName()).isEqualTo(newname);
    }

    @Test
    public void deleteTest() throws Exception {
        //新建一个对象
        Klass klass = new Klass();
        klassRepository.save(klass);

        String deleteUrl = url + klass.getId().toString();
        //调用C层删除方法
        this.mockMvc
                .perform(MockMvcRequestBuilders.delete(deleteUrl)
                        .contentType(MediaType.APPLICATION_JSON_UTF8))
                .andDo(print())
                .andExpect(status().is(HttpStatus.NO_CONTENT.value()));

        //断言删除成功
        Klass newKlass = klassRepository.findOne(klass.getId());
        assertThat(newKlass).isNull();
    }

    @Test
    public void page() throws Exception {
        String pageUrl = url + "page";
        this.mockMvc
                .perform(get(pageUrl)
                        .contentType(MediaType.APPLICATION_JSON_UTF8)
                .param("page","0")
                .param("size","2"))
                .andExpect(status().isOk())
                .andDo(print())
                .andExpect(MockMvcResultMatchers.jsonPath("$.totalElements").isNumber())
                .andExpect(MockMvcResultMatchers.jsonPath("$.number").value(0));
    }
}
