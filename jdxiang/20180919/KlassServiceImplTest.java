package com.mengyunzhi.carboncopies.service;

import com.mengyunzhi.carboncopies.entity.Klass;
import com.mengyunzhi.carboncopies.entity.Teacher;
import com.mengyunzhi.carboncopies.repository.KlassRepository;
import com.mengyunzhi.carboncopies.repository.TeacherRepository;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.List;
import java.util.Optional;

import static org.assertj.core.api.Assertions.assertThat;

public class KlassServiceImplTest extends ServiceTest{
    @Autowired
    KlassRepository klassRepository;
    @Autowired
    KlassService klassService;
    @Autowired
    TeacherRepository teacherRepository;
    @Test
    public void getKlass() {
        Klass newKlass = new Klass();
        String newKlassName = "newKlass";
        newKlass.setName(newKlassName);
        Teacher newTeacher = new Teacher();
        String newTeacherName = "newTeacher";
        newTeacher.setName(newTeacherName);
        newKlass.setTeacher(newTeacher);
        klassRepository.save(newKlass);
        Long id = newKlass.getId();
        Klass getKlass = klassService.getKlass(id);
        assertThat(getKlass.getName()).isEqualTo(newKlassName);
        assertThat(getKlass.getTeacher().getName()).isEqualTo(newTeacherName);
    }

    @Test
    public void getAllKlass() {
        Teacher t1 = new Teacher();
        t1.setName("t1name");
        teacherRepository.save(t1);
        Klass klass1 = new Klass();
        String klass1Name = "klass1Name";
        klass1.setTeacher(t1);
        klass1.setName(klass1Name);
        klassRepository.save(klass1);

        Klass klass2 = new Klass();
        String klass2Name = "klass2Name";
        klass2.setName(klass2Name);
        klassRepository.save(klass2);



        List<Klass> klasses = (List<Klass>) klassService.getAllKlass();
        assertThat(klasses.size()).isEqualTo(2);
        assertThat(klasses.get(0).getName()).isEqualTo(klass1Name);
        assertThat(klasses.get(0).getTeacher().getName()).isEqualTo("t1name");
        assertThat(klasses.get(1).getName()).isEqualTo(klass2Name);
    }

    @Test
    public void deleteKlass() {
        Klass klass = new Klass();
        klassRepository.save(klass);
        Long id = klass.getId();
        klassService.deleteKlass(id);
        Optional<Klass> deleteKlass = klassRepository.findById(id);
        assertThat(deleteKlass).isEmpty();
    }

    @Test
    public void updateKlass() {
        Klass klass = new Klass();
        Teacher oldTeacher = new Teacher();
        oldTeacher.setName("oldTeacher");
        teacherRepository.save(oldTeacher);
        String oldName = "oldName";
        klass.setName(oldName);
        klass.setTeacher(oldTeacher);
        klassRepository.save(klass);
        Long id = klass.getId();

        Klass updateKlass = new Klass();
        Teacher newTeacher = new Teacher();
        newTeacher.setName("newTeacher");
        String newName = "newName";
        updateKlass.setName(newName);
        teacherRepository.save(newTeacher);
        updateKlass.setTeacher(newTeacher);

        klassService.updateKlass(id, updateKlass);
        Klass newKlass = klassRepository.findById(id).get();
        assertThat(newKlass.getName()).isEqualTo(newName);
        assertThat(newKlass.getTeacher().getName()).isEqualTo("newTeacher");
    }

    @Test
    public void addKlass() {
        Klass klass = new Klass();
        String klassName = "addKlassName";
        klass.setName(klassName);
        Teacher teacher = new Teacher();
        String teacherName = "addTeacherName";
        teacher.setName(teacherName);
        teacherRepository.save(teacher);
        klass.setTeacher(teacher);
        klassService.addKlass(klass);
        Klass newKlass = klassRepository.findById(klass.getId()).get();
        assertThat(newKlass.getName()).isEqualTo(klassName);
        assertThat(newKlass.getTeacher().getName()).isEqualTo(teacherName);
    }
}