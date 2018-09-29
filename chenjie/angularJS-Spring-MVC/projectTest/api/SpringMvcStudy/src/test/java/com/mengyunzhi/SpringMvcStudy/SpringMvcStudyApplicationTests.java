package com.mengyunzhi.SpringMvcStudy;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import javax.transaction.Transactional;

@RunWith(SpringRunner.class)
@SpringBootTest
@Transactional  //事务，数据回滚
public class SpringMvcStudyApplicationTests {

	@Test
	public void contextLoads() {
	}

}
