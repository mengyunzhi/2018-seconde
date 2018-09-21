package com.mengyunzhi.carboncopies.controller;

import com.mengyunzhi.carboncopies.entity.Klass;
import com.mengyunzhi.carboncopies.service.KlassService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/klass")
public class KlassController {
    @Autowired
    KlassService klassService;
    @GetMapping("/getKlass{id}")
    public Klass getKlass(@PathVariable Long id) {
        return klassService.getKlass(id);
    }
    @GetMapping("/getAll")
    public Iterable<Klass> getAll() {
        return klassService.getAllKlass();
    }
    @PutMapping("/updata{id}")
    @ResponseStatus(HttpStatus.ACCEPTED)
    public Klass updata(@PathVariable Long id, @RequestBody Klass klass) {
        return klassService.updateKlass(id,klass);
    }
    @PostMapping("/add")
    @ResponseStatus(HttpStatus.CREATED)
    public Klass add(@RequestBody Klass klass) {
        return klassService.addKlass(klass);
    }
    @DeleteMapping("/delete{id}")
    public void delete(@PathVariable Long id) {
        klassService.deleteKlass(id);
        return;
    }
    @GetMapping("/getByPage")
    public Page<Klass> getByPage(@RequestParam int page, @RequestParam int size) {
        return klassService.getKlassPage(page, size);
    }
}
