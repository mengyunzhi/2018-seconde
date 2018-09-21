package com.mengyunzhi.SpringMvcStudy.service;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import java.util.logging.Logger;


@RunWith(SpringRunner.class)
@SpringBootTest
public class KlassServiceImplTest {
    private final static Logger logger  = Logger.getLogger(KlassServiceImplTest.class.getName());
    @Test
    public void save() throws  Exception{
        logger.info("new 一个对象");
        logger.info("调用保存方法");
    }
}