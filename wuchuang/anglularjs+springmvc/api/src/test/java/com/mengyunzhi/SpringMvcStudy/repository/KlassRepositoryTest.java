package com.mengyunzhi.SpringMvcStudy.repository;

import com.mengyunzhi.SpringMvcStudy.SpringMvcStudyApplicationTests;
import com.mengyunzhi.SpringMvcStudy.entity.Klass;
import org.junit.Test;

import org.springframework.beans.factory.annotation.Autowired;

import static org.assertj.core.api.AssertionsForInterfaceTypes.assertThat;

public class KlassRepositoryTest extends SpringMvcStudyApplicationTests {
    @Autowired KlassRepository klassRepository;
    @Test
    public void findTest() {
        Iterable<Klass> klasses = klassRepository.findAll();
        assertThat(klasses).isNotNull();
    }
}