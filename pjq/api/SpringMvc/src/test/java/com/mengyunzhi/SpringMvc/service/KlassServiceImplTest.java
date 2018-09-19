package com.mengyunzhi.SpringMvc.service;

import com.mengyunzhi.SpringMvc.entity.Klass;
import com.mengyunzhi.SpringMvc.repository.KlassRepository;
import org.apache.log4j.Logger;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;

import java.util.List;

import static org.assertj.core.api.Assertions.assertThat;


public class KlassServiceImplTest extends ServiceTest {
    private final static Logger logger = Logger.getLogger(KlassServiceImplTest.class.getName());

    @Autowired
    KlassService klassService;
    @Autowired
    KlassRepository klassRepository;

    @Test
    public void save() {
        logger.info("新建一个对象");
        Klass klass = new Klass();

        logger.info("调用保存方法");
        klassRepository.save(klass);

        logger.info("去数据表中查这个对象");
        Klass newKlass = klassRepository.findOne(klass.getId());

        logger.info("断言查询到旳值不是null");
        assertThat(newKlass).isNotNull();
    }

    @Test
    public void getAll() {
        logger.info("新建一个对象");
        Klass klass = new Klass();

        logger.info("调用保存方法");
        klassRepository.save(klass);

        List<Klass> KlassList = (List<Klass>) klassService.getAll();
        assertThat(KlassList.size()).isNotZero();
    }

    @Test
    public void delete() {
        logger.info("新建一个对象");
        Klass klass = new Klass();
        klassRepository.save(klass);

        logger.info("调用M层的删除方法");
        klassService.delete(klass.getId());

        logger.info("断言删除是否成功");
        Klass newKlass = klassRepository.findOne(klass.getId());
        assertThat(newKlass).isNull();
    }

    @Test
    public void page() {
        PageRequest pageRequest  = new PageRequest(0,2);
        Page<Klass> klasses = klassService.page(pageRequest);
        assertThat(klasses.getTotalElements()).isGreaterThanOrEqualTo(0);
    }
}