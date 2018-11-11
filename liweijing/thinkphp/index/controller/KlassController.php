<?php
namespace app\index\controller;
use app\common\model\Klass;   // 班级
use think\Request;            // 请求
use app\common\model\Teacher;
class KlassController extends IndexController
{
    public function add()
    {
        // 获取所有的教师信息
        $teachers = Teacher::all();
        $this->assign('teachers',$teachers);
        return $this->fetch();
    }
    public function save()
    {
       $Request = Request::instance();
       $Klass = new Klass;
       $Klass->name = $Request->post('name');
       $klass->teacher_id = $Request->post('teacher_id/d');
       $Klass->save();
    }
    public function index()
    {
        $klasses = Klass::paginate();
        $this->assign('klasses',$klasses);
        return $this->fetch();
    }
}