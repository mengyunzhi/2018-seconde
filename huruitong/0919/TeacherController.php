<?php
namespace app\index\controller;
use app\common\model\Teacher;

class TeacherController
{
    public function index()
    {
        $Teacher = new Teacher;
        $teachers = $Teacher->select();
        $teacher = $teachers[0];
        var_dump($teacher->getData());
        var_dump($teacher->getData('name'))
        echo $teacher->getData('name');
        return $teacher->getData('name');
    }
}
