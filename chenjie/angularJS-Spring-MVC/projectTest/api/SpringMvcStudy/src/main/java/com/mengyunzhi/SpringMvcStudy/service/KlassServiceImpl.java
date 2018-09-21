package com.mengyunzhi.SpringMvcStudy.service;

import com.mengyunzhi.SpringMvcStudy.repository.Klass;
import com.mengyunzhi.SpringMvcStudy.repository.KlassRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class KlassServiceImpl implements KlassService {
    @Autowired
    KlassRepository klassRepository;    //班级

    @Override
    public Klass save(Klass klass) {
        return klassRepository.save(klass);
    }
}
