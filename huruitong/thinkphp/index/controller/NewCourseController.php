<?php 
namespace app\index\controller;
use think\Controller;
use think\Request;
use app\common\model\NewCourse;
use app\common\model\NewKlass;


/**
 * 第八章：新课程
 */

class NewCourseController extends Controller
{
    public function index() 
    {
        $klasses = NewKlass::all();
        $this->assign('klasses', $klasses);
        return $this->fetch();
    }

    // 新增
    public function add() 
    {
        $NewKlass = NewKlass::get();
        $this->assign('NewKlass',$NewKlass);
        return $this->fetch();
    }

    public function save() 
    {

        return;
    }

}