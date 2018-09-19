package com.mengyunzhi.carboncopies.service;

import com.mengyunzhi.carboncopies.entity.Klass;

public interface KlassService {
    Klass getKlass(Long id);
    Iterable<Klass> getAllKlass();
    void deleteKlass(Long id);
    Klass updateKlass(Long id, Klass klass);
    Klass addKlass(Klass klass);
}
