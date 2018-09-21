package com.mengyunzhi.SpringMvcStudy.controller;

import com.mengyunzhi.SpringMvcStudy.repository.Klass;
import com.mengyunzhi.SpringMvcStudy.repository.KlassRepository;
import com.mengyunzhi.SpringMvcStudy.service.KlassService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * @author 某杰
 */
@RestController
@RequestMapping("/Klass")
public class KlassController {
    @Autowired
    KlassRepository klassRepository;

    @Autowired
    KlassService klassService;

    @PostMapping("/")
    public Klass save(@RequestBody Klass klass) {
        return  klassService.save(klass);
    }
}
