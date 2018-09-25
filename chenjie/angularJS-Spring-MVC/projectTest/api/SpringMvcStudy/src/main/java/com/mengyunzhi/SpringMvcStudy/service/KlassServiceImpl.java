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

    @Override
    public Iterable<Klass> getAll() {
        return klassRepository.findAll();
    }

    @Override
    public Klass getById(Long id) {
        return klassRepository.findOne(id);
    }

    @Override
    public void updateByIdAndKlass(Long id, Klass newKlass) {
        // 获取传入的ID对应的实体
        Klass oldKlass = klassRepository.findOne(id);

        // 更新实体的内容
        if (oldKlass != null) {
            oldKlass.setName(newKlass.getName());
            oldKlass.setTeacher(newKlass.getTeacher());

            klassRepository.save(oldKlass);
        }
    }

    @Override
    public void delete(Long id) {
        klassRepository.delete(id);
    }
}
