package com.mengyunzhi.SpringMvcStudy.service;

import com.mengyunzhi.SpringMvcStudy.entity.Klass;
import com.mengyunzhi.SpringMvcStudy.repository.KlassRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class KlassServiceImpl implements KlassService {
    @Autowired KlassRepository klassRepository;
    @Override
    public Klass save(Klass klass) {
        return klassRepository.save(klass);
    }

    @Override
    public Iterable<Klass> getAll() {
        return klassRepository.findAll();
    }

    @Override
    public Klass getById(Long id) {
        return klassRepository.findOne(id);
    }

    @Override
    public void updateByIdAndKlass(Long id, Klass klass) {
        Klass newKlass = klassRepository.findOne(id);
        newKlass.setName(klass.getName());
        newKlass.setTeacher(klass.getTeacher());

        klassRepository.save(newKlass);
    }

    @Override
    public void delete(Long id) {
        klassRepository.delete(id);
    }
}
