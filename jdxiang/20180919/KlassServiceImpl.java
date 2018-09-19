package com.mengyunzhi.carboncopies.service;

import com.mengyunzhi.carboncopies.entity.Klass;
import com.mengyunzhi.carboncopies.repository.KlassRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class KlassServiceImpl implements KlassService {
    @Autowired
    KlassRepository klassRepository;
    @Override
    public Klass getKlass(Long id) {
        return klassRepository.findById(id).get();
    }

    @Override
    public Iterable<Klass> getAllKlass() {
        return klassRepository.findAll();
    }

    @Override
    public void deleteKlass(Long id) {
        klassRepository.deleteById(id);
        return;
    }

    @Override
    public Klass updateKlass(Long id, Klass klass) {
        Klass updateKlass = klassRepository.findById(id).get();
        updateKlass.setName(klass.getName());
        updateKlass.setTeacher(klass.getTeacher());
        updateKlass.setSex(klass.isSex());
        updateKlass.setUsername(klass.getUsername());
        return klassRepository.save(updateKlass);
    }

    @Override
    public Klass addKlass(Klass klass) {
        return klassRepository.save(klass);
    }
}
