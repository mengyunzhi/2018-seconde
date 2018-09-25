package com.mengyunzhi.SpringMvcStudy.service;

import com.mengyunzhi.SpringMvcStudy.repository.Klass;
import com.mengyunzhi.SpringMvcStudy.repository.KlassRepository;
import com.mengyunzhi.SpringMvcStudy.repository.Teacher;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;

import java.util.List;
import java.util.logging.Logger;

import static org.assertj.core.api.Assertions.assertThat;


@RunWith(SpringRunner.class)
@SpringBootTest
public class KlassServiceImplTest extends ServiceTest {
    private final static Logger logger = Logger.getLogger(KlassServiceImplTest.class.getName());
    @Autowired
    KlassService klassService;
    @Autowired
    KlassRepository klassRepository;

    @Test
    public void saveTest() throws Exception{
        logger.info("new 一个对象");
        Klass klass = new Klass();

        logger.info("调用保存方法");
        klassService.save(klass);

        logger.info("去数据表查这个对象");
        Klass newklass = klassRepository.findOne(klass.getId());

        logger.info("断言查询到的值不是null");
        assertThat(newklass).isNotNull();
    }

    @Test
    public void getAllTest() throws Exception{
        logger.info("new一个对象");
        Klass klass = new Klass();

        logger.info("调用保存方法");
        klassService.save(klass);

        List<Klass> klassList = (List<Klass>) klassService.getAll();
        assertThat(klassList.size()).isNotZero();
    }

    @Test
    public void deleteTest() throws Exception{
        logger.info("new一个对象");
        Klass klass = new Klass();
        klassRepository.save(klass);

        logger.info("调用M层的删除方法");
        klassService.delete(klass.getId());

        logger.info("断言删除是否成功");
        Klass newKlass = klassRepository.findOne(klass.getId());
        assertThat(newKlass).isNull();
    }
}
