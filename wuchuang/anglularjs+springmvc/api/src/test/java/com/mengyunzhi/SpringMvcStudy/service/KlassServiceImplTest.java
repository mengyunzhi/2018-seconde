package com.mengyunzhi.SpringMvcStudy.service;

import com.mengyunzhi.SpringMvcStudy.entity.Klass;
import com.mengyunzhi.SpringMvcStudy.repository.KlassRepository;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.List;
import java.util.logging.Logger;

import static org.assertj.core.api.Assertions.assertThat;

public class KlassServiceImplTest extends serviceTest {
    private final static Logger logger = Logger.getLogger(KlassServiceImplTest.class.getName());
    @Autowired KlassService klassService;
    @Autowired
    KlassRepository klassRepository;
    @Test
    public void save() throws Exception {
        logger.info("new一个对象");
        Klass klass = new Klass();
        logger.info("调用保存方法");
        klassService.save(klass);
        logger.info("数据表中查找");
        Klass newklass = klassRepository.findOne(klass.getId());
        logger.info("断言不是null");
        assertThat(newklass).isNotNull();

    }

    @Test
    public void getAll() {
        logger.info("new一个对象");
        Klass klass = new Klass();
        logger.info("调用保存方法");
        klassService.save(klass);

        List<Klass> klassList = (List<Klass>) klassService.getAll();
        assertThat(klassList.size()).isNotZero();
    }

    @Test
    public void delete() {
        logger.info("new一个对象");
        Klass klass = new Klass();
        logger.info("调用保存方法");
        klassRepository.save(klass);

        klassService.delete(klass.getId());

        Klass newKlass = klassRepository.findOne(klass.getId());
        assertThat(newKlass).isNull();
    }
}