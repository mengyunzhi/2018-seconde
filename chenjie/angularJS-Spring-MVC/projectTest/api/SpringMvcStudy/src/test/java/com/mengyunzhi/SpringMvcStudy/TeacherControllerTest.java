package com.mengyunzhi.SpringMvcStudy;

import com.mengyunzhi.SpringMvcStudy.repository.Teacher;
import com.mengyunzhi.SpringMvcStudy.repository.TeacherRespository;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;

import static org.assertj.core.api.Assertions.assertThat;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.delete;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.put;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@RunWith(SpringRunner.class)
@SpringBootTest
@AutoConfigureMockMvc
public class TeacherControllerTest {
    @Autowired
    private MockMvc mockMvc; //模拟进行REST请求

    @Autowired
    TeacherRespository teacherRespository;

    @Test
    public void getAllTest() throws Exception {
        String url = "/Teacher";
        this.mockMvc
                .perform(get(url))  //用put方法请求这个ur
                .andDo(print()) // 请求后，打印请求数据
                .andExpect(status().isOk()); // 断言返回的状态为真
    }

    @Test
    public void getTest() throws Exception {
        //创建一条数据
        Teacher teacher = new Teacher();
        teacher.setUsername("name");
        teacher.setUsername("username");
        teacher.setEmail("email");
        teacher.setSex(true);
        teacherRespository.save(teacher);

        String url = "/Teacher/" + String.valueOf(teacher.getId());
        this.mockMvc
                .perform(get(url))  //用put方法请求这个ur
                .andDo(print()) // 请求后，打印请求数据
                .andExpect(status().isOk()); // 断言返回的状态为真
    }

    @Test
    public void  updateTest() throws Exception {
        // 添加测试数据
        // 实例化一个Teacher并且持久化
        Teacher teacher = new Teacher();
        teacherRespository.save(teacher);

        // 更新持久化的Teacher
        String url = "/Teacher/" + teacher.getId();
        this.mockMvc
                .perform(get(url)
                        .contentType(MediaType.APPLICATION_JSON_UTF8)
                        .content("{}"))  //用get方法请求这个url
                .andDo(print()) // 请求后，打印请求数据
                .andExpect(status().isOk()); // 断言返回的状态为真
    }

    @Test
    public  void  deleteTest() throws Exception {
        // 先添加一个数据
        Teacher teacher = new Teacher();
        teacherRespository.save(teacher);
        Long id = teacher.getId();
        // 再删除这个数据
        String url = "/Teacher/" + teacher.getId();
        this.mockMvc
                .perform(delete(url)
                        .contentType(MediaType.APPLICATION_JSON_UTF8))
                .andDo(print()) // 请求后，打印请求数据
                .andExpect(status().isOk()); // 断言返回的状态为真
        // 断言这个数据删除已成功
        Teacher newTeacher = teacherRespository.findOne(id);
        assertThat(newTeacher).isNull();
    }
}
