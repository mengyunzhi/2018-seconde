package com.mengyunzhi.SpringMvcStudy.service;

import com.mengyunzhi.SpringMvcStudy.entity.Klass;

public interface KlassService {
    Klass save(Klass klass);

    Iterable<Klass> getAll() ;

    Klass getById(Long id);

    void updateByIdAndKlass(Long id, Klass klass);

    void delete(Long id);
}
