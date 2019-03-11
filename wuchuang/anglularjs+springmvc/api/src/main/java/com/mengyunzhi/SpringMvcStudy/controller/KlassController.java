package com.mengyunzhi.SpringMvcStudy.controller;

import com.mengyunzhi.SpringMvcStudy.entity.Klass;
import com.mengyunzhi.SpringMvcStudy.service.KlassService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/Klass")
public class KlassController {
    @Autowired
    KlassService klassService;

    @PostMapping("/")
    @ResponseStatus(HttpStatus.CREATED)
    public Klass save(@RequestBody Klass klass) {
        return klassService.save(klass);
    }

    @GetMapping("/")
    public Iterable<Klass> getAll() {
        return klassService.getAll();

    }

    @GetMapping("/{id}")
    public Klass getById(@PathVariable Long id) {
        return klassService.getById(id);
    }

    @PutMapping("/{id}")
    public void update(@PathVariable Long id, @RequestBody Klass klass)
    {
        klassService.updateByIdAndKlass(id, klass);
    }

    @DeleteMapping("/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void delete(@PathVariable Long id)
    {
        klassService.delete(id);
    }

}
