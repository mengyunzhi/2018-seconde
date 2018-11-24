<?php
namespace app\index\controller;
use app\common\model\Student;
use app\common\model\Klass;
use think\Request;    // 请求

class StudentController extends IndexController
{
    public function index()
    {
        $students = Student::paginate();
        $this->assign('students',$students);
        return $this->fetch();
    }
    public function edit()
    {
        $id = Request::instance()->param('id/d');

        // 判断是否存在当前记录
        if (is_null($Student = Student::get($id))) {
            return $this->error('未找到ID为' . $id . '的记录');
        }

        // 取出班级列表
        $klasses = Klass::all();
        $this->assign('klasses', $klasses);

        $this->assign('Student', $Student);
        return $this->fetch();
    }
} 