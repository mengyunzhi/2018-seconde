package com.mengyunzhi.carboncopies.service;

import com.mengyunzhi.carboncopies.entity.Course;
import com.mengyunzhi.carboncopies.entity.Klass;
import com.mengyunzhi.carboncopies.repository.CourseRepository;
import com.mengyunzhi.carboncopies.repository.KlassRepository;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import static org.assertj.core.api.Assertions.assertThat;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;


public class CourseServiceImplTest extends ServiceTest{
    @Autowired
    CourseRepository courseRepository;
    @Autowired CourseService courseService;
    @Autowired
    KlassRepository klassRepository;

    @Test
    public void getAll() {
        Course course1 = new Course();
        course1.setName("couse1");
//        course.setKlasses(klasses);
        courseRepository.save(course1);
        Course course2 = new Course();
        course2.setName("couse2");
        courseRepository.save(course2);

        List<Course> courses = (List<Course>) courseService.getAll();
        assertThat(courses.size()).isEqualTo(2);
        assertThat(courses.get(0)).isEqualTo(course1);
        assertThat(courses.get(1)).isEqualTo(course2);
    }

    @Test
    public void getById() {
        Course course = new Course();
        courseRepository.save(course);
        Long id = course.getId();

        Course getCourse = courseService.getById(id);
        assertThat(getCourse).isEqualTo(course);
    }

    @Test
    public void update() {
        Course oldCourse = new Course();
        List<Klass> klasses = new ArrayList<Klass>();
        Klass oldKlass = new Klass();
        klasses.add(oldKlass);
        oldCourse.setKlasses(klasses);
        courseRepository.save(oldCourse);
        Long id = oldCourse.getId();

        Course newCourse = new Course();
        List<Klass> newKlasses = new ArrayList<Klass>();
        Klass newKlass = new Klass();
        newKlasses.add(newKlass);
        newCourse.setKlasses(newKlasses);

        courseService.update(id, newCourse);

        Course course = courseRepository.findById(id).get();

        assertThat(course.getKlasses().get(0)).isEqualTo(newKlass);

    }

    @Test
    public void delete() {
        Course course = new Course();
        courseRepository.save(course);
        Long id = course.getId();
        courseService.delete(id);

        Optional<Course> deleteCourse = courseRepository.findById(id);
        assertThat(deleteCourse).isEmpty();
    }

    @Test
    public void add() {
        Klass klass1 = new Klass();
        klassRepository.save(klass1);
        List<Klass> klasses = new ArrayList<Klass>();
        klasses.add(klass1);

        Course course = new Course();
        course.setKlasses(klasses);
        courseService.add(course);
        Long id = course.getId();

        Course getCourse = courseRepository.findById(id).get();
        assertThat(getCourse).isEqualTo(course);
        assertThat(getCourse.getKlasses().get(0)).isEqualTo(klasses.get(0));
    }
}